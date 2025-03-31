using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RingoEntidades
{
    public class Usuarios
    {
        [Key]
        public int? IdUsuario { get; set; }

        [MaxLength(100)]
        public string NombreUsuario { get; set; }

        [MaxLength(100)]
        public string ClaveUsuario { get; set; }

        public int? IdPersona { get; set; }

        [ForeignKey("IdPersona")]
        public Personas? Personas { get; set; }

        [NotMapped]
        public string? Nombre
        {
            get
            {
                if (Personas != null)
                    return Personas.Nombre;
                else
                    return null;
            }
        }

        public string? Apellidos
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
    }
}