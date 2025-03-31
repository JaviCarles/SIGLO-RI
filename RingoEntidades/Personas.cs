using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoEntidades
{
    public class Personas
    {
        [Key]
        public int? IdPersona { get; set; }

        [MaxLength(15)]
        public string Dni { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        [MaxLength(20)]
        public string? Cuil { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(200)]
        public string? Observaciones { get; set; }

        [ForeignKey("CondicionesFiscales")]
        public int IdCondicionFiscal { get; set; }

        [ForeignKey("Estados")]
        public int IdEstado { get; set; }

        public CondicionesFiscales? CondicionesFiscales { get; set; }

        public Estados? Estados { get; set; }

        [NotMapped]
        public string? DetalleFiscal
        {
            get
            {
                if (CondicionesFiscales != null)
                    return CondicionesFiscales.DetalleFiscal;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? EstadoPersona
        {
            get
            {
                if (Estados != null)
                    return Estados.Estado;
                else
                    return null;
            }
        }
    }
}
