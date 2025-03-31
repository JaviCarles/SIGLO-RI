using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class PersonasMetodos
    {
        //Consulta
        public static List<Estados>? EstadosPorIndole (string indole)
        {
            if (indole == null)
                return null;
            List<Estados>? estados = new();
            estados = RingoDatosEF.EstadosPorIndole(indole);
            return estados;
        }

        public static Personas? PersonaPorDni (string dni)
        {
            Personas? persona = new();
            persona = PersonasDatosEF.PersonaPorDni(dni);
            return persona;
        }

        public static Estados? EstadoPorPersona (Personas? p)
        {
            if (p == null)
                return null;
            Estados? estado = new();
            estado = PersonasDatosEF.EstadoPorPersona(p);
            return estado;
        }

        public static Personas? PersonaSola (Personas p)
        {
            Personas? persona = new();
            persona = PersonasDatosEF.PersonaSola(p);
            return persona;
        }

        public static Clientes? BuscarClientes(Personas p)
        {
            Clientes? clientes = new();
            if (p == null)
                return clientes;
            clientes = PersonasDatosEF.BuscarCliente(p);
            return clientes;
        }
        public static List<Personas>? PersonaPorCiudad(int idCiudad, bool baja, bool observaciones)
        {
            List<Personas>? personas = new();
            personas = PersonasDatosEF.PersonasPorCiudad(baja, idCiudad, observaciones);
            return personas;
        }

        public static List<Personas>? PersonaPorDni (Personas p, bool baja, bool observaciones)
        {
            List<Personas>? personas = new();
            personas = PersonasDatosEF.PersonasPorDni(p, baja, observaciones);
            return personas;
        }

        public static List<Personas>? PersonasTodas(bool baja, bool observaciones)
        {
            //Busca todas las personas registradas con el estado Baja o no segun el booleano baja
            List<Personas>? personas = new();
            personas = PersonasDatosEF.GetAllPersonas(baja, observaciones);
            return personas;
        }

        public static List<Personas>? PersonasCompleto(Personas p, bool baja, int idCiudad, bool observaciones, ref string mensaje)
        {
            //Creo la lista de personas
            List<Personas>? personas = new();

            //Creo variables para facilitar la busqueda y el entendimiento de la misma
            string nombre = "";
            string apellido = "";
            string dni = "";

            //Las cargo con lo que llega
            if (p != null)
            {
                nombre = p.Nombre;
                apellido = p.Apellidos;
                dni = p.Dni;
            }

            //Creo un contador que si llega a cero es porque no se envían datos y buscará todos los clientes
            int conDatos = 3;
            conDatos -= String.IsNullOrWhiteSpace(dni) ? 1 : 0;
            conDatos -= String.IsNullOrWhiteSpace(nombre) ? 1 : 0;
            conDatos -= idCiudad > 0 ? 0 : 1;

            if (conDatos > 0)
            {
                personas = PersonasDatosEF.PersonasCompleto(apellido, nombre, dni, baja, idCiudad, observaciones, ref mensaje);
            } else
            {
                personas = PersonasDatosEF.GetAllPersonas(baja, observaciones);
                mensaje += personas != null ? "Sin datos de consulta se trajeron todos los clientes del registro\n" : "";
            }

            return personas;
        }

        public static List<Personas>? PersonasSinCiudad(Personas p, bool baja, bool observaciones)
        {
            List<Personas>? personas = new();
            personas = PersonasDatosEF.PersonasSinCiudad(p, baja, observaciones);
            return personas;
        }

        public static List<CondicionesFiscales>? ConsultarCondicionesFiscales ()
        {
            List<CondicionesFiscales>? condicionesFiscales = new();
            condicionesFiscales = PersonasDatosEF.CondicionesFiscales();
            return condicionesFiscales;
        }

        public static Estados? GetEstadoPorNombre (string? estado)
        {
            if (String.IsNullOrWhiteSpace(estado))
                return null;
            List<Estados>? estados = new();
            Estados? es = null;
            estados = RingoDatosEF.EstadosPorIndole("Personas");
            if (estados != null && estados.Count > 0)
            {
                es = estados.FirstOrDefault(e => e.Estado == estado);
            }
            return es;
        }

        //Inserts
        public static int InsertarCondFiscal (CondicionesFiscales? c)
        {
            int condicion = 0;
            condicion = PersonasDatosEF.InsertarCondicionFiscal(c);
            return condicion;
        }

        public static int InsertarPersona (Personas p)
        {
            int resultado = 0;
            resultado = PersonasDatosEF.InsertarPersona(p);
            return resultado;
        }

        public static int InsertarCliente (Clientes c)
        {
            int resultado = 0;
            resultado = PersonasDatosEF.InsertarCliente(c);
            return resultado;
        }

        //Modificacion
        public static bool UpdatePersona ( Personas? p)
        {
            if (p == null)
                return false;
            return PersonasDatosEF.UpdatePersona(p);
            
        }

        //Eliminar
        public static bool DeletePersona (Personas? p, ref string mensaje)
        {
            if (p == null)
                return false;
            if (PersonasDatosEF.EsEmpleado(p))
            {
                mensaje += "\nNo se puede eliminar como persona porque es un Empleado de la tienda. Consulte al Administrador del sistema!";
                return false;
            }
            List<Domicilios>? domiciliosPersona = DomiciliosDatosEF.DomiciliosPorPersona(p);
            List<Contactos>? contactosPersona = ContactosDatosEF.ContactosPorPersona(p);
            int domEliminados = 0;
            int conEliminados = 0;
            if (domiciliosPersona != null)
            {
                domEliminados = DomiciliosDatosEF.EliminarDomicilios(domiciliosPersona);
                if (domEliminados > 0)
                    mensaje += $"\nSe eliminaron {domEliminados} domicilios relacionados a la persona";
            }
            if (contactosPersona != null)
            {
                conEliminados = ContactosDatosEF.EliminarContactos(contactosPersona);
                if (conEliminados > 0)
                    mensaje += $"\nSe eliminaron {conEliminados} domicilios relacionados a la persona";
            }
            return PersonasDatosEF.DeletePersona(p);
        }

        public static string DeleteCliente (Clientes? c)
        {
            string mensaje = $"El cliente {c.Nombres}, dni: {c.DNI} \nFué removido exitosamente de la base de datos";
            if (c == null)
                return "Error al eliminar. No se seleccionó ningún cliente";
            if (c.Personas == null)
                return "Error al eliminar. No se seleccionó ningún cliente";
            if (!PersonasDatosEF.DeleteCliente(c))
                return "Error al eliminar. No se pudo remover el cliente de la base de datos";
            string mensajePersona = "";
            if (!DeletePersona(c.Personas, ref mensajePersona))
            {
                return "Error al eliminar. No se pudo remover el cliente de la base de datos" + mensajePersona;
            }
            return mensaje + mensajePersona;
        }
    }
}
