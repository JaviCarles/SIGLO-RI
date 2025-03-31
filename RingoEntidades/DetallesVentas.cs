using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesVentas
    {
        [Key]
        public int? IdDetalleVenta { get; set; }

        [ForeignKey("Ventas")]
        public int IdVenta { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [MaxLength(200)]
        public string? DescripcionProducto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? SubTotal { get; set; }

        public Ventas? Ventas { get; set; }
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

        [NotMapped]
        public string? Codigos
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.CodigoDetalle;
                return null;
            }
            set
            {
                _codigos = value;
            }
        }
        private string? _codigos;

        [NotMapped]
        public string? DescripcionPrenda
        {
            get
            {
                if (Prendas != null)
                    return Prendas.DescripcionPrenda;
                return null;
            }
        }

        [NotMapped]
        public decimal? PrecioVenta
        {
            get
            {
                if (SubTotal != null)
                    return SubTotal / Cantidad;
                return _precioVenta;
            }
            set
            {
                _precioVenta = value;
            }
        }
        private decimal? _precioVenta;

        [NotMapped]
        public string? Tela
        {
            get
            {
                if (Prendas != null)
                    return Prendas.TelaPrenda;
                return null;
            }
        }

        [NotMapped]
        public string? DescripcionTalle
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.DescripcionTalle;
                return null;
            }
        }

        [NotMapped]
        public string? NroTalle
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.NroTalle;
                return null;
            }
        }

        [NotMapped]
        public string? Color
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.Color;
                return null;
            }
        }
    }
}
