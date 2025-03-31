using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class ProveedoresNegocio
    {
        public static int existe(string? razonSocial, string? cuit, ref string mensaje)
        {
            string rs = razonSocial ?? "";
            if (String.IsNullOrWhiteSpace(rs) && String.IsNullOrWhiteSpace(cuit))
            {
                mensaje = "Ambos campos estan vacíos, ingrese un dato válido";
                return -1;
            }

            Empresas? empresa = new();
            empresa.RazonSocial = rs;
            empresa.Cuit = cuit;

            int idProv = ProveedoresDatosEF.existeProveedor(empresa);
            if (idProv < 0)
            {
                mensaje = "Los datos estan registrados pero no ligados a un proveedor";
                return -1;
            }
            if (idProv > 0)
            {
                mensaje = "El proveedor ya se encuentra registrado en el sistema";
                return idProv;
            }
            return 0;
        }

        public static bool InsertProveedor(Proveedores? prov, List<Contactos>? cont, ref string mensaje)
        {
            if (prov == null || prov.Empresas == null)
            {
                mensaje = "Error, no se enviaron datos de proveedor para registrar";
                return false;
            }
            mensaje = "";
            if (prov.Empresas.Domicilios != null)
            {
                if (prov.Empresas.Domicilios.IdCiudad == null)
                {
                    int idCiudad = 0;
                    if (prov.Empresas.Domicilios.Ciudades != null)
                    {
                        idCiudad = DomiciliosDatosEF.InsertCiudad(prov.Empresas.Domicilios.Ciudades);
                    }
                    if (idCiudad > 0)
                    {
                        mensaje += "\nCiudad nueva registrada";
                        prov.Empresas.Domicilios.IdCiudad = idCiudad;
                        prov.Empresas.Domicilios.Ciudades = null;
                    }
                    
                }
                if (prov.Empresas.Domicilios.IdCiudad == null)
                {
                    prov.Empresas.Domicilios.Barrios = null;
                }
                else if (prov.Empresas.Domicilios.Barrios != null)
                {
                    prov.Empresas.Domicilios.Barrios.IdCiudad = (int)prov.Empresas.Domicilios.IdCiudad;
                    prov.Empresas.Domicilios.Barrios.Ciudades = null;
                }
                if (prov.Empresas.Domicilios.IdBarrio != null)
                {
                    prov.Empresas.Domicilios.Barrios = null;
                }
            }
            int idEmpresa = ProveedoresDatosEF.insertProveedor(prov);
            if (idEmpresa > 0)
            {
                mensaje = InsertContactosProveedor(idEmpresa, cont);
            } else
            {
                mensaje = "Error al registrar al proveedor con las siguientes observaciones" + mensaje;
                return false;
            }

            return true;
        }

        public static string InsertContactosProveedor(int idEmpresa, List<Contactos>? contactos)
        {
            if (contactos == null || contactos.Count == 0)
            {
                return "\nNo se han registrado contacto para este proveedor";
            }
            string mensaje = "";
            int cantidadCorrectos = 0;
            int cantidadIncorrectos = 0;
            foreach (Contactos con in contactos)
            {
                con.IdEmpresa = idEmpresa;
                con.Empresas = null;
                if (con.IdUserRedSocial != null)
                {
                    con.UsersRedesSociales = null;
                }
                if (con.UsersRedesSociales != null)
                {
                    if (con.UsersRedesSociales.IdRedSocial != null)
                    {
                        con.UsersRedesSociales.RedesSociales = null;
                    }
                }
                int idContacto = ContactosDatosEF.insertContactosProveedor(con);
                if (idContacto == 0)
                {
                    cantidadIncorrectos++;
                } else
                {
                    cantidadCorrectos++;
                }
            }

            if (cantidadCorrectos > 0)
            {
                mensaje = $"\nSe registraron correctamente {cantidadCorrectos} contactos";
            }
            if (cantidadIncorrectos > 0)
            {
                mensaje += $"\nHubo problemas para registrar {cantidadIncorrectos} contactos";
            }
            return mensaje;
        }

        //Consulta
        public static Proveedores? GetProveedorPorId(int id)
        {
            if (id < 1)
            {
                return null;
            }
            Proveedores? proveedor = ProveedoresDatosEF.getProveedorPorId(id);
            return proveedor;
        }

        public static Domicilios? DomicilioPorProveedor(Proveedores? prov)
        {
            if (prov == null)
            {
                return null;
            }
            if (prov.Empresas == null)
            {
                return null;
            }
            if (prov.Empresas.IdDomicilio == null)
            {
                return null;
            }
            Domicilios? domicilio = ProveedoresDatosEF.DomicilioPorEmpresa(prov.Empresas);
            if (domicilio == null)
            {
                return null;
            }
            return domicilio;
        }

        public static List<Contactos>? ContactosPorProveedor(Proveedores? prov)
        {
            if (prov == null)
            {
                return null;
            }
            if (prov.Empresas == null)
            {
                return null;
            }
            List<Contactos>? contactos = new();
            contactos = ProveedoresDatosEF.ContactosPorProveedor(prov.Empresas);
            return contactos;
        }

        public static List<Proveedores>? ConsultarProveedores(List<string>? datosProv, List<string>? datosPrenda, bool baja, ref string mensaje)
        {
            List<Proveedores>? proveedores = new();
            if (datosProv == null && datosPrenda == null)
            {
                proveedores = ProveedoresDatosEF.getProveedores(baja);
                string b = baja ? "(Incluidos los que dados de baja)" : "";
                mensaje = $"Se listarán todos los proveedores {b}\n"; 
            } else
            {
                proveedores = ProveedoresDatosEF.getProveedoresFiltrados(datosProv, datosPrenda, baja);
            }
            if (proveedores == null || proveedores.Count == 0)
            {
                mensaje = "No se han encontrado proveedores con los datos proporcionados";
                return null;
            }

            foreach (Proveedores prov  in proveedores)
            {
                Domicilios? d = new();
                d = DomicilioPorProveedor(prov);
                prov.Empresas.Domicilios = d;
            }

            return proveedores;
        }


        //Updates

        public static bool UpdateProveedor(Proveedores? prov, List<Contactos>? viejos, List<Contactos>? nuevos, ref string mensaje)
        {
            if (prov == null)
            {
                mensaje = "No se pudo actualizar: No se cargó desde el formulario";
                return false;
            }
            if (prov.IdProveedor == null)
            {
                mensaje = "No se pudo actualizar: No se cargó el ID desde el formulario";
                return false;
            }
            if (prov.Empresas == null)
            {
                mensaje = "No se pudo actualizar: No se cargó la empresa desde el formulario";
                return false;
            }
            if (prov.Empresas.IdEmpresa == null)
            {
                mensaje = "No se pudo actualizar: No se cargó el ID de la empresa desde el formulario";
                return false;
            }

            Domicilios? d = prov.Empresas.Domicilios;
            int empresaModificada = ProveedoresDatosEF.updateEmpresa(prov.Empresas);
            int provModificado = ProveedoresDatosEF.updateProveedor(prov);
            if (provModificado > 0)
            {
                mensaje += "\nDatos de proveedor modificados exitosamente";
            }
            if (empresaModificada > 0)
            {
                mensaje += "\nDatos de empresa modificados exitosamente";
            }

            if (empresaModificada + provModificado == 0)
            {
                mensaje += "\nNo se modificaron datos de proveedor ni empresa";
            }

            if (d == null)
            {
                mensaje += "\nNo se registra ni modifica domicilio";
            } else if (d.IdDomicilio == null) {
                int idDom = DomiciliosDatosEF.InsertDomicilio(d);
                if (idDom > 0)
                {
                    mensaje += "\nDomicilio registrado exitosamente";
                    prov.Empresas.IdDomicilio = idDom;
                } else
                {
                    mensaje += "\nError al registrar un domicilio";
                    prov.Empresas.IdDomicilio = null;
                }
                prov.Empresas.Domicilios = null;
                d = prov.Empresas.Domicilios;

            } else
            {
                if (DomiciliosDatosEF.UpdateDomicilio(d))
                {
                    mensaje += "\nEl domicilio se guardó correctamente";
                }
                else
                {
                    mensaje += "\nNo se modifica el domicilio";
                }
            }
            
            List<Contactos>? eliminar = new();
            int cantidadNuevos = nuevos == null ? 0 : nuevos.Count;
            if (viejos.Count > 0 && nuevos.Count > 0)
            {
                eliminar = viejos.Where(d => !nuevos.Any(c => c.IdContacto != null && c.IdContacto == d.IdContacto)).ToList();
            }

            if (eliminar.Count > 0)
            {
                int eliminados = ContactosDatosEF.EliminarContactos(eliminar);
                if (eliminados > 0)
                {
                    mensaje += $"\nSe eliminaron {eliminados} contactos";
                } else
                {
                    mensaje += $"\nNo se pudieron eliminar los contactos antiguos";
                }
            }

            if (cantidadNuevos > 0)
            {
                int exitos = 0;
                int fallidos = 0;
                for (int i = 0; i < nuevos.Count; i++)
                {
                    if (ContactosDatosEF.UpdateContacto(nuevos[i]))
                    {
                        exitos++;
                    } else
                    {
                        fallidos++;
                    }
                }
                if (exitos > 0)
                {
                    mensaje += $"\nSe guardaron exitosamente {exitos} contactos";
                }
                if (fallidos > 0)
                {
                    mensaje += $"\nHubo problemas al guardar {fallidos} contactos";
                }
            }
            
            return true;
            
        }
    }
}
