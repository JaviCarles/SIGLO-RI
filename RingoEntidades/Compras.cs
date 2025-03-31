using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Compras
    {
        [Key]
        public int? IdCompra { get; set; }

        [ForeignKey("PedidosProveedores")]
        public int? IdPedidoProveedor { get; set; }

        [ForeignKey("EstadosHistoria")]
        public int? IdEstadoHistoria { get; set; }

        [ForeignKey("DetallesLibrosDiarios")]
        public int? IdDetalleLibroDiario { get; set; }

        public DateTime FechaCompra { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalCompra { get; set; }

        public PedidosProveedores? PedidosProveedores { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

        public DetallesLibrosDiarios? DetallesLibrosDiarios { get; set; }
    }
}
