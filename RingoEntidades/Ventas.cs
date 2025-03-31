using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Ventas
    {
        [Key]
        public int? IdVenta { get; set; }

        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }

        [ForeignKey("Facturas")]
        public int? IdFactura { get; set; }

        [ForeignKey("Empleados")]
        public int IdResponsableVenta { get; set; }

        [ForeignKey("Estados")]
        public int? IdEstado { get; set; }

        public DateTime FechaVenta { get; set; }

        public int? NumeroVenta { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? DescuentoRecargo { get; set; }

        [MaxLength(200)]
        public string? ObservacionesVenta { get; set; }

        public Clientes? Clientes { get; set; }

        public Facturas? Facturas { get; set; }

        public Empleados? Empleados { get; set; }

        public Estados? Estados { get; set; }
    }
}
