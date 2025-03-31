using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class TarjetasEntidades
    {
        [Key]
        public int? IdTarjetaEntidad { get; set; }

        [ForeignKey("Tarjetas")]
        public int IdTarjeta { get; set; }

        [ForeignKey("EntidadesTarjetas")]
        public int IdEntidadTarjeta { get; set; }

        public Tarjetas? Tarjetas { get; set; }

        public EntidadesTarjetas? EntidadesTarjetas { get; set; }

        [NotMapped]
        public string? Tarjeta
        {
            get
            {
                if (Tarjetas != null)
                    return Tarjetas.Tarjeta;
                return null;
            }
        }

        [NotMapped]
        public string? Entidad
        {
            get
            {
                if (EntidadesTarjetas != null)
                    return EntidadesTarjetas.EntidadFinanciera;
                return null;
            }
        }
    }
}
