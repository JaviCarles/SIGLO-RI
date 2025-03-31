using Org.BouncyCastle.Asn1.X509;
using RingoDatos;
using RingoEntidades;
using RingoFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class FinanzasNegocio
    {
        public static int buscarDiferenciaEfectivo(decimal declarado, ref decimal diferencia, ref string mensaje)
        {
            //Primero Busco si hay fondo de cajas creado hoy
            FondosCajas? fondoHoy = VentasDatosEF.FondoCajaCreadoHoy(); 
            if (fondoHoy == null)
            {
                mensaje = "No hay fondoFactura de cajas creado hoy";
                return -1;
            }
            diferencia = declarado - fondoHoy.MontoFondo;
            if (diferencia == 0)
            {
                mensaje = "No hay diferencias de dinero en efectivo";
                return 0;
            }
            if (diferencia > 1)
            {
                mensaje = $"Hay un sobrante de cajas de ${diferencia}";
                return 1;
            } else
            {
                mensaje = $"Hay un faltante de cajas de ${diferencia}";
                return -1;
            }
        }
        
        //Queda con fecha para poder hacerlo genérico más adelante
        public static List<CajasConsulta>? getMovimientosCaja(DateTime? fecha, ref string mensaje)
        {
            DateTime dia = fecha ?? DateTime.Now;
            List<Facturas>? facturas = FinanzasDatos.getFacturasDiarias(dia);
            List<TarjetasEntidades>? tarjetasEntidades = FinanzasDatos.getTarjetasTodas();
            List<MediosPagos>? mediosPagos = VentasDatosEF.getMedioPago();
            string mensajeFalla = "";
            FondosCajas? fondo = VentasDatosEF.FondoCajaCreadoHoy();
            if (fondo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            if (facturas == null || facturas.Count == 0)
            {
                mensaje = "No Huvo ventas cobradas en el día de hoy";
                return new();
            }
            
            if (mediosPagos == null || mediosPagos.Count == 0)
            {
                mensajeFalla = "\nNo se puede acceder a los medios de pago en la base de datos";
            }
            if (tarjetasEntidades == null || tarjetasEntidades.Count == 0)
            {
                mensajeFalla += "\nNo se puede acceder a las tarjetas y bancos registrados en la base de datos";
            }
            if (!String.IsNullOrWhiteSpace(mensajeFalla))
            {
                mensaje = "Error la operación se cancela por los siguientes motivos:"+mensajeFalla;
                return null;
            }

            Facturas fondoFactura = new Facturas();
            List<TiposFacturas>? tipos = VentasDatosEF.getTiposFacturas();
            if (tipos == null || tipos.Count == 0)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            TiposFacturas? tipo = tipos.FirstOrDefault();
            if (tipo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            if (Llaves.Empresa == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            if (Llaves.Empresa.IdEmpresa == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            if (Llaves.EmpleadoUsuario == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            Tarjetas? tarjNula = tarjetasEntidades.Where(t => t.Tarjetas != null && t.Tarjetas.Tarjeta.Contains("--")).Select(t => t.Tarjetas).FirstOrDefault();
            EntidadesTarjetas? bancoNulo = tarjetasEntidades.Where(t => t.EntidadesTarjetas != null && t.EntidadesTarjetas.EntidadFinanciera.Contains("--")).Select(t => t.EntidadesTarjetas).FirstOrDefault();
            if (tarjNula == null || bancoNulo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            TarjetasEntidades? nula = tarjetasEntidades.Where(t => t.IdEntidadTarjeta == bancoNulo.IdEntidadTarjeta && t.IdTarjeta == tarjNula.IdTarjeta).FirstOrDefault();
            if (nula == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            MediosPagos? efectivo = mediosPagos.FirstOrDefault(m => m.FormaPago == "Efectivo");
            if (efectivo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return null;
            }
            decimal cobros = facturas.Where(f => f.IdMedioPago == efectivo.IdMedioPago).Sum(f => f.Total);
            decimal monto = fondo.MontoFondo;
            if (cobros > 0)
            {
                monto = fondo.MontoFondo - cobros;
            }
            fondoFactura.IdTipoFactura = (int)tipo.IdTipoFactura;
            fondoFactura.IdEmpresa = (int)Llaves.Empresa.IdEmpresa;
            fondoFactura.NumeroFactura = "_FondoCajas";
            fondoFactura.FechaFactura = dia;
            fondoFactura.IdMedioPago = (int)efectivo.IdMedioPago;
            fondoFactura.IdTarjetaEntidad = nula.IdTarjetaEntidad;
            fondoFactura.Total = monto;
            List<CajasConsulta> cierre = new List<CajasConsulta>();
            if (monto > 0)
            {
                CajasConsulta apertura = new CajasConsulta(fondoFactura, mediosPagos, tarjetasEntidades);
                cierre.Add(apertura);
            }
            
            foreach (Facturas factura in facturas)
            {
                try
                {
                    CajasConsulta movimiento = new CajasConsulta(factura, mediosPagos, tarjetasEntidades);
                    cierre.Add(movimiento);
                } catch (Exception ex)
                {
                    mensajeFalla += $"\nError al traer la factura n°:{factura.NumeroFactura}\nMensaje de error: {ex.Message}";
                }
                
            }
            mensaje += mensajeFalla;
            return cierre;
        }



        /*
        public static List<DetallesLibrosDiarios> getMovimientosDeCajas ()
        {

        }*/
    }
}
