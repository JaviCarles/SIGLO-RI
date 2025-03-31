using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Proveedores
    {
        [Key]
        public int? IdProveedor { get; set; }

        [ForeignKey("Empresas")]
        public int IdEmpresa { get; set; }

        [ForeignKey("Estados")]
        public int IdEstado { get; set; }

        [MaxLength(220)]
        public string? DetalleProveedor { get; set; }

        public Empresas? Empresas { get; set; }

        public Estados? Estados { get; set; }

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
        public string? RazonSocial
        {
            get
            {
                if (Empresas != null)
                    return Empresas.RazonSocial;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Cuit
        {
            get
            {
                if (Empresas != null)
                    return Empresas.Cuit;
                else
                    return null;
            }
        }

    }
}
