using RingoEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class FacturaC
    {
        public string? nroFactura { get; set; }
        public string? tipoFactura { get; set; }
        public string? cuitEmpresa { get; set; }
        public string? ingresosBrutos { get; set; }
        public string? domicilioSucursal { get; set; }
        public string? telefono { get; set; }
        public string? codPostal { get; set; }
        public string? ciudadProvincia { get; set; }
        public string? nombreCompleto { get; set; }
        public string? domicilioCliente { get; set; }
        public string? ivaCliente { get; set; }
        public string? dniCliente { get; set; }
        public string? condVenta { get; set; }
        public string? condEntrega { get; set; }
        public string? cuilCliente { get; set; }
        public DateTime fechaVenta { get; set; }
        public DateTime? fechaImpresion { get; set; }
        public DateTime? inicioActividades { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? total { get; set; }

        public FacturaC(Facturas? factura, Personas? cliente, Empresas? ringo, Sucursales? ringoGchu, Ventas? venta, List<DetallesFacturas> detalles, Domicilios? domicilioCliente, string? telefonoCliente, string? condEntrega, string? tipoPago, string? tipoFactura)
        {
            
        }
    }
}
