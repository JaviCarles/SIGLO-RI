using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Telas
    {
        [Key]
        public int? IdTela { get; set; }

        [MaxLength(50)]
        public string Tela { get; set; }
    }
}
