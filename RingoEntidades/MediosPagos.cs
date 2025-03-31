using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class MediosPagos
    {
        [Key]
        public int? IdMedioPago { get; set; }

        [MaxLength(100)]
        public string FormaPago { get; set; }

    }
}
