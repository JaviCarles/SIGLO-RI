using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class EstadosPrendas
    {
        [Key]
        public int? IdEstadosPrendas { get; set; }

        [ForeignKey("EstadosHistorias")]
        public int IdEstadoHistoria { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [ForeignKey("Prendas")]
        public int IdPrenda { get; set; }

        public int CantidadEstado { get; set; }

        [MaxLength(150)]
        public string? Observaciones { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }

        public Prendas? Prendas { get; set; }

        [NotMapped]
        public string? CodigoDetalle
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.CodigoDetalle;
                return null;
            }
            set
            {
                _codigoDetalle = value;
            }
        }
        private string? _codigoDetalle;


        [NotMapped]
        public string? Color
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.Color;
                return null;
            }
            set
            {
                _color = value;
            }
        }
        private string? _color;

        [NotMapped]
        public string? NroTalle
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.NroTalle;
                return null;
            } 
            set
            {
                _nroTalle = value;
            }
        }
        private string? _nroTalle;


        [NotMapped]
        public string? DescripcionTalle
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.DescripcionTalle;
                return null;
            } set
            {
                _descripcionTalle = value;
            }
        }
        private string? _descripcionTalle;

        [NotMapped]
        public decimal? PrecioVenta
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.PrecioVenta;
                return null;
            } set
            {
                _precioVenta = value;
            }
        }
        private decimal? _precioVenta;

        [NotMapped]
        public decimal? Costo
        {
            get
            {
                if (DetallesPrendas != null)
                    return DetallesPrendas.CostoPrenda;
                return null;
            } set
            {
                _costo = value;
            }
        }
        private decimal? _costo;

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
        public string? EstadoActual
        {
            get
            {
                if (EstadosHistorias != null)
                    return EstadosHistorias.EstadoActual;
                return null;
            } 
            set 
            { 
                _estadoActual = value;
            }
        }
        private string? _estadoActual;

        [NotMapped]
        public int? DiferenciaStock
        {
            get
            {
                if (DetallesPrendas != null)
                    return CantidadEstado - DetallesPrendas.CantidadPrenda;
                return null;
            }
        }
    }
}
