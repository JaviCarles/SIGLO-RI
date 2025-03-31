using Microsoft.IdentityModel.Tokens;
using RingoDatos;
using RingoEntidades;

namespace RingoNegocio
{
    public class LoginUsuario
    {
        public static bool login (Usuarios u) //el método login recibe como parámetro un objeto Usuario. login devuelve un bool.
        {
            // Usuarios user = RingoDatosEF.usuario(u);
            List<UsuariosCredenciales>? user = new();
            u.NombreUsuario = u.NombreUsuario.ToLower();
            user = RingoDatosEF.usuario(u);
            bool usuarioValido = false;
            if (user == null || user.Count == 0)
            {
                Llaves.CredencialesActivas = null;
                Llaves.EmpleadoUsuario = null;
                Llaves.TiempoLogueo = null;
                return false;
            }
            else if (user[0].Usuarios == null || user[0].Usuarios.Personas == null)
            {
                Llaves.CredencialesActivas = null;
                Llaves.EmpleadoUsuario = null;
                Llaves.TiempoLogueo = null;
                return false;
            }
            Empleados? empleado = new();
            empleado = RingoDatosEF.GetEmpleadoPorPersona(user[0].Usuarios.Personas);
            if (empleado == null)
            {
                Llaves.CredencialesActivas = null;
                Llaves.EmpleadoUsuario = null;
                Llaves.TiempoLogueo = null;
                return false;
            }

            Llaves.CredencialesActivas = (from userCred in user select userCred.CodigoCredencial).ToList();
            Llaves.EmpleadoUsuario = empleado;
            Llaves.TiempoLogueo = DateTime.Now;
            Llaves.Empresa = RingoDatosEF.ObtenerEmpresaPorNombre("Ringo Indumentaria");
            Llaves.Sucursal = RingoDatosEF.ObtenerSucursalPorNumero((int)Llaves.Empresa.IdEmpresa, 1);
            Llaves.LibroDiario = registrarLibroDiario();


            //Ver bien
            if (Llaves.LibroDiario == null)
            {
                Llaves.CredencialesActivas = null;
                Llaves.EmpleadoUsuario = null;
                Llaves.TiempoLogueo = null;
                return false;
            }


            return true;
        }

        public static int IdUsuarioActivo()
        {
            if (Llaves.EmpleadoUsuario == null)
                return 0;
            return (int)Llaves.EmpleadoUsuario.IdEmpleado;
        }

        public static List<string>? CredencialesActivas()
        {
            return Llaves.CredencialesActivas;
        }

        public static LibrosDiarios? registrarLibroDiario()
        {
            LibrosDiarios? libro = RingoDatosEF.LibroDiarioHoy();
            
            if (libro != null)
            {
                return libro;
            }
            libro = RingoDatosEF.registrarLibroDiario(Llaves.EmpleadoUsuario);
            return libro;
        }
    }
}