using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public static class TransferirDatos
    {
        public static bool VisibilidadContactos { get; set; }

        public static bool VisibilidadDomicilios { get; set; }

        public static List<Contactos>? Contactos { get; set; }

        public static List<Domicilios>? Domicilios { get; set; }
    }
}
