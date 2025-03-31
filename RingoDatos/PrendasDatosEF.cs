using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoDatos
{
    public class PrendasDatosEF
    {
        static RingoDbContext? prendasContext;
        public static List<Prendas>? Get(Prendas p) // este método debe devolver una lista de prendas
        {
            prendasContext = new RingoDbContext();

            if (prendasContext.Prendas == null) //verificamos si existe la tabla Prendas (por las dudas)
            {
                return new List<Prendas>();
            }

            List<Prendas>? list = new();

         
            return list;
        }

        public static EstadosPrendas? getEstadoPrendaPorId(int id, ref string mensaje)
        {
            if (id < 1)
            {
                mensaje = "El identificador viaja vacío";
                return null;
            }
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
            {
                mensaje = "Error al conectarse a la Base de Datos";
                return null;
            }

            EstadosPrendas? estado = prendasContext.EstadosPrendas.Include("EstadosHistorias.EstadosActuales").Include("Prendas").Include("DetallesPrendas").FirstOrDefault(e => 
                                                e.IdEstadosPrendas == id);
            if (estado == null)
            {
                return null;
            }
            Estados? estadoAnterior = null;
            if (estado.EstadosHistorias.IdEstadoAnterior != null)
            {
                estadoAnterior = prendasContext.Estados.FirstOrDefault(e => e.IdEstado == estado.EstadosHistorias.IdEstadoAnterior);
            }
            estado.EstadosHistorias.EstadosAnteriores = estadoAnterior;

            return estado;

        }


        public static void editarPrenda(DetallesPrendas det)
        {
            if (det == null)
            {

            }
        }

        public static string codigoSugerido()
        {
            string codigo = "10000";
            prendasContext = new RingoDbContext();
            if (prendasContext.Prendas == null)
                return "";
            codigo = prendasContext.Prendas.Max(p => p.CodigoPrenda);
            int cod = 0;
            if(!int.TryParse(codigo, out cod))
            {
                return "10000";
            }
            cod++;
            codigo = cod.ToString();
            return codigo;
        }

        public static List<Prendas> getPrenda(string pren, bool stock)
        {
            prendasContext = new RingoDbContext();
            List<Prendas>? list = new List<Prendas>();
            int stk = 0;
            if (stock)
                stk = -100;
            if (!string.IsNullOrEmpty(pren))
            {
                list = prendasContext.Prendas
                        .Include("CategoriaSubCategoria.CategoriasPrendas").Include("CategoriaSubCategoria.SubCategoriasPrendas")
                        .Include("Telas").Include("Proveedores.Empresas")
                        .Where(c =>c.Cantidad > stk && (c.DescripcionPrenda.Contains(pren)
                || c.CodigoPrenda.Contains(pren))).OrderBy(c => c.DescripcionPrenda).ToList();
            }
            else
                list = prendasContext.Prendas
                     .Include("CategoriaSubCategoria.CategoriasPrendas").Include("CategoriaSubCategoria.SubCategoriasPrendas")
                     .Include("Telas").Include("Proveedores.Empresas").Where(c => c.Cantidad > stk)
                     .OrderBy(p => p.DescripcionPrenda).ToList();

            /* if (list.Count == 0)
                 list = null;*/

            return list;
        }

        public static List<DetallesPrendas>? getDetallesPrenda(int? pren)
        {
            prendasContext = new RingoDbContext();
            List<DetallesPrendas>? list = new List<DetallesPrendas>();

            if (pren != null || pren > 0)
            {
                list = prendasContext.DetallesPrendas
                    .Include("Prenda")
                    .Include("Talle").Where(c => c.IdPrenda == pren).OrderBy(d => d.CodigoDetalle).ToList();
            }

            if (list.Count == 0)
                list = null;

            return list;
        }
        public static Prendas? VerificarPrenda(Prendas? pren)
        {
            if (pren == null)
                return null;
            prendasContext = new RingoDbContext();
            if (prendasContext == null)
                return null;
            if (prendasContext.Prendas == null)
                return null;
            Prendas? prenda = new Prendas();
            prenda = (from p in prendasContext.Prendas
                      where p.IdPrenda != null &&
                      (p.CodigoPrenda == pren.CodigoPrenda
                      || p.DescripcionPrenda == pren.DescripcionPrenda)
                      select p).FirstOrDefault();
            return prenda;
        }

        public static List<Proveedores> getProveedores()
        {
            prendasContext = new RingoDbContext();
            if (prendasContext == null || prendasContext.Proveedores == null)
                return null;
            List<Proveedores>? list = new();
            list = prendasContext.Proveedores.Include(p => p.Empresas).ToList();
            if (list == null || list.Count == 0)
                return new();
            return list;
        }
        public static List<Telas>? GetTelas()
        {
            prendasContext = new RingoDbContext();
            if (prendasContext == null || prendasContext.Telas == null)
                return null;
            List<Telas>? list = new();
            list = prendasContext.Telas.OrderBy(t => t.Tela).ToList();
            if (list.Count == 0)
                return null;
            return list;
        }

        public static List<CategoriaSubCategoria>? GetCategoriasSubCategorias()
        {
            prendasContext = new RingoDbContext();
            if (prendasContext == null || prendasContext.CategoriaSubCategoria == null)
                return null;
            List<CategoriaSubCategoria>? list = new();
            list = prendasContext.CategoriaSubCategoria.Include("CategoriasPrendas").Include("SubCategoriasPrendas").ToList();
            if (list.Count == 0)
                return null;
            return list;
        }
        
        public static int ExisteTela(Telas t)
        {
            if (t == null)
                return 1;
            if (t.Tela == "")
                return 1;
            prendasContext = new RingoDbContext();
            if (prendasContext == null || prendasContext.Telas == null)
                return 1;
            Telas? tela = new();
            tela = (from T in prendasContext.Telas
                    where T.IdTela != null && T.Tela == t.Tela
                    select T).FirstOrDefault();
            if (tela == null)
                return 0;
            return (int)tela.IdTela;
        }

        public static int ExisteCategoria(CategoriasPrendas c)
        {
            if (c == null)
                return 1;
            if (c.Categoria == "")
                return 1;
            prendasContext = new RingoDbContext();
            if (prendasContext == null || prendasContext.CategoriasPrendas == null)
                return 1;
            if (c.IdCategoriaPrenda == null)
                c.IdCategoriaPrenda = 0;
            CategoriasPrendas? categoria = new();
            categoria = (from C in prendasContext.CategoriasPrendas
                         where C.IdCategoriaPrenda != null &&
                         (c.Categoria == C.Categoria
                         || c.IdCategoriaPrenda == C.IdCategoriaPrenda)
                         select C).FirstOrDefault();
            if (categoria == null)
                return 0;
            return (int)categoria.IdCategoriaPrenda;
        }

        
        public static List<Talles>? getTalles()
        {
            List<Talles>? talles = new();
            prendasContext = new RingoDbContext();

            if (prendasContext.Talles == null)
            { return null; }
            talles = prendasContext.Talles.OrderBy(t => t.DescripcionTalle).ToList();
            if (talles.Count == 0)
                return null;
            return talles;
        }

        public static List<EstadosPrendas>? GetEstadoPrenda(DetallesPrendas? detalles)
        {
            if (detalles == null)
                return null;
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
                return null;

            List<EstadosPrendas>? estados = prendasContext.EstadosPrendas.Include("EstadosHistorias.EstadosActuales").Where(
                                        e => e.IdDetallePrenda != null && e.IdDetallePrenda == detalles.IdDetallePrenda).ToList();

            if (estados.Count == 0)
                return null;

            return estados;
        }

        public static List<EstadosPrendas>? GetEstadosPrendas(Prendas? prenda, bool sinStock)
        {
            if (prenda == null)
                return null;
            if (prenda.IdPrenda == null)
                return null;
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
                return null;
            List<EstadosHistorias>? estadosHistoriasPrendas = RingoDatosEF.EstadosHistoriasPorIndole("Prendas");
            if (estadosHistoriasPrendas.Count == 0)
                return null;
            List<int>? idsStock = new();
            int stock = 0;
            if (sinStock) 
            { 
                idsStock = (from e in estadosHistoriasPrendas select (int)e.IdEstadoHistoria).ToList();
                stock = -100;
            }
            else
                idsStock = (from e in estadosHistoriasPrendas where e.EstadoActual == "Apta" || e.EstadoActual == "Outlet" select (int)e.IdEstadoHistoria).ToList();
            if (idsStock.Count == 0)
                return null;

            List<EstadosPrendas>? estados = prendasContext.EstadosPrendas.Include("EstadosHistorias.EstadosActuales").Include("DetallesPrendas.Talle").Include("Prendas").Where(
                                                        e => e.IdPrenda == (int)prenda.IdPrenda && idsStock.Contains(e.IdEstadoHistoria) && e.CantidadEstado > stock).ToList();
            if (estados.Count == 0)
                return null;
            return estados;
        }

        public static List<EstadosPrendas>? GetEstadosPrendas(List<Prendas>? prendas, bool sinStock)
        {
            if (prendas == null || prendas.Count == 0)
                return null;

            using var prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
                return null;

            List<EstadosHistorias>? estadosHistoriasPrendas = RingoDatosEF.EstadosHistoriasPorIndole("Prendas");
            if (estadosHistoriasPrendas.Count == 0)
                return null;

            List<int>? idsStock = new();
            int stock = 0;
            if (sinStock)
            {
                idsStock = (from e in estadosHistoriasPrendas select (int)e.IdEstadoHistoria).ToList();
                stock = -1;
            }
            else
            {
                idsStock = (from e in estadosHistoriasPrendas where e.EstadoActual == "Apta" || e.EstadoActual == "Outlet" select (int)e.IdEstadoHistoria).ToList();
            }

            if (idsStock.Count == 0)
                return null;

            List<EstadosPrendas>? estados = new();
            foreach (var prenda in prendas)
            {
                var estadosPrenda = prendasContext.EstadosPrendas.Include("EstadosHistorias.EstadosActuales")
                                                  .Include("DetallesPrendas").Include("Prendas")
                                                  .Where(e => e.IdPrenda == (int)prenda.IdPrenda && idsStock.Contains(e.IdEstadoHistoria) && e.CantidadEstado > stock)
                                                  .ToList();

                if (estadosPrenda != null && estadosPrenda.Count > 0)
                    estados.AddRange(estadosPrenda);
            }

            if (estados.Count == 0)
                return null;

            return estados;
        }

        public static string? getEstadoPorId(int id)
        {
            if (id == 0)
            {
                return null;
            }
            prendasContext = new RingoDbContext();
            if (prendasContext.Estados == null)
            {
                return null;
            }
            string? estado = (from e in prendasContext.Estados where e.IdEstado == id select e.Estado).FirstOrDefault();
            return estado;
        }

        public static EstadosHistorias? getEstadoHistoria(int id)
        {
            if (id == 0)
            {
                return null;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.Estados == null || prendasContext.EstadosHistorias == null)
            {
                return null;
            }

            EstadosHistorias? estado = prendasContext.EstadosHistorias.Include("EstadosActuales").Include("EstadosAnteriores").Where(e => e.IdEstadoHistoria == id).FirstOrDefault();   
            return estado;

        }

        //Inserts


        public static int InsertarCategoriaSubCategoria(CategoriaSubCategoria? cs)
        {
            if (cs == null)
                return 0;

            if (cs.IdCategoriaPrenda != null)
                return 0;

            prendasContext = new RingoDbContext();

            if (prendasContext == null)
                return 0;

            if (prendasContext.CategoriaSubCategoria == null)
                return 0;

            if (cs.IdCategoriaPrenda != null)
                cs.CategoriasPrendas = null;
            if (cs.IdSubCategoriaPrenda == null)
                cs.SubCategoriasPrendas = null;

            cs.IdCateSubCate = null;
            prendasContext.CategoriaSubCategoria.Add(cs);
            prendasContext.SaveChanges();
            if (cs.IdCateSubCate == null)
                return 0;

            return (int)cs.IdCateSubCate;
        }

       
        public static int Insert(Prendas? pren /*, DetallesPrendas detPren*/)
        {
            if (pren == null)
                return 0;

            prendasContext = new RingoDbContext();
            if (prendasContext.Prendas == null)
            {
                return 0;
            }

            if (pren.IdTela != null)
                pren.Telas = null;
            if (pren.IdCateSubCate != null)
                pren.CategoriaSubCategoria = null;

            //seteo el ID en null para que realice el insert porque si tiene otro valor EF
            //lo toma como un update
            pren.IdPrenda = null;

            //Agregamos la prenda "pren" al contexto, a este se le asignará el Id por defecto.
            prendasContext.Add(pren);
            prendasContext.SaveChanges();

            

            // Guardamos los cambios porque sino al salir del método no se realizarán los cambios.

            if (pren.IdPrenda == null)
                return 0;

            return (int)pren.IdPrenda;
        }

        public static int InsertDetallePenda(DetallesPrendas? detPren)
        {
            if(detPren == null)
              return 0;

            if(detPren.IdPrenda == 0)
            {
                return 0;
            }
            //para que no quiera volver a registrar la Prenda nuevamente
            detPren.Prenda = null;

            prendasContext = new RingoDbContext();
            if (prendasContext.DetallesPrendas == null)
            {
                return 0;
            }

            if(detPren.IdTalle != null)
            {
                detPren.Talle = null;
            }

             detPren.IdDetallePrenda = null;
             prendasContext.Add(detPren);
             prendasContext.SaveChanges();

            if(detPren.IdDetallePrenda == null)
            {
                return 0;
            }

            return (int)detPren.IdDetallePrenda;
        }

        public static int RegistrarEstadoPrenda(EstadosPrendas? estado)
        {
            if (estado == null)
                return 0;
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
                return 0;

            int idEstadoHistoria = RingoDatosEF.RegistrarEstadoHistoriaConIds(estado.EstadosHistorias.IdEstadoActual, null);
                        
            //Ver excepcion
            if (idEstadoHistoria == 0)
                return 0;
            
            estado.IdEstadoHistoria = idEstadoHistoria;
            estado.EstadosHistorias = null;

            prendasContext.Add(estado);
            prendasContext.SaveChanges();

            if (estado.IdEstadosPrendas == null)
                return 0;
            return (int)estado.IdEstadosPrendas;

        }

        public static int InsertEstadoHistoriaGenerico()
        {
            prendasContext = new RingoDbContext();
            if (prendasContext.Estados == null || prendasContext.EstadosHistorias == null)
            {
                return 0;
            }

            int idAlta = prendasContext.Estados.Where(e => e.Indole == "Prendas" && e.Estado == "Apta").Select(e => (int)e.IdEstado).FirstOrDefault();
            EstadosHistorias nuevo = new EstadosHistorias();
            nuevo.IdEstadoActual = idAlta;
            nuevo.FechaCambioEstado = DateTime.Now;
            prendasContext.EstadosHistorias.Add(nuevo);
            prendasContext.SaveChanges();
            if (nuevo.IdEstadoHistoria == null)
            {
                return 0;
            }
            return (int)nuevo.IdEstadoHistoria;
        }

        public static int InsertEstadoPrendaGenerico(EstadosPrendas? estado)
        {
            if (estado == null)
                return 0;
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
                return 0;
            estado.IdEstadoHistoria = InsertEstadoHistoriaGenerico();

            prendasContext.Add(estado);
            prendasContext.SaveChanges();

            if (estado.IdEstadosPrendas == null)
                return 0;
            return (int)estado.IdEstadosPrendas;

        }
        
        //Métodos de anomalías

        public static int updateEstadoHistoria(EstadosHistorias? estado, ref string mensaje)
        { 
            //Reemplaza directamente el estado historia (los cambios los maneja negocio)
            if (estado == null)
            {
                mensaje = "No se envían estado a modificar";
                return 0;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.Estados == null || prendasContext.EstadosHistorias == null)
            {
                mensaje = "Error al conectarse a la BD";
                return 0;
            }

            EstadosHistorias? estadoHistoria = prendasContext.EstadosHistorias.FirstOrDefault(e => e.IdEstadoHistoria == estado.IdEstadoHistoria);
            if (estadoHistoria == null)
            {
                mensaje = "No se encontró el estado a modificar";
                return 0;
            }

            estadoHistoria.IdEstadoActual = estado.IdEstadoActual;
            estadoHistoria.IdEstadoAnterior = estado.IdEstadoAnterior;
            estadoHistoria.FechaCambioEstado = DateTime.Now;
            prendasContext.EstadosHistorias.Update(estadoHistoria);
            int cambios = prendasContext.SaveChanges();
            return cambios;
        }

        public static int updateEstadosPrendas(EstadosPrendas? estadoPrenda, ref string mensaje)
        {
            //Reemplaza directamente el estado prenda (los cambios los maneja negocio)
            if (estadoPrenda == null)
            {
                mensaje = "No se envía estado a modificar";
                return 0;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
            {
                mensaje = "Error al conectarse a la BD";
                return 0;
            }

            EstadosPrendas? estado = prendasContext.EstadosPrendas.FirstOrDefault(e => e.IdEstadosPrendas == estadoPrenda.IdEstadosPrendas);
            if (estado == null)
            {
                mensaje = "No se encontró el estado a modificar";
                return 0;
            }
            estado.IdPrenda = estadoPrenda.IdPrenda;
            estado.IdDetallePrenda = estadoPrenda.IdDetallePrenda;
            estado.IdEstadoHistoria = estadoPrenda.IdEstadoHistoria;
            estado.CantidadEstado = estadoPrenda.CantidadEstado;
            estado.Observaciones = estadoPrenda.Observaciones;

            prendasContext.EstadosPrendas.Update(estado);
            int cambio = prendasContext.SaveChanges();
            return cambio;
        }

        public static bool borrarEstadoPrenda(EstadosPrendas? estado, ref string mensaje)
        {
            if (estado == null)
            {
                mensaje += "\nError al enviar a borrar el estado obsoleto";
                return false;
            }
            if (estado.EstadosHistorias == null)
            {
                mensaje += "\nError al enviar a borrar el estado obsoleto";
                return false;
            }
            prendasContext = new RingoDbContext();
            if (prendasContext.EstadosPrendas == null)
            {
                mensaje += "\nError al conectarse a la base de datos";
                return false;
            }
            int estadosBorrados = 0;
            EstadosPrendas? ep = prendasContext.EstadosPrendas.FirstOrDefault(e => e.IdEstadosPrendas == estado.IdEstadosPrendas);
            if (ep == null)
            {
                mensaje += "\nError al recibir para borrar el estado obsoleto";
                return false;
            }
            try
            {
                prendasContext.EstadosPrendas.Remove(ep);
                estadosBorrados = prendasContext.SaveChanges();
                string mensajeEH = "";
                if (estadosBorrados > 0)
                {
                    estadosBorrados = borrarEstadoHistoria(estado.EstadosHistorias, ref mensajeEH);
                    mensaje += mensajeEH;
                }
            }
            catch (Exception ex)
            {
                mensaje += "\n" + ex.Message;
            }
            return estadosBorrados > 0;
        }

        public static int borrarEstadoHistoria(EstadosHistorias? estado, ref string mensaje)
        {
            //Para eliminar el estado historia (siempre la lógica está en negocio)
            //Reemplaza directamente el estado historia (los cambios los maneja negocio)
            if (estado == null)
            {
                mensaje = "No se envían estado a eliminar";
                return 0;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.Estados == null || prendasContext.EstadosHistorias == null)
            {
                mensaje = "Error al conectarse a la BD";
                return 0;
            }
            int exito = 0;
            EstadosHistorias? estadoHistoria = prendasContext.EstadosHistorias.FirstOrDefault(e => e.IdEstadoHistoria == estado.IdEstadoHistoria);
            if (estadoHistoria == null)
            {
                mensaje = "No se encontró el estado a eliminar";
                return 0;
            }
            try
            {
                prendasContext.EstadosHistorias.Remove(estadoHistoria);
                exito = prendasContext.SaveChanges();
            } catch (Exception ex) {
                mensaje += "\n" + ex.Message;
            }
            return exito;
        }

        public static int updateDetallePrenda(DetallesPrendas? detallePrenda, ref string mensaje)
        {
            //Reemplaza directamente el detalle prenda (los cambios los maneja negocio)
            if (detallePrenda == null)
            {
                mensaje = "No se envía prenda a modificar";
                return 0;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.DetallesPrendas == null)
            {
                mensaje = "Error al conectarse a la BD";
                return 0;
            }

            DetallesPrendas? detalle = prendasContext.DetallesPrendas.FirstOrDefault(d => d.IdDetallePrenda == detallePrenda.IdDetallePrenda);
            if (detalle == null)
            {
                mensaje = "No se encontró la prenda a eliminar";
                return 0;
            }

            detalle.IdPrenda = detallePrenda.IdPrenda;
            detalle.IdTalle = detallePrenda.IdTalle;
            detalle.CantidadPrenda = detallePrenda.CantidadPrenda;
            detalle.CodigoDetalle = detallePrenda.CodigoDetalle;
            detalle.PrecioVenta = detallePrenda.PrecioVenta;
            detalle.CostoPrenda = detallePrenda.CostoPrenda;
            detalle.Color = detallePrenda.Color;

            prendasContext.DetallesPrendas.Update(detalle);
            return prendasContext.SaveChanges();

        }

        public static int updatePrenda(Prendas? prendaNueva, ref string mensaje)
        {
            //Reemplaza directamente la prenda (los cambios los maneja negocio)
            if (prendaNueva == null)
            {
                mensaje = "No se envía prenda genérica a modificar";
                return 0;
            }

            prendasContext = new RingoDbContext();
            if (prendasContext.Prendas == null)
            {
                mensaje = "Error al conectarse a la BD";
                return 0;
            }

            Prendas? prenda = prendasContext.Prendas.FirstOrDefault(p => p.IdPrenda == prendaNueva.IdPrenda);
            if (prenda == null)
            {
                mensaje = "No se encontró la prenda genérica a eliminar";
                return 0;
            }

            prenda.IdCateSubCate = prendaNueva.IdCateSubCate;
            prenda.IdProveedor = prendaNueva.IdProveedor;
            prenda.IdTela = prendaNueva.IdTela;
            prenda.CodigoPrenda = prendaNueva.CodigoPrenda;
            prenda.DescripcionPrenda = prendaNueva.DescripcionPrenda;
            prenda.Cantidad = prendaNueva.Cantidad;
            prenda.Costo = prendaNueva.Costo;
            prenda.PrecioVenta = prendaNueva.PrecioVenta;

            prendasContext.Update(prenda);
            return prendasContext.SaveChanges();
        }
    }
}
