using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Provincias
    {
        [Key]
        public int? IdProvincia { get; set; }

        [MaxLength(100)]
        public string NombreProvincia { get; set; }
    }
}
