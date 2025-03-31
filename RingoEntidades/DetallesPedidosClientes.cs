using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesPedidosClientes
    {
        [Key]
        public int? IdDetallePedidoCliente { get; set; }

        [ForeignKey("PedidosClientes")]
        public int IdPedidoCliente { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [MaxLength(200)]
        public string? DescripcionProducto { get; set; }

        public int CantidadReserva { get; set; }

        public PedidosClientes? PedidosClientes { get; set; }

        public Prendas? Prendas { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }

    }
}
