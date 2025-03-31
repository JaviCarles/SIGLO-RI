using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;

namespace RingoDatos
{
    public class RingoDatosEF // en esta clase es donde nos conectamos a la base de datos
    {
        static RingoDbContext ringoContext;

        public static List<UsuariosCredenciales>? usuario(Usuarios e) // este método debe devolver una lista de Usuario
        {
            ringoContext = new RingoDbContext();
            Usuarios? user = new();
            List<UsuariosCredenciales>? credenciales = new();
            try
            {

                if (ringoContext.UsuariosCredenciales == null) //verificamos si existe la tabla "usuariosCredenciales" (por las dudas)
                {
                    return null; // si no existe la tabla "usuarios", ingresa al if y el método devuelve null.
                }
                //Busco el usuario que coincida
                user = ringoContext.Usuarios.Where(u => u.NombreUsuario == e.NombreUsuario && u.ClaveUsuario == e.ClaveUsuario).FirstOrDefault();
                //Si no hay retorno null
                if (user == null)
                    return null;
                //Si hay busco todas las credenciales de ese usuario
                credenciales = ringoContext.UsuariosCredenciales.Include("Usuarios.Personas").Include("Credenciales").Where(
                                     uc => uc.IdUsuario == (int)user.IdUsuario).ToList();

                //Si no encontró retorno null pues no es un usuario válido
                if (credenciales.Count == 0)
                    return null;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error al buscar usuario en DB");
            }
            //si todo está bien debe retornar la credencial incluyeno a la persona que conecta el usuario
            return credenciales;
        }

        public static Estados? getEstadoPorDescripcion(string descripcion, string indole, ref string mensaje)
        {
            if (string.IsNullOrWhiteSpace(descripcion) || String.IsNullOrWhiteSpace(indole))
            {
                mensaje = "No se envía el estado a buscar";
                return null;
            }
            ringoContext = new RingoDbContext();
            if (ringoContext.Estados == null)
            {
                mensaje = "Error al conectarse a la Base de Datos";
                return null;
            }
            Estados? estadoBuscado = ringoContext.Estados.FirstOrDefault(e => e.Indole == indole && e.Estado == descripcion);
            return estadoBuscado;
        }

        public static Empleados? GetEmpleadoPorPersona(Personas? p)
        {
            if (p == null)
                return null;
            if (p.IdPersona == null)
                return null;
            ringoContext = new RingoDbContext();
            if (ringoContext.Personas == null || ringoContext.Empleados == null)
                return null;

            Empleados? empleado = new();

            empleado = ringoContext.Empleados.Include("Personas").Where(e => e.IdPersona == p.IdPersona).FirstOrDefault();

            return empleado;
        }

        public static List<EstadosHistorias>? EstadosHistoriasPorIndole(string? indole)
        {
            if(indole == null)
                return null;
            ringoContext = new RingoDbContext();
            if(ringoContext.EstadosHistorias == null || ringoContext.Estados == null)
                return null;
            List<int>? idsEstadosIndoles = new();
            idsEstadosIndoles = (from e in ringoContext.Estados where e.Indole == indole select (int)e.IdEstado).ToList();
            if (idsEstadosIndoles.Count == 0 )
                return null;
            List<EstadosHistorias>? estadosHistorias = new();
            estadosHistorias = ringoContext.EstadosHistorias.Include("EstadosActuales").Where(e => idsEstadosIndoles.Contains(e.IdEstadoActual)).ToList();
            if (estadosHistorias.Count == 0)
                return null;
            return estadosHistorias;
        }

        public static Empresas? ObtenerEmpresaPorNombre(string nombreEmpresa)
        {
            using (var context = new RingoDbContext())
            {
                var empresa = context.Empresas
                    .Include(e => e.Domicilios)
                    .Include(e => e.CondicionesFiscales)
                    .FirstOrDefault(e => e.RazonSocial == nombreEmpresa);

                return empresa;
            }
        }

