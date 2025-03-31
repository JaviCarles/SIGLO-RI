using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Empleados
    {
        [Key]
        public int? IdEmpleado { get; set; }

        [ForeignKey("Personas")]
        public int IdPersona { get; set; }

        [ForeignKey("Estados")]
        public int IdEstado { get; set; }

        [ForeignKey("Puestos")]
        public int IdPuesto { get; set; }

        [MaxLength(50)]
        public string Legajo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public Personas? Personas { get; set; }

        public Estados? Estados { get; set; }

        public Puestos? Puestos { get; set; }

        [NotMapped]
        public string? NombreYApellido
        {
            get
            {
                if (Personas != null)
                    return Personas.Nombre+" "+Personas.Apellidos;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Dni
        {
            get
            {
                if (Personas != null)
                    return Personas.Dni;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Estado
        {
            get
            {
                if (Estados != null)
                    return Estados.Estado;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Puesto
        {
            get
            {
                if (Puestos != null)
                    return Puestos.Puesto;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? DescripcionPuesto
        {
            get
            {
                if (Puestos != null)
                    return Puestos.DescripcionPuesto;
                else
                    return null;
            }
        }
    }
}
