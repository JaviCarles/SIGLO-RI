using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoEntidades
{
    public class Clientes
    {
        [Key]
        public int? IdCliente { get; set; }

        [ForeignKey("Personas")]
        public int IdPersona { get; set; }

        public Personas? Personas { get; set; }

        [NotMapped]
        public string? DNI
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
        public string? Nombres
        {
            get
            {
                if (Personas != null)
                    return Personas.Nombre;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Apellido
        {
            get
            {
                if (Personas != null)
                    return Personas.Apellidos;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? NombreCompleto
        {
            get
            {
                if (Personas != null)
                    return $"{Personas.Nombre} {Personas.Apellidos}";
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Cuil
        {
            get
            {
                if (Personas != null)
                    return Personas.Cuil;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? CondicionFiscal
        {
            get
            {
                if (Personas != null)
                    return Personas.DetalleFiscal;
                else
                    return null;
            }
        }


        [NotMapped]
        public string? EstadoCliente
        {
            get
            {
                if (Personas != null)
                    return Personas.EstadoPersona;
                else
                    return null;
            }
        }


        [NotMapped]
        public string? Observaciones
        {
            get
            {
                if (Personas != null)
                    return Personas.Observaciones;
                else
                    return null;
            }
        }

        [NotMapped]
        public DateTime? Nacimiento
        {
            get
            {
                if (Personas != null)
                    return Personas.FechaNacimiento;
                else
                    return null;
            }
        }
    }
}
