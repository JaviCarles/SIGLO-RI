using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class LibrosDiarios
    {
        [Key]
        public int? IdLibroDiario { get; set; }

        [ForeignKey("Empleados")]
        public int? IdResponsableContable { get; set; }

        [MaxLength(100)]
        public string? FirmaResponsable { get; set; }

        public DateTime FechaLibroDiario { get; set; }

        public DateTime? FechaFirma { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalIngresos { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalEgresos { get; set; }

        public Empleados? Empleados { get; set; }

        [NotMapped]
        public bool Firmado
        {
            get
            {
                if (FirmaResponsable != null)
                    return true;
                return false;
            }
        }
    }
}
