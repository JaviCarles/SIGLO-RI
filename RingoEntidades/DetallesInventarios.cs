using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DetallesInventarios
    {
        [Key]
        public int? IdDetalleInventario { get; set; }

        [ForeignKey("Inventarios")]
        public int IdInventario { get; set; }

        [ForeignKey("Prendas")]
        public int? IdPrenda { get; set; }

        [ForeignKey("DetallesPrendas")]
        public int? IdDetallePrenda { get; set; }

        public int? StockReal { get; set; }

        public int StockTeorico { get; set; }

        public Inventarios? Inventarios { get; set; }

        public Prendas? Prendas { get; set; } 

        public DetallesPrendas? DetallesPrendas { get; set; }

        [NotMapped]
        public int? CantidadPedida
        {
            get
            {
                if (DetallesPrendas !=  null)
                    return DetallesPrendas.CantidadPrenda;
                if (Prendas != null)
                    return Prendas.Cantidad;
                return null;
            }
        }
    }
}
