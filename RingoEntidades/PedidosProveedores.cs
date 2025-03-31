using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class PedidosProveedores
    {
        [Key]
        public int? IdPedidoProveedor { get; set; }

        [ForeignKey("Proveedores")]
        public int? IdProveedor { get; set; }

        [ForeignKey("Empleados")]
        public int? IdEmpleado { get; set; }

        [ForeignKey("EstadosHistorias")]
        public int IdEstadoHistoria { get; set; }

        public DateTime FechaPedido { get; set; }

        public Proveedores? Proveedores { get; set; }

        public Empleados? Empleados { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

        [NotMapped]
        public string? EstadoActual
        {
            get
            {
                if(EstadosHistorias != null)
                    return EstadosHistorias.EstadoActual;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? EstadoAnterior
        {
            get
            {
                if (EstadosHistorias != null)
                    return EstadosHistorias.EstadoAnterior;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Responsable 
        {
            get
            {
                if (Empleados != null)
                    return Empleados.NombreYApellido;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? NombreProveedor
        {
            get
            {
                if(Proveedores != null)
                    return Proveedores.RazonSocial;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? CuitProveedor
        {
            get
            {
                if (Proveedores != null)
                    return Proveedores.Cuit;
                else
                    return null;
            }
        }
    }
}
