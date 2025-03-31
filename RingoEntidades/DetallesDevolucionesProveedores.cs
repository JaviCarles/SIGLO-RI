using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesDevolucionesProveedores
    {
        [Key]
        public int? IdDetalleDevolProv { get; set; }

        [ForeignKey("DevolucionesProveedores")]
        public int IdDevolucionProveedor { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        [MaxLength(100)]
        public string? MotivoDevolucion { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? SubTotal { get; set; }

        public int CantidadDevolProv { get; set; }

        public DevolucionesProveedores? DevolucionesProveedores { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }

    }
}
