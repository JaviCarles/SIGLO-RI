using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Talles
    {
        [Key]
        public int? IdTalle { get; set; }

        [MaxLength(150)]
        public string? DescripcionTalle { get; set; }

        [MaxLength(20)]
        public string? NroTalle { get; set; }
    }
}
