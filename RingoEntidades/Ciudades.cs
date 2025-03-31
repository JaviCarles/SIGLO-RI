using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Ciudades
    {
        [Key]
        public int? IdCiudad { get; set; }

        [MaxLength(100)]
        public string NombreCiudad { get; set; }

        public int? CodigoPostal { get; set; }

        [ForeignKey("Provincias")]
        public int IdProvincia { get; set; }

        public Provincias? Provincias { get; set; }

        [NotMapped]
        public string? NombreProvincia
        {
            get
            {
                if (Provincias != null)
                    return Provincias.NombreProvincia;
                else
                    return null;
            }
        }
    }
}
