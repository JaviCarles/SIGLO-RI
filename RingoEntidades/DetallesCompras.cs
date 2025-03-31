using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesCompras
    {
        [Key]
        public int? IdDetalleCompra { get; set; }

        [ForeignKey("Compras")]
        public int IdCompra { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        public int CantidadComprada { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Monto { get; set; }

        [MaxLength(100)]
        public string? DescripcionCurva { get; set; }

        public Compras? Compras { get; set; }

        public Prendas? Prendas { get; set; }

        public DetallesPrendas? DetallesPrendas { get; set; }



    }
}
