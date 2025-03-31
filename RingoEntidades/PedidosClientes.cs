using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class PedidosClientes
    {
        [Key]
        public int? IdPedidoCliente { get; set; }

        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }

        [ForeignKey("EstadosHistorias")]
        public int IdEstadoHistoria { get; set; }

        public DateTime FechaPedidoCliente { get; set; }

        public Clientes? Clientes { get; set; }

        public EstadosHistorias? EstadosHistorias { get; set; }

        [NotMapped]
        public string? NombreCliente
        {
            get
            {
                if (Clientes != null)
                    return Clientes.Apellido+" "+Clientes.Nombres;
                return null;
            }
        }

        [NotMapped]
        public string? DniCliente
        {
            get
            {
                if (Clientes != null)
                    return Clientes.DNI;
                return null;
            }
        }

        [NotMapped]
        public string? EstadoPedido
        {
            get
            {
                if (EstadosHistorias != null)
                    return EstadosHistorias.EstadoActual;
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
                return null;
            }
        }

        [NotMapped]
        public DateTime? FechaCambioEstado
        {
            get
            {
                if (EstadosHistorias != null)
                    return EstadosHistorias.FechaCambioEstado;
                return null;
            }
        }
    }
}
