using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class EstadosNC
    {
        [Key]
        public int? IdEstadoNC { get; set; }

        [ForeignKey("Estados")]
        public int IdEstado { get; set; }

        public DateTime FechaEstadoNC { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal MontoUtilizado { get; set; }

        public Estados? Estados { get; set; }
    }
}
