using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesReportes
    {
        [Key]
        public int? IdDetalleReporte { get; set; }

        [ForeignKey("Reportes")]
        public int IdReporte { get; set; }

        [ForeignKey("Ventas")]
        public int? IdVenta { get; set; }

        [ForeignKey("Compras")]
        public int? IdCompra { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [ForeignKey("PedidosClientes")]
        public int? IdPedidoCliente { get; set; }

        [MaxLength(150)]
        public string? Observaciones { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? MontoDetalle { get; set; }

        public Reportes? Reportes { get; set; }

        public Ventas? Ventas { get; set; }

        public Compras? Compras { get; set; }

        public Prendas? Prendas { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }

        public PedidosClientes? PedidosClientes { get; set; }

    }
}
