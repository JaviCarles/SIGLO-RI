using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Sucursales
    {
        [Key]
        public int? IdSucursal { get; set; }

        [ForeignKey("Empresas")]
        public int IdEmpresa { get; set; }

        [ForeignKey("Domicilios")]
        public int? IdDomicilio { get; set; }

        public int? NroSucursal { get; set; }

        [MaxLength(100)]
        public string? NroIngresosBrutos { get; set; }

        [MaxLength(50)]
        public string? NombreSucursal { get; set; }

        public Empresas? Empresas { get; set; }

        public Domicilios? Domicilios { get; set; }

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
