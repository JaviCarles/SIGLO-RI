using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class EntidadesTarjetas
    {
        [Key]
        public int? IdEntidadTarjeta { get; set; }

        [MaxLength(100)]
        public string EntidadFinanciera { get; set; }
    }
}
