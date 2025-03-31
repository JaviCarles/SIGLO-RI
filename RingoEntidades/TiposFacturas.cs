using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class TiposFacturas
    {
        [Key]
        public int? IdTipoFactura { get; set; }

        [MaxLength(100)]
        public string TipoFactura { get; set; }

        [MaxLength(100)]
        public string? DescripcionTipoFactura { get; set; }
    }
}
