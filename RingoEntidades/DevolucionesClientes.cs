using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DevolucionesClientes
    {
        [Key]
        public int? IdDevolucionCliente { get; set; }

        [ForeignKey("Facturas")]
        public int? IdFactura { get; set; }

        public DateTime FechaDevolucionCliente { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal MontoTotalDevolucion { get; set; }

        public Facturas? Facturas { get; set; }
    }
}
