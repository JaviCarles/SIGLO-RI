using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RingoDatos
{
    public class FinanzasDatos
    {
        public static RingoDbContext RingoContext;

        public static List<DetallesLibrosDiarios>? getMovimientosFinancieros(DateTime? desde, DateTime? hasta, ref string mensaje)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.DetallesLibrosDiarios == null || RingoContext.LibrosDiarios == null)
            {
                mensaje = "Error al conectarse a los registros de movimientos financieros";
                return null;
            }
            DateTime de = DateTime.Now;
            if (desde == null)
            {
                de = DateTime.MinValue;
            } else
            {
                de = (DateTime)desde;
            }
            DateTime a = DateTime.Now.AddDays(1);
            if (hasta != null)
            {
                a = (DateTime)hasta;
            }
            List<int>? idsLibrosDiarios = RingoContext.LibrosDiarios.Where(l => l.FechaLibroDiario.Date >= de.Date 
                                                    && l.FechaLibroDiario.Date < a.Date ).Select(l => (int)l.IdLibroDiario).ToList();
            if (idsLibrosDiarios == null || idsLibrosDiarios.Count == 0)
            {
                mensaje = "No se encontraron detalles financieros en el rango de fechas seleccionadas";
                return null;
            }

            List<DetallesLibrosDiarios>? detalles = RingoContext.DetallesLibrosDiarios.Include("LibrosDiarios").Where(d => 
                                                            idsLibrosDiarios.Contains(d.IdLibroDiario)).ToList();
            if (detalles == null || detalles.Count == 0)
            {
                return null;
            }
            return detalles;
        }


        public static List<TarjetasEntidades>? getTarjetasTodas()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null)
            {
                return null;
            }
            if (RingoContext.TarjetasEntidades == null)
            {
                return null;
            }

            List<TarjetasEntidades>? lista = RingoContext.TarjetasEntidades.Include("Tarjetas").Include("EntidadesTarjetas").ToList();
            if (lista == null || lista.Count == 0)
            {
                return null;
            }
            return lista;
        }

        public static List<Facturas>? getFacturasDiarias(DateTime dia)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext == null)
            {
                return null;
            }
            if (RingoContext.Facturas == null)
            {
                return null;
            }

            List<Facturas>? lista = RingoContext.Facturas.Include("MediosPagos").Include("DetallesLibrosDiarios.Ventas").Include("Empleados.Personas").Where(f =>
                                                            f.FechaFactura.Date == dia.Date).OrderBy(f => f.IdMedioPago).ToList();

            if (lista == null || lista.Count == 0)
            {
                return null;
            }
            return lista;
        }


    }
}
