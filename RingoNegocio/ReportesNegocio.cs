using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Utilities.Test.FixedSecureRandom;


namespace RingoNegocio
{
    public class ReportesNegocio
    {

        public static List<ClienteParaReporte> GetReporte(bool ordenAscendente, DateTime desde, DateTime hasta, int cantidad)
        {
            List<ClienteParaReporte> list = new List<ClienteParaReporte>();

            list = ReportesDatos.GetClientesConCompras(ordenAscendente, desde, hasta, cantidad);

            return list;
        }

        public static List<MesParaReporte> Get12Meses(int año)
        {
            try
            {
                return ReportesDatos.Get12Meses(año);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los meses: {ex.Message}");
                return new List<MesParaReporte>();
            }

        }

        public static List<PrendasVendidasPorProveedor> GetPrendasVendidasPorProveedor(int cant, DateTime desde, DateTime hasta)
        {
            try
            {
                return ReportesDatos.GetCantidadVentasPorProveedor(cant, desde, hasta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las ventas de prendas por proveedor");
                return new List<PrendasVendidasPorProveedor>();
            }
           
        }

        public static List<CantPrendasPorProveedor> GetCantidadPrendasPorProveedor(int cant)
        {
            try
            {
                return ReportesDatos.GetCantidadDePrendasPorProveedor(cant);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al obtener la cantidad de prendas por proveedor");
                return new List<CantPrendasPorProveedor>();
            }
        }

        public static List<CantidadVentasPorCategoria> GetVentasPorCategoria(int cantidad, DateTime desde, DateTime hasta)
        {
            try
            {
                return ReportesDatos.GetVentasPorCategoria(cantidad, desde, hasta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas en el método de la capa negocio del reporte");
                return new List<CantidadVentasPorCategoria>();
            }
        }

        public static List<CantidadPrendasPorCategoria> GetPrendasPorCategorias(int cantidad, DateTime desde, DateTime hasta)
        {

            try
            {
                return ReportesDatos.GetPrendasPorCategorias(cantidad, desde, hasta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas en el método de la capa negocio del reporte");
                return new List<CantidadPrendasPorCategoria>();
            }
        }

        public static List<MovimientoFinanzasDiario> GetMovimientoFinanzaDiario(int mes, int año)
        {
            try
            {
                return ReportesDatos.GetMovimientoFinanzaDiario(mes, año);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas para obtener el reporte en la capa de negocio");
                return new List<MovimientoFinanzasDiario>();
            }
        }
    }

}
