using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Puestos
    {
        [Key]
        public int? IdPuesto { get; set; }

        [MaxLength(50)]
        public string Puesto { get; set; }

        [MaxLength(150)]
        public string? DescripcionPuesto { get; set; }
    }
}
