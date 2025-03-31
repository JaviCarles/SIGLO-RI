using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace RingoDatos
{
    public class ReportesDatos
    {
        //public static RingoDbContext RingoContext;
        private static string connectionString = "Server=RINGO\\SQLEXPRESS;Integrated Security=True;Database=AdministracionRingo2;TrustServerCertificate=True";
        //private static string connectionString = "server=localhost;Integrated security = yes; Database=AdministracionRingo2 ;TrustServerCertificate=true";

        #region REPORTE DE VENTAS POR CLIENTE
        public static List<ClienteParaReporte> GetClientesConCompras(bool ordenAscendente, DateTime desde, DateTime hasta, int cantidad)
        {
            List<ClienteParaReporte> listaClientes = new List<ClienteParaReporte>();
            try
            {

                /*string query = @" SELECT c.IdCliente, p.Nombre, p.Apellidos, COUNT(v.IdVenta) AS CantidadCompras, SUM(f.Total) AS MontoTotalCompras FROM dbo.Clientes c JOIN dbo.Personas p ON c.IdPersona = p.IdPersona JOIN dbo.Ventas v ON c.IdCliente = v.IdCliente JOIN dbo.Facturas f ON v.IdFactura = f.IdFactura GROUP BY c.IdCliente, p.Nombre, p.Apellidos ORDER BY CantidadCompras DESC";
                */
                string query;
                if (ordenAscendente)
                {
                    query = @" SELECT TOP(@cantidad) c.IdCliente, p.Nombre, p.Apellidos, p.Dni, COUNT(v.IdVenta) AS CantidadCompras, SUM(f.Total) AS MontoTotalCompras FROM dbo.Clientes c JOIN dbo.Personas p ON c.IdPersona = p.IdPersona JOIN dbo.Ventas v ON c.IdCliente = v.IdCliente JOIN dbo.Facturas f ON v.IdFactura = f.IdFactura WHERE v.FechaVenta BETWEEN @desde AND @hasta GROUP BY c.IdCliente, p.Nombre, p.Apellidos, p.Dni ORDER BY CantidadCompras DESC";
                }
                else
                {
                    query = @" SELECT TOP(@cantidad) c.IdCliente, p.Nombre, p.Apellidos, p.Dni, COUNT(v.IdVenta) AS CantidadCompras, SUM(f.Total) AS MontoTotalCompras FROM dbo.Clientes c JOIN dbo.Personas p ON c.IdPersona = p.IdPersona JOIN dbo.Ventas v ON c.IdCliente = v.IdCliente JOIN dbo.Facturas f ON v.IdFactura = f.IdFactura WHERE v.FechaVenta BETWEEN @desde AND @hasta GROUP BY c.IdCliente, p.Nombre, p.Apellidos, p.Dni ORDER BY CantidadCompras ASC";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cantidad", cantidad); command.Parameters.AddWithValue("@desde", desde); command.Parameters.AddWithValue("@hasta", hasta);
                    connection.Open(); SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClienteParaReporte cliente = new ClienteParaReporte
                        {
                            IdCliente = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            CantidadCompras = reader.GetInt32(4),
                            MontoTotalCompras = reader.GetDecimal(5)

                        };

                        listaClientes.Add(cliente); // Agregar el cliente a la lista 
                    }
                }
                
            }
            catch (Exception ex)
            {
                
            }

            return listaClientes;
        }
        #endregion

        #region REPORTE DE VENTAS ANUAL COMPARATIVO

        public static List<MesParaReporte> Get12Meses(int año)
        {
            List<MesParaReporte> listaMeses = new List<MesParaReporte>();
            try
            {
                string query = "SELECT MONTH(v.FechaVenta) AS Mes, COUNT(v.IdVenta) AS CantidadVentas FROM dbo.Ventas v WHERE YEAR(v.FechaVenta) = @Año GROUP BY MONTH(v.FechaVenta) ORDER BY Mes";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Año", año);
                    connection.Open(); SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int mes = (int)reader["Mes"];
                        int cantidadVentas = (int)reader["CantidadVentas"];
                        string nombreMes = new DateTime(año, mes, 1).ToString("MMMM", new CultureInfo("es-ES"));
                        listaMeses.Add(new MesParaReporte { Nombre = nombreMes, CantidadVentas = cantidadVentas });
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Problemas al consultar las ventas por categoria");
            }
            return listaMeses;
        }

        #endregion

        #region REPORTE DE VENTAS POR PROVEEDOR

        public static List<PrendasVendidasPorProveedor> GetCantidadVentasPorProveedor(int cant, DateTime desde, DateTime hasta)
        {
            List<PrendasVendidasPorProveedor> list = new List<PrendasVendidasPorProveedor>();

            string query = @"
                            SELECT TOP(@Cantidad)
                                Emp.RazonSocial AS NombreProveedor, 
                                SUM(DV.Cantidad) AS CantidadPrendasVendidas 
                            FROM 
                                dbo.DetallesVentas DV
                            JOIN 
                                dbo.Prendas P ON DV.IdPrenda = P.IdPrenda
                            JOIN 
                                dbo.Proveedores Pro ON P.IdProveedor = Pro.IdProveedor
                            JOIN 
                                dbo.Empresas Emp ON Pro.IdEmpresa = Emp.IdEmpresa
                            JOIN 
                                dbo.Ventas V ON DV.IdVenta = V.IdVenta
                            WHERE 
                                V.FechaVenta BETWEEN @Desde AND @Hasta 
                            GROUP BY 
                                Emp.RazonSocial
                            ORDER BY 
                                CantidadPrendasVendidas DESC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection); 
                    command.Parameters.AddWithValue("@Desde", desde); 
                    command.Parameters.AddWithValue("@Hasta", hasta); 
                    command.Parameters.AddWithValue("@Cantidad", cant);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PrendasVendidasPorProveedor
                            {
                                CantidadPrendasVendidas = reader.GetInt32(1), // CantidadTotalVendida
                                NombreProveedor = reader.GetString(0) // NombreProveedor

                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta en DB");
            }

            return list;
        }

        public static List<CantPrendasPorProveedor> GetCantidadDePrendasPorProveedor(int cant)
        {
            List<CantPrendasPorProveedor> list = new List<CantPrendasPorProveedor> ();

            string query = @" SELECT e.RazonSocial, SUM(dp.CantidadPrenda) AS CantidadPrendas
                              FROM Proveedores p
                              JOIN Prendas pr ON p.IdProveedor = pr.IdProveedor
                              JOIN Empresas e ON p.IdEmpresa = e.IdEmpresa
                              JOIN DetallesPrendas dp ON pr.IdPrenda = dp.IdPrenda
                              GROUP BY e.RazonSocial 
                              ORDER BY CantidadPrendas DESC;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open(); 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CantPrendasPorProveedor
                            {
                                NombreProveedor = reader.GetString(0),// RazonSocial
                                CantidadPrendas = reader.GetInt32(1) // CantidadPrendas
                            });
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al consultar la cantidad de prendas por proveedor en la DB");
            }
            return list;
        }

        #endregion

        #region REPORTE DE VENTAS POR CATEGORIA
        public static List<CantidadVentasPorCategoria> GetVentasPorCategoria(int cantidad, DateTime desde, DateTime hasta)
        {
            List<CantidadVentasPorCategoria> lista = new List<CantidadVentasPorCategoria>();

            string query = @"
                             SELECT TOP(@Cantidad) CP.Categoria AS NombreCategoria, 
                             SCP.SubCategoria AS NombreSubCategoria, 
                             SUM(DV.Cantidad) AS CantidadPrendas
                             FROM dbo.DetallesVentas DV 
                             JOIN dbo.Prendas P ON DV.IdPrenda = P.IdPrenda 
                             JOIN dbo.CategoriaSubCategoria CSC ON P.IdCateSubCate = CSC.IdCateSubCate 
                             JOIN dbo.CategoriasPrendas CP ON CSC.IdCategoriaPrenda = CP.IdCategoriaPrenda
                             JOIN dbo.SubCategoriasPrendas SCP ON CSC.IdSubCategoriaPrenda = SCP.IdSubCategoriaPrenda 
                             JOIN dbo.Ventas V ON DV.IdVenta = V.IdVenta
                             WHERE V.FechaVenta BETWEEN @Desde AND @Hasta
                             GROUP BY CP.Categoria, SCP.SubCategoria
                             ORDER BY CantidadPrendas DESC;"; 
              

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                    { 
                        SqlCommand command = new SqlCommand(query, connection); 
                        command.Parameters.AddWithValue("@Desde", desde); 
                        command.Parameters.AddWithValue("@Hasta", hasta); 
                        command.Parameters.AddWithValue("@Cantidad", cantidad); 
                        connection.Open(); 
                    
                        using (SqlDataReader reader = command.ExecuteReader()) 
                            {
                                while (reader.Read())
                                {
                                    lista.Add(new CantidadVentasPorCategoria 
                                    {
                                        NombreCategoria = reader["NombreCategoria"].ToString(),
                                        CantidadPrendas = Convert.ToInt32(reader["CantidadPrendas"]),
                                        NombreSubCategoria = reader["NombreSubCategoria"].ToString(),
                                    });
                                    
                                }
                      
                            }
                    } 

            }
            catch (Exception e) 
            {
                Console.WriteLine("Problemas al consultar la cantidad de ventas por categoria en la db");
            }
            return lista;
        }

      

        public static List<CantidadPrendasPorCategoria> GetPrendasPorCategorias(int cantidad, DateTime? desde, DateTime? hasta)
        {
            List<CantidadPrendasPorCategoria> lista = new List<CantidadPrendasPorCategoria>();

            string query =/* @" SELECT TOP(@Cantidad)
                        CP.Categoria AS NombreCategoria, 
                        SCP.SubCategoria AS NombreSubCategoria, 
                        SUM(DP.CantidadPrenda) AS CantidadPrendas
                    FROM
                        dbo.Prendas P
                    JOIN
                        dbo.DetallesPrendas DP ON P.IdPrenda = DP.IdPrenda
                    JOIN
                        dbo.CategoriaSubCategoria CSC ON P.IdCateSubCate = CSC.IdCateSubCate
                    JOIN
                        dbo.CategoriasPrendas CP ON CSC.IdCategoriaPrenda = CP.IdCategoriaPrenda
                    JOIN
                        dbo.SubCategoriasPrendas SCP ON CSC.IdSubCategoriaPrenda = SCP.IdSubCategoriaPrenda
                    JOIN
                        dbo.DetallesVentas DV ON DP.IdDetallePrenda = DV.IdDetallePrenda
                    JOIN
                        dbo.Ventas V ON DV.IdVenta = V.IdVenta
                   
                    GROUP BY
                        CP.Categoria, SCP.SubCategoria
                    ORDER BY
                        Cantidad DESC;";*/
                @"  SELECT TOP(@Cantidad)
    cat.Categoria AS NombreCategoria,
    subcat.SubCategoria AS NombreSubCategoria,
    SUM(dp.CantidadPrenda) AS CantidadPrendas
FROM 
    dbo.Prendas pr
JOIN 
    dbo.CategoriaSubCategoria csc ON pr.IdCateSubCate = csc.IdCateSubCate
JOIN 
    dbo.CategoriasPrendas cat ON csc.IdCategoriaPrenda = cat.IdCategoriaPrenda
JOIN 
    dbo.SubCategoriasPrendas subcat ON csc.IdSubCategoriaPrenda = subcat.IdSubCategoriaPrenda
JOIN 
    dbo.DetallesPrendas dp ON pr.IdPrenda = dp.IdPrenda
GROUP BY 
    cat.Categoria, subcat.SubCategoria
ORDER BY 
    CantidadPrendas DESC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                 /*   command.Parameters.AddWithValue("@Desde", desde ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Hasta", hasta ?? (object)DBNull.Value);*/
                    command.Parameters.AddWithValue("@Cantidad", cantidad);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CantidadPrendasPorCategoria
                            {
                                NombreCategoria = reader["NombreCategoria"].ToString(),
                                CantidadPrendas = Convert.ToInt32(reader["CantidadPrendas"]),
                                NombreSubCategoria = reader["NombreSubCategoria"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Problemas para realizar la consulta de cantidad de prendas por categoría: {e.Message}");
            }

            return lista;
        }


        #endregion

        #region REPORTE DE EGRESOS E INGRESOS BRUTOS

        /*public static List<MovimientoFinanzasDiario> GetMovimientoFinanzaDiario(int mesAnt, int mesPost,int añoAnt, int añoPost)
        {
            List<MovimientoFinanzasDiario> list = new List<MovimientoFinanzasDiario>();

            try
            {

            }
            catch (Exception e) 
            { 
                Console.WriteLine(e);
            }
            return list;
        }*/

        public static List<MovimientoFinanzasDiario> GetMovimientoFinanzaDiario(int mes, int año)
        {
            List<MovimientoFinanzasDiario> list = new List<MovimientoFinanzasDiario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    FechaLibroDiario,
                    TotalIngresos,
                    TotalEgresos,
                    (TotalIngresos - TotalEgresos) AS Margen
                FROM 
                    dbo.LibrosDiarios
                WHERE 
                    MONTH(FechaLibroDiario) = @mes AND YEAR(FechaLibroDiario) = @año 
                ORDER BY
                    FechaLibroDiario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@año", año);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MovimientoFinanzasDiario movimiento = new MovimientoFinanzasDiario
                                {
                                    Fecha = reader.GetDateTime(0),
                                    TotalIngreso = reader.GetDecimal(1),
                                    TotalEgreso = reader.GetDecimal(2),
                                    TotalMargen = reader.GetDecimal(3)
                                };
                                list.Add(movimiento);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar obtener el listado de Movimientos diarios de finanzas en la capa de datos");
            }
            return list;
        }

        #endregion
    }
}
