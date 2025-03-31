using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class MovimientoFinanzasDiario
    {
        public decimal TotalIngreso { get; set; }
        public decimal TotalEgreso { get; set; }
        public decimal TotalMargen {  get; set; }
        public DateTime Fecha { get; set; }
    }
}
