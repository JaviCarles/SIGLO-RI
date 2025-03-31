using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RingoDatos
{
    public class PersonasDatosEF
    {
        public static RingoDbContext RingoContext = new RingoDbContext();
        //Consultas
        public static Personas? PersonaSola(Personas p)
        {
            RingoContext = new RingoDbContext();
            Personas? persona = new Personas();
            if (RingoContext == null || RingoContext.Personas == null || p.IdPersona == null || p.IdPersona == 0)
                return persona;
            persona = RingoContext.Personas.Where(P => P.IdPersona == p.IdPersona).FirstOrDefault();
            return persona;
        }

        public static Personas? PersonaPorDni(string dni)
        {
            if (String.IsNullOrEmpty(dni))
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null)
                return null;
            Personas? persona = new();
            persona = RingoContext.Personas.FirstOrDefault(p => p.Dni == dni);
            if (persona == null)
                return null;
            return persona;
        }

        public static List<Personas>? PersonasPorDni(Personas? per, bool baja, bool observaciones)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null)
                return null;
            if (RingoContext.Personas == null || String.IsNullOrWhiteSpace(per.Dni))
                return null;
            //el booleano me dice si la busqueda incluye a los estados Baja
            //Así que transformo para facilitar la búsqueda
            int e = 0;
            int o = 0;
            if (!baja)
            {
                e = EstadosId("Baja", RingoContext);
            }
            if (!observaciones)
            {
                o = EstadosId("Con Observaciones", RingoContext);
            }
            List<Personas> personas = new();
            List<int>? clientes = IdPersonasClientes(RingoContext);
            if (clientes == null || clientes.Count == 0)
                return null;
            personas = RingoContext.Personas.Include("Estados").Include("CondicionesFiscales").Where(p =>
                       clientes.Contains((int)p.IdPersona) &&
                       p.IdPersona != null && p.IdEstado != e && p.IdEstado != o&&
                       p.Dni != null && p.Dni.Contains(per.Dni)).ToList();
            return personas;
        }

        static List<int>? IdPersonasClientes(RingoDbContext Context)
        {
            if (Context.Clientes == null)
                return null;
            List<int>? IdPersonas = new();
            IdPersonas = (from c in Context.Clientes select c.IdPersona).ToList();
            return IdPersonas;
        }

        static List<int>? IdPersonasCiudad (RingoDbContext Context, int idCiudad)
        {
            if (Context.Domicilios == null)
                return null;
            List<int>? Ids = new();
            Ids = (from d in Context.Domicilios
                   where d.IdCiudad != null &&
                   d.IdPersona != null && d.IdCiudad.Equals(idCiudad)
                   select (int)d.IdPersona).ToList();
            return Ids;
        }

        public static int EstadosId(string baja, RingoDbContext RingoContext)
        {
            int? id = 0;
            if (String.IsNullOrWhiteSpace(baja))
                return 0;
            if (RingoContext.Estados == null)
                return 0;
            id = (from e in RingoContext.Estados
                  where e.IdEstado != null && e.Indole == "Personas"
                  && e.Estado == baja
                  select e.IdEstado).FirstOrDefault();
            if (id == null)
                return 0;
            else
                return (int)id;
        }

        public static bool EsEmpleado(Personas? p)
        {
            if (p == null)
                return false;
            RingoContext = new RingoDbContext();
            if (RingoContext.Empleados == null || RingoContext.Personas == null)
                return false;
            Empleados? empleado = RingoContext.Empleados.FirstOrDefault(e => e.IdPersona == p.IdPersona);
            return empleado != null;

        }

        public static List<Personas>? PersonasSinCiudad(Personas per, bool baja, bool observaciones)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null || RingoContext.Personas == null)
                return null;
            int e = 0;
            int o = 0;
            if (!baja)
            {
                e = EstadosId("Baja", RingoContext);
            }
            if (!observaciones)
            {
                o = EstadosId("Con Observaciones", RingoContext);
            };
            List<Personas> personas = new();
            List<int>? clientes = IdPersonasClientes(RingoContext);
            if (clientes == null || clientes.Count == 0)
                return null;
            if (!String.IsNullOrEmpty(per.Nombre))
            {
                int espacio = per.Nombre.IndexOf(" ");
                if (espacio > -1)
                {
                    string sub1 = per.Nombre.Substring(0, espacio);
                    string sub2 = per.Nombre.Substring(++espacio);
                    per.Nombre = sub1;
                    per.Apellidos = sub2;
                }
            }
            personas = RingoContext.Personas.Include("Estados").Include("CondicionesFiscales").Where(p =>
                       p.IdPersona != null && p.IdEstado != e && p.IdEstado != o && clientes.Contains((int)p.IdPersona) &&
                       p.Dni.Contains(per.Dni) &&
                       (p.Nombre.Contains(per.Nombre) || p.Apellidos.Contains(per.Apellidos)
                       || p.Nombre.Contains(per.Apellidos) || p.Apellidos.Contains(per.Nombre))
                       ).OrderBy(p => p.Apellidos).OrderBy(p => p.Nombre).ToList();
            return personas;
        }

        public static List<Personas>? PersonasCompleto(string apellido, string nombre, string dni, bool baja, int Ciudad, bool observaciones, ref string mensaje)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null || RingoContext.Estados == null || RingoContext.Domicilios == null || RingoContext.Clientes == null)
            {
                mensaje += "No se puede acceder a la base de datos";
                return null;
            }

            List<Personas>? personas = GetAllPersonas(baja, observaciones);
            if (personas == null || personas.Count == 0)
            {
                mensaje += "No se encontró ningún cliente en el registro";
                return null;
            }
            
            List<int>? idsConCiudad = new();

            if (Ciudad > 0)
            {
                idsConCiudad = IdPersonasCiudad(RingoContext, Ciudad);
                if (idsConCiudad == null || idsConCiudad.Count == 0)
                {
                    mensaje = "No hay clientes con domicilios en la localidad seleccionada";
                    return null;
                }
                else
                {
                    personas = personas.Where(p => idsConCiudad.Contains((int)p.IdPersona)).ToList();
                }
            }

            if (!string.IsNullOrEmpty(dni))
            {
                personas = personas.Where(p => p.Dni.Contains(dni)).ToList();
            }
            if (!string.IsNullOrEmpty(nombre))
            {
                personas = personas.Where(p => p.Nombre.Contains(nombre) || p.Apellidos.Contains(nombre)).ToList();
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                personas = personas.Where(p => p.Nombre.Contains(apellido) || p.Apellidos.Contains(apellido)).ToList();
            }

            


            return personas;
        }

        public static List<Personas>? GetAllPersonas(bool baja, bool observaciones)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null || RingoContext.Personas == null)
                return null;
            int e = 0;
            int o = 0;
            if (!baja)
            {
                e = EstadosId("Baja", RingoContext);
            }
            if (!observaciones)
            {
                o = EstadosId("Con Observaciones", RingoContext);
            }
            List<Personas>? personas = new();
            List<int>? clientes = IdPersonasClientes(RingoContext);
            if (clientes == null || clientes.Count == 0)
                return null;
            personas = RingoContext.Personas.Include("Estados").Include("CondicionesFiscales").Where(p => 
                       p.IdPersona != null && p.IdEstado != e && p.IdEstado != o && clientes.Contains((int)p.IdPersona)
                       ).OrderBy(p => p.Apellidos).OrderBy(p => p.Nombre).ToList();
            return personas;
        }

        public static List<Personas>? PersonasPorCiudad(bool baja, int idCiudad, bool observaciones)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null || RingoContext.Domicilios == null || idCiudad == 0)
                return null;
            int e = 0;
            int o = 0;
            if (!baja)
            {
                e = EstadosId("Baja", RingoContext);
            }
            if (!observaciones)
            {
                o = EstadosId("Con Observaciones", RingoContext);
            }

            List<int>? idsConCiudad = IdPersonasCiudad(RingoContext, idCiudad);
            if (idsConCiudad == null || idsConCiudad.Count == 0)
                return null;
            List<int>? clientes = IdPersonasClientes(RingoContext);
            List<Personas>? personas = new();
            if (clientes == null || clientes.Count == 0)
                return null;
            personas = RingoContext.Personas.Include("Estados").Include("CondicionesFiscales").Where(p =>
                            clientes.Contains((int)p.IdPersona) && idsConCiudad.Contains((int)p.IdPersona)
                            && p.IdEstado != e && p.IdEstado != o).OrderBy(p => p.Apellidos).OrderBy(p => p.Nombre).ToList();
            return personas;
        }

        public static Clientes? BuscarCliente(Personas p)
        {
            if (p == null)
                return null;
            //trae a un cliente a partir de una persona
            Clientes? cliente = new();
            try
            {
                RingoContext = new RingoDbContext();
                cliente = RingoContext.Clientes.Where(c => c.IdPersona == p.IdPersona).FirstOrDefault();
            }
            catch (Exception) { }

            return cliente;
        }

        public static List<int>? GetIdsClientesPorTexto(string txtBuscado)
        {
            if (txtBuscado == null)
                return null;
            Personas? persona = new();
            string txtConsulta = txtBuscado ?? "";
            persona.Dni = txtConsulta;
            persona.Apellidos = txtConsulta;
            persona.Nombre = txtConsulta;
            List<Personas>? personas = PersonasDatosEF.PersonasSinCiudad(persona, true, true);
            if (personas == null)
                return null;
            List<int>? idsPersonas = personas.Select(p => (int)p.IdPersona).ToList();
            if (idsPersonas == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Clientes == null)
                return null;
            List<int>? idsClientes = RingoContext.Clientes.Where(c => idsPersonas.Contains(c.IdPersona)).Select(cl => (int)cl.IdCliente).ToList();
            if (idsClientes == null || idsClientes.Count == 0)
                return null;
            return idsClientes;
        }

        public static List<CondicionesFiscales>? CondicionesFiscales()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null || RingoContext.CondicionesFiscales == null)
                return null;
            List<CondicionesFiscales>? condicionesFiscales = new();
            
            condicionesFiscales = RingoContext.CondicionesFiscales.ToList();
            return condicionesFiscales;
        }

        public static Estados? EstadoPorPersona(Personas p)
        {
            if(p == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null || RingoContext.Estados == null)
                return null;
            Estados? estado = new();
            estado = (from E in RingoContext.Estados
                      join P in RingoContext.Personas on E.IdEstado equals P.IdEstado
                      select E).FirstOrDefault();
            return estado;
        }

        //Inserts
        public static int InsertarPersona(Personas? p)
        {
            if (p == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext == null)
                return 0;
            if (RingoContext.Personas == null)
                return 0;
            int resultado = 0;
            List<Personas>? consulta = PersonasPorDni(p, true, true);
            if (consulta == null || consulta.Count == 0)
            {
                RingoContext.Personas.Add(p);
                RingoContext.SaveChanges();
                resultado = (int)p.IdPersona;
            }
            else
                resultado = -1;
            return resultado;
        }
        
        public static int InsertarCondicionFiscal(CondicionesFiscales? c)
        {
            if (c == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext == null)
                return 0;
            if (RingoContext.CondicionesFiscales == null)
                return 0;

            int resultado = 0;
            c.IdCondicionFiscal = null;
            RingoContext.CondicionesFiscales.Add(c);
            RingoContext.SaveChanges();
            resultado = (int)c.IdCondicionFiscal;
            return resultado;
        }

        public static int InsertarCliente(Clientes? c)
        {
            if (c == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext == null || RingoContext.Clientes == null)
                return 0;
            
            int resultado = 0;
            c.IdCliente = null;
            RingoContext.Clientes.Add(c);
            RingoContext.SaveChanges();
            resultado = (int)c.IdCliente;
            return resultado;
        }

        //Modificacion
        public static bool UpdatePersona(Personas p)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null)
                return false;
            var persona = RingoContext.Personas.FirstOrDefault(per => per.IdPersona == p.IdPersona);
            if (persona == null)
                return false;
            persona.Dni = p.Dni;
            persona.Apellidos = p.Apellidos;
            persona.Nombre = p.Nombre;
            persona.Observaciones = p.Observaciones;
            persona.IdEstado = p.IdEstado;
            persona.IdCondicionFiscal = p.IdCondicionFiscal;
            RingoContext.SaveChanges();
            return true;

        }
        //Eliminar
        public static bool DeletePersona(Personas p)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null)
                return false;
            var persona = RingoContext.Personas.FirstOrDefault(per => per.IdPersona == p.IdPersona);
            if (persona == null)
                return false;
            RingoContext.Personas.Remove(persona);
            RingoContext.SaveChanges();
            return RingoContext.Personas.SingleOrDefault(per => per.IdPersona == p.IdPersona) == null;
        }

        public static bool DeleteCliente(Clientes c)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Clientes == null)
                return false;
            var cliente = RingoContext.Clientes.FirstOrDefault(cli => cli.IdCliente == c.IdCliente);
            if (cliente == null)
                return false;
            RingoContext.Clientes.Remove(cliente);
            RingoContext.SaveChanges();
            return RingoContext.Clientes.SingleOrDefault(cli => cli.IdCliente == c.IdCliente) == null;
        }
    }
}
