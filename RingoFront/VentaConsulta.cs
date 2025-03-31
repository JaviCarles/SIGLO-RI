using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class VentaConsulta
    {
        public int IdVenta { get; set; }
        public int IdEstado { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFactura { get; set; }
        public Clientes? Cliente { get; set; }
        public Empleados? Vendedor { get; set; }
        public Estados? Estado { get; set; }
        public Ventas? Venta { get; set; }
        public int? NumeroVenta { get; set; }
        public DateTime? Fecha { get; set; }
        public string NombresCliente { get; set; }
        public string NombresVendedor { get; set; }
        public string DniCliente { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? MontoReal { get; set; }
        public decimal? TotalDescuentosRecargos { get; set; }
        public int CantidadProductos { get; set; }
        public string? DescuentoRecargoAplicado { get; set; }
        public List<DetallesVentas>? DetallesVenta { get; set; }
        public string? ObservacionesVenta { get; set; }
        public string? EstadoVenta { get; set; }

        public VentaConsulta(Empleados? vendedor, Clientes? cliente,Ventas? venta, List<DetallesVentas>? detallesVentas, Estados? estado)
        {
            Vendedor = vendedor;
            Cliente = cliente;
            Venta = venta;
            DetallesVenta = detallesVentas;
            Estado = estado;

            if (Venta != null)
            {
                IdVenta = Venta.IdVenta ?? 0;
                NumeroVenta = Venta.NumeroVenta ?? 0;
                Fecha = Venta.FechaVenta;
                ObservacionesVenta = Venta.ObservacionesVenta;
                if (DetallesVenta != null && DetallesVenta.Count > 0)
                {
                    CantidadProductos = DetallesVenta.Sum(x => x.Cantidad);
                    MontoTotal = 0;
                    MontoTotal += DetallesVenta.Sum(x => x.SubTotal) * (Venta.DescuentoRecargo == null ? 0 : Venta.DescuentoRecargo / 100);
                }
                else
                {
                    CantidadProductos = 0;
                    MontoTotal = 0;
                }
            }

            if (Vendedor != null)
            {
                NombresVendedor = Vendedor.NombreYApellido ?? "Vendedor Sin Datos";
                IdEmpleado = Vendedor.IdEmpleado ?? 0;
            } else
            {
                NombresVendedor = "Sin Vendedor";
                IdEmpleado = 0;
            }
            if (Cliente != null)
            {
                NombresCliente = $"{Cliente.Nombres ?? "Error en Cliente: "} {Cliente.Apellido ?? "Faltan Datos"}";
                DniCliente = Cliente.DNI ?? "";
                IdCliente = Cliente.IdCliente ?? 0;
            } else
            {
                NombresCliente = "Sin Cliente";
                DniCliente = "";
                IdCliente = 0;
            }
            if (Estado != null)
            {
                EstadoVenta = Estado.Estado ?? "Estado Sin Datos";
                IdEstado = Estado.IdEstado ?? 0;
            } else
            {
                EstadoVenta = "Sin Estado";
                IdEstado = 0;
            }
            
        }

    }
}
