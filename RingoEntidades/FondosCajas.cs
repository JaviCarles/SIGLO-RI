using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class FondosCajas
    {
        [Key]
        public int? IdFondoCaja { get; set; }

        [ForeignKey("Empleados")]
        public int IdResponsableCaja { get; set; }

        public DateTime FechaFondo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal MontoFondo { get; set; }

        public Empleados? Empleados { get; set; }
    }
}
