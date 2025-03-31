using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class CajasConsulta
    {
        public int? idFactura { get; set; }
        public int? idMedioPago { get; set; }
        public string? MedioDePago { get; set; }
        public string? Hora { get; set; }
        public string? Tarjeta { get; set; }
        public string? Banco { get; set; }
        public string? Vendedor { get; set; }
        public decimal? TotalFactura { get; set; }

        public CajasConsulta(Facturas factura, List<MediosPagos> mediosPagos, List<TarjetasEntidades> tarjetasEntidades)
        {
            idFactura = factura.IdFactura;
            idMedioPago = factura.IdMedioPago;
            MedioDePago = mediosPagos.Where(m => m.IdMedioPago == idMedioPago).Select(m => m.FormaPago).FirstOrDefault();
            int hora = factura.FechaFactura.Hour;
            int minutos = factura.FechaFactura.Minute;
            Hora = $"{hora}:{minutos}";
            TarjetasEntidades? TarjEnt = tarjetasEntidades.FirstOrDefault(t => t.IdTarjetaEntidad == factura.IdTarjetaEntidad);
            if (TarjEnt == null )
            {
                Tarjeta = "---";
                Banco = "---";
            } else
            {
                Tarjeta = TarjEnt.Tarjetas == null ? "---" : TarjEnt.Tarjetas.Tarjeta;
                Banco = TarjEnt.EntidadesTarjetas == null ? "---" : TarjEnt.EntidadesTarjetas.EntidadFinanciera;
            }
            if (factura.Empleados == null)
            {
                Vendedor = "---";
            } else
            {
                Vendedor = factura.Empleados.Personas == null ? "---" : factura.Empleados.NombreYApellido;
            }
            TotalFactura = factura.Total;

        }
    }
}
