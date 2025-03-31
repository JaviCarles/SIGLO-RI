using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    internal static class Llaves
    {
        public static List<string>? CredencialesActivas { get; set; }

        public static Empleados? EmpleadoUsuario { get; set; }

        public static DateTime? TiempoLogueo { get; set; }

        public static Empresas? Empresa { get; set; }

        public static Sucursales? Sucursal { get; set; }

        public static LibrosDiarios? LibroDiario { get; set; }
    }
}
