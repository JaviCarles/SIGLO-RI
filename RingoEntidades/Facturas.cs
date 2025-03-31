using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Facturas
    {
        [Key]
        public int? IdFactura { get; set; }

        [ForeignKey("TiposFacturas")]
        public int IdTipoFactura { get; set; }

        public int? IdResponsableCaja { get; set; }

        [ForeignKey("DetallesLibrosDiarios")]
        public int? IdDetalleLibroDiario { get; set; }

        [ForeignKey("Empresas")]
        public int IdEmpresa { get; set; }

        [ForeignKey("Sucursales")]
        public int? IdSucursal { get; set; }

        [ForeignKey("MediosPagos")]
        public int IdMedioPago { get; set; }

        [MaxLength(50)]
        public string? NumeroFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        [MaxLength(50)]
        public string? cuponTarjeta { get; set; }

        [ForeignKey("TarjetasEntidades")]
        public int? IdTarjetaEntidad { get; set; }

        public TiposFacturas? TiposFacturas { get; set; }

        [ForeignKey("IdResponsableCaja")]
        public Empleados? Empleados { get; set; }

        public DetallesLibrosDiarios? DetallesLibrosDiarios { get; set; }

        public Empresas? Empresas { get; set; }

        public Sucursales? Sucursales { get; set; }

        public MediosPagos? MediosPagos { get; set; }

        public TarjetasEntidades? TarjetasEntidades { get; set; }
    }
}
