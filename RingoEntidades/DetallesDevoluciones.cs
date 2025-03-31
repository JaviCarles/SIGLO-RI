using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesDevoluciones
    {
        [Key]
        public int? IdDetalleDevolucion { get; set; }

        [ForeignKey("DevolucionesClientes")]
        public int IdDevolucionCliente { get; set; }

        [ForeignKey("DetallesFacturas")]
        public int IdDetalleFactura { get; set; }

        public int CantidadDevolucion { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal SubTotal { get; set; }

        [MaxLength(150)]
        public string Motivo { get; set; }

        public DevolucionesClientes? DevolucionesClientes { get; set; }

        public DetallesFacturas? DetallesFactura { get; set;}


    }
}
