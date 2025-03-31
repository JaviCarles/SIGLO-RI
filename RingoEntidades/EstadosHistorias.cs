using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class EstadosHistorias
    {
        [Key]
        public int? IdEstadoHistoria { get; set; }

        public int? IdEstadoAnterior { get; set; }

        public int IdEstadoActual { get; set; }

        public DateTime? FechaCambioEstado { get; set; }

        [ForeignKey("IdEstadoAnterior")]
        public Estados? EstadosAnteriores { get; set; }

        [ForeignKey("IdEstadoActual")]
        public Estados? EstadosActuales { get; set; }

        [NotMapped]
        public string? EstadoAnterior
        {
            get
            {
                if (EstadosAnteriores != null)
                    return EstadosAnteriores.Estado;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? EstadoActual
        {
            get
            {
                if (EstadosActuales != null)
                    return EstadosActuales.Estado;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? IndoleEstado
        {
            get
            {
                if (EstadosActuales != null)
                    return EstadosActuales.Indole;
                else
                    return null;
            }
        }
    }
}
