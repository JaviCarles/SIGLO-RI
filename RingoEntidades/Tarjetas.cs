using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Tarjetas
    {
        [Key]
        public int? IdTarjeta { get; set; }

        [MaxLength(50)]
        public string Tarjeta { get; set; }
    }
}
