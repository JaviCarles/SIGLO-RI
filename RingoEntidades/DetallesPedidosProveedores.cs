using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesPedidosProveedores
    {
        [Key]
        public int? IdDetallePedidoProveedor { get; set; }

        [ForeignKey("PedidosProveedores")]
        public int IdPedidoProveedor { get; set;}

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [MaxLength(100)]
        public string DescripcionPrenda { get; set; }

        public int CantidadPedido { get; set; }

        public PedidosProveedores? PedidosProveedores { get; set; }

        public Prendas? Prendas { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }
    }
}
