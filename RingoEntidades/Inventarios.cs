using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Inventarios
    {
        [Key]
        public int? IdInventario { get; set; }

        [ForeignKey("Empleados")]
        public int? IdEmpleado { get; set; }

        [ForeignKey("EstadosHistorias")]
        public int? IdEstadoHistoria { get; set; }

        public DateTime? FechaInventario { get; set; }

        public DateTime? FechaCierreInventario { get; set; }

        public Empleados? Empleados { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

    }
}
