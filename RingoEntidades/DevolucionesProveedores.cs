using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class DevolucionesProveedores
    {
        [Key]
        public int? IdDevolucionProveedor { get; set; }

        [ForeignKey("Compras")]
        public int? IdCompra { get; set; }

        [ForeignKey("Empleados")]
        public int IdResponsableMercaderias { get; set; }

        [ForeignKey("EstadosHistorias")]
        public int IdEstadoHistoria { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public Compras? Compras { get; set; }

        public Empleados? Empleados { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

    }
}
