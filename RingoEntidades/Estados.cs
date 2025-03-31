using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Estados
    {
        [Key]
        public int? IdEstado { get; set; }

        [MaxLength(50)]
        public string Indole { get; set;}

        [MaxLength(50)]
        public string Estado { get; set; }
    }
}