        public static Sucursales? ObtenerSucursalPorNumero(int idEmpresa, int numeroSucursal)
        {
            using (var context = new RingoDbContext())
            {
                var sucursal = context.Sucursales
                    .Include(s => s.Domicilios)
                    .FirstOrDefault(s => s.IdEmpresa == idEmpresa && s.NroSucursal == numeroSucursal);

                return sucursal;
            }
        }


        //Métodos de Estados
        public static List<Estados>? EstadosPorIndole(string? indole)
        {
            if (String.IsNullOrWhiteSpace(indole))
                return null;

            List<Estados>? estados = new();
            try
            {
                ringoContext = new RingoDbContext();
                estados = ringoContext.Estados.Where(e => e.Indole == indole).ToList();
            }
            catch (Exception) { }

            return estados;
        }

        public static int RegistrarEstadoHistoriaConEstados (Estados? estadoNuevo, Estados? estadoAnterior)
        {
            if (estadoNuevo == null)
                return 0;
            ringoContext = new RingoDbContext();
            if (ringoContext.EstadosHistorias == null)
                return 0;
            EstadosHistorias nuevo = new EstadosHistorias();
            nuevo.IdEstadoActual = (int)estadoNuevo.IdEstado;
            nuevo.IdEstadoAnterior = estadoAnterior != null ? estadoAnterior.IdEstado : null;
            nuevo.FechaCambioEstado = DateTime.Now;
            ringoContext.EstadosHistorias.Add(nuevo);
            ringoContext.SaveChanges();
            if (nuevo.IdEstadoHistoria == null)
                return 0;
            return (int)nuevo.IdEstadoHistoria;
        }

        public static int RegistrarEstadoHistoriaConIds(int idEstadoNuevo, int? idEstadoAnterior)
        {
            if (idEstadoNuevo == 0)
                return 0;
            ringoContext = new RingoDbContext();
            if (ringoContext.EstadosHistorias == null)
                return 0;
            EstadosHistorias nuevo = new EstadosHistorias();
            nuevo.IdEstadoActual = idEstadoNuevo;
            nuevo.IdEstadoAnterior = idEstadoAnterior;
            nuevo.FechaCambioEstado = DateTime.Now;
            ringoContext.EstadosHistorias.Add(nuevo);
            ringoContext.SaveChanges();
            if (nuevo.IdEstadoHistoria == null)
                return 0;
            return (int)nuevo.IdEstadoHistoria;
        }

        public static int InsertEstado (Estados e)
        {
            ringoContext = new RingoDbContext();
            if (ringoContext.Estados == null)
                return 0;
            e.IdEstado = null;
            ringoContext.Estados.Add(e);
            ringoContext.SaveChanges();

            if(e.IdEstado == null)
                return 0;
            return (int)e.IdEstado;
        }

        public static LibrosDiarios? LibroDiarioHoy()
        {
            ringoContext = new RingoDbContext();
            if ( ringoContext.LibrosDiarios == null)
            {
                return null;
            }
            LibrosDiarios? libro = ringoContext.LibrosDiarios.Where(l => l.FechaLibroDiario.Date == DateTime.Today).FirstOrDefault();
            if (libro == null)
            {
                return null;
            }
            return libro;
        }

        public static LibrosDiarios? registrarLibroDiario(Empleados e)
        {
            if (e.IdEmpleado == null)
            {
                return null;
            }

            ringoContext = new RingoDbContext();
            if (ringoContext.LibrosDiarios == null)
            {
                return null;
            }

            LibrosDiarios libroNuevo = new LibrosDiarios();
            libroNuevo.IdResponsableContable = e.IdEmpleado;
            libroNuevo.FechaLibroDiario = DateTime.Now;
            libroNuevo.TotalEgresos = 0;
            libroNuevo.TotalIngresos = 0;
            int exito = 0;
            try
            {
                ringoContext.LibrosDiarios.Add(libroNuevo);
                exito = ringoContext.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            if (exito == 0)
            {
                return null;
            }
            if (libroNuevo.IdLibroDiario == null)
            {
                return null;
            }
            return libroNuevo;
        }

    }
}