using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Credenciales
    {
        [Key]
        public int? IdCredencial { get; set; }

        [MaxLength(100)]
        public string TipoCredencial { get; set; }
        
        [MaxLength(20)]
        public string CodigoCredencial { get; set; }

        [MaxLength(150)]
        public string? PermisosOtorgados { get; set; }
    }
}
