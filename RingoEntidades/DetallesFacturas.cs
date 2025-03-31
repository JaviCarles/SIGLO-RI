using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesFacturas
    {
        [Key]
        public int? IdDetalleFactura { get; set; }

        [ForeignKey("Facturas")]
        public int IdFactura { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [MaxLength(200)]
        public string? DescripcionProducto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? SubTotal { get; set; }

        public Facturas? Facturas { get; set; }

        public Prendas? Prendas { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }

        [NotMapped]
        public decimal? PrecioUnitario
        {
            get
            {
                if (SubTotal != null && Cantidad > 0)
                {
                    return SubTotal / Cantidad;
                }
                return null;
            }
            set
            {
                _precioUnitario = value;
            }
        }
        private decimal? _precioUnitario;
    }
}
