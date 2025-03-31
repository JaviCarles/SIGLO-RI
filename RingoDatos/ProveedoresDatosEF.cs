using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoDatos
{
    public class ProveedoresDatosEF
    {
        public static RingoDbContext RingoContext;

        
        public static int existeProveedor(Empresas? prov)
        {
            if (prov == null)
            {
                return 0;
            }

            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null || RingoContext.Empresas == null)
            {
                return 0;
            }
            string razonSocial = prov.RazonSocial;
            string cuit = prov.Cuit ?? "0";

            Empresas? empresa = RingoContext.Empresas.Where(e => 
                            e.RazonSocial.Equals(razonSocial) || (e.Cuit != null && e.Cuit == cuit)).FirstOrDefault();
            if (empresa == null)
            {
                return 0;
            }
            Proveedores? proveedor = RingoContext.Proveedores.FirstOrDefault(p => p.IdEmpresa == empresa.IdEmpresa);
            if (proveedor == null)
            {
                return -1;
            }

            return (int)proveedor.IdProveedor;
        }

        public static Domicilios? DomicilioPorEmpresa(Empresas? empresa)
        {
            if (empresa == null)
            {
                return null;
            }
            if (empresa.IdDomicilio == null)
            {
                return null;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.Empresas == null || RingoContext.Domicilios == null)
            {
                return null;
            }
            Domicilios? dom = RingoContext.Domicilios.Include("Barrios").Include("Ciudades.Provincias").Where(d => d.IdDomicilio == empresa.IdDomicilio).FirstOrDefault();

            return dom;
        }

        public static List<Contactos>? ContactosPorProveedor(Empresas? empresa)
        {
            if (empresa == null)
            {
                return null;
            }

            RingoContext = new RingoDbContext();
            if (RingoContext.Empresas == null || RingoContext.Contactos == null)
            {
                return null;
            }
            List<Contactos>? contactos = new();
            contactos = RingoContext.Contactos.Include("UsersRedesSociales.RedesSociales").Where(c => c.IdEmpresa != null && c.IdEmpresa == empresa.IdEmpresa).ToList();
            if (contactos ==  null || contactos.Count == 0)
            {
                return null;
            }

            return contactos;
        }

        public static List<Proveedores>? getProveedores(bool baja)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null || RingoContext.Estados == null || RingoContext.Empresas == null)
            {
                return null;
            }
            List<Proveedores>? proveedores = new();

            //el booleano me dice si la busqueda incluye a los estados Baja
            //Así que transformo para facilitar la búsqueda
            int e;
            if (baja)
                e = 0;
            else
                e = EstadosId("Baja", RingoContext);

            proveedores = RingoContext.Proveedores.Include("Empresas.CondicionesFiscales").Include("Estados").Where(p =>
                                            p.IdEstado != e).OrderBy(p => p.Empresas.RazonSocial).ToList();
            if (proveedores == null || proveedores.Count == 0)
            {
                return null;
            }

            return proveedores;
        }

        public static List<Proveedores>? getProveedoresFiltrados(List<string>? datos, List<string>? datosPrenda, bool baja)
        {
            if (datos == null && datosPrenda == null)
            {
                return null;
            }

            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null || RingoContext.Estados == null || RingoContext.Empresas == null)
            {
                return null;
            }
            List<Proveedores>? proveedores = new();

            //el booleano me dice si la busqueda incluye a los estados Baja
            //Así que transformo para facilitar la búsqueda
            int e;
            if (baja)
                e = 0;
            else
                e = EstadosId("Baja", RingoContext);

            List<int>? idEmpresasDatos = new List<int>();

            if (datos != null)
            {
                idEmpresasDatos = RingoContext.Empresas.Where(e => e.IdEmpresa != null).AsEnumerable()
                                    .Where(e => datos.Any(d => e.RazonSocial.Contains(d) || (e.Cuit ?? "").Contains(d)))
                                    .Select(e => (int)e.IdEmpresa).ToList();
            }

            idEmpresasDatos.Add(0);



            List<int> idProvPrendas = new List<int>();

            if (datosPrenda != null)
            {
                idProvPrendas = RingoContext.Prendas.AsEnumerable().Where(pr => pr.IdProveedor != null &&
                                        datosPrenda.Any(d => pr.DescripcionPrenda.Contains(d)
                                    || pr.CodigoPrenda.Contains(d))).Select(pr => (int)pr.IdProveedor).ToList();
            }
            idProvPrendas.Add(0);
            
            

            proveedores = RingoContext.Proveedores.Include("Empresas.CondicionesFiscales").Include("Estados").Where(p =>
                                            p.IdEstado != e && (idEmpresasDatos.Contains(p.IdEmpresa) || idProvPrendas.Contains((int)p.IdProveedor))
                                            ).OrderBy(p => p.Empresas.RazonSocial).ToList();

            if (proveedores == null || proveedores.Count == 0)
            {
                return null;
            }

            return proveedores;
        }

        public static Proveedores? getProveedorPorId(int id)
        {
            if (id < 1)
            {
                return null;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null || RingoContext.Empresas == null)
            {
                return null;
            }
            Proveedores? prov = RingoContext.Proveedores.Include("Empresas.Domicilios").Include("Empresas.CondicionesFiscales").Include("Estados").FirstOrDefault(p => p.IdProveedor == id);

            return prov;
        }

        public static int EstadosId(string baja, RingoDbContext RingoContext)
        {
            int? id = 0;
            if (String.IsNullOrWhiteSpace(baja))
                return 0;
            if (RingoContext.Estados == null)
                return 0;
            id = (from e in RingoContext.Estados
                  where e.IdEstado != null && e.Indole == "Proveedores"
                  && e.Estado == baja
                  select e.IdEstado).FirstOrDefault();
            if (id == null)
                return 0;
            else
                return (int)id;
        }

        public static int insertProveedor(Proveedores? proveedor)
        {
            if (proveedor == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null || RingoContext.Empresas == null)
            {
                return 0;
            }
            proveedor.IdProveedor = null;
            RingoContext.Add(proveedor);
            RingoContext.SaveChanges();
            if (proveedor.IdProveedor == null || proveedor.IdEmpresa == 0)
                return 0;
            return (int)proveedor.IdEmpresa;
        }


        public static int updateEmpresa(Empresas? empresa)
        {
            if (empresa == null)
                return 0;
            if (empresa.IdEmpresa == null) 
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext.Empresas == null)
            {
                return 0;
            }
            Empresas? emp = RingoContext.Empresas.FirstOrDefault(e => e.IdEmpresa ==  empresa.IdEmpresa);
            if (emp == null)
            {
                return 0;
            }
            emp.IdCondicionFiscal = empresa.IdCondicionFiscal;
            emp.IdDomicilio = empresa.IdDomicilio;
            emp.Cuit = empresa.Cuit;
            emp.RazonSocial = empresa.RazonSocial;
            emp.InicioActividades = empresa.InicioActividades;
            int v = RingoContext.SaveChanges();
            return v;
        }

        public static int updateProveedor(Proveedores? proveedor)
        {
            if (proveedor == null)
                return 0;
            if (proveedor.IdProveedor == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext.Proveedores == null)
            {
                return 0;
            }

            Proveedores? prov = RingoContext.Proveedores.FirstOrDefault(p => p.IdProveedor == proveedor.IdProveedor);
            if (prov == null)
            {
                return 0;
            }
            prov.IdEstado = proveedor.IdEstado;
            prov.DetalleProveedor = proveedor.DetalleProveedor;
            int v = RingoContext.SaveChanges();
            return v;
        }
    }
}
