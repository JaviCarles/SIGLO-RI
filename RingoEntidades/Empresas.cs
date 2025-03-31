using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Empresas
    {
        [Key]
        public int? IdEmpresa { get; set; }

        [ForeignKey("Domicilios")]
        public int? IdDomicilio { get; set; }

        [ForeignKey("CondicionesFiscales")]
        public int IdCondicionFiscal { get; set; }

        [MaxLength(100)]
        public string RazonSocial { get; set; }

        [MaxLength(20)]
        public string? Cuit { get; set; }

        public DateTime? InicioActividades { get; set; }

        public Domicilios? Domicilios { get; set; }

        public CondicionesFiscales? CondicionesFiscales { get; set; }

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

    }
}
