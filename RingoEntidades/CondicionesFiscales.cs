using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class CondicionesFiscales
    {
        [Key]
        public int? IdCondicionFiscal { get;  set; }

        [MaxLength(100)]
        public string DetalleFiscal { get; set; }
    }
}
