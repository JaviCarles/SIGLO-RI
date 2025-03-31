using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Barrios
    {
        [Key]
        public int? IdBarrio { get; set; }

        [MaxLength(100)]
        public string NombreBarrio { get; set; }

        [ForeignKey("Ciudades")]
        public int IdCiudad { get; set; }

        public Ciudades? Ciudades { get; set; }

        [NotMapped]
        public string? NombreCiudad
        {
            get
            {
                if (Ciudades != null)
                    return Ciudades.NombreCiudad;
                else
                    return null;
            }
        }
    }
}
