using Microsoft.EntityFrameworkCore;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoDatos
{
    public class VentasDatosEF
    {
        public static RingoDbContext RingoContext = new RingoDbContext();

        //Métodos de consulta

        public static int GenerarNumeroVenta()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null)
                return -1;

            // Obtener la fecha actual en el formato yyMMdd
            string fechaActual = DateTime.Now.ToString("yyMMdd");

            // Obtener el último número de venta
            Ventas? ultimaVenta = RingoContext.Ventas.OrderByDescending(v => v.NumeroVenta).FirstOrDefault();
            int ultimoNumeroIncremental = 0;

            if (ultimaVenta != null)
            {
                // Obtener los primeros 6 dígitos del último número de venta
                string fechaUltimaVenta = ultimaVenta.NumeroVenta.ToString().Substring(0, 6);

                // Verificar si la fecha coincide con la fecha actual
                if (fechaUltimaVenta == fechaActual)
                {
                    // Obtener el número incremental del último número de venta
                    ultimoNumeroIncremental = int.Parse(ultimaVenta.NumeroVenta.ToString().Substring(6));
                }
            }

            // Incrementar el número
            int nuevoNumeroIncremental = ultimoNumeroIncremental + 1;

            // Formatear el número a 6 dígitos con ceros a la izquierda
            string numeroIncremental = nuevoNumeroIncremental.ToString("D3");

            // Combinar la fecha y el número incremental
            string numeroVenta = fechaActual + numeroIncremental;
            int nroVenta = 0;
            if (!int.TryParse(numeroVenta, out nroVenta))
                return 0;

            // Convertir a entero
            return nroVenta;
        }
        public static List<DetallesLibrosDiarios> getMovimientosFinancieros(DateTime fecha)
        {
            List<DetallesLibrosDiarios> lista = new List<DetallesLibrosDiarios> ();
            try
            {
                using (var context = new RingoDbContext())
                {
                    lista = context.DetallesLibrosDiarios
                        .Include(d => d.LibrosDiarios)
                        .Include(d => d.MediosPagos)
                        .Include(d => d.Ventas)
                        .Where(d => d.Fecha.HasValue && d.Fecha.Value.Date == fecha.Date)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar obtener movimientos financieros");
            }
            return lista;
        }
        public static bool insertDetalleFinanciero(DetallesLibrosDiarios? detalle)
        {
            if (detalle == null)
            {
                return false;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.DetallesLibrosDiarios == null)
            {
                return false;
            }
            detalle.IdDetalleLibroDiario = null;
            int exito = 0;
            try
            {
                RingoContext.DetallesLibrosDiarios.Add(detalle);
                exito = RingoContext.SaveChanges();
            } catch (Exception)
            {
                return false;
            }
            return exito > 0;
            
        }

        public static int insertDetalleLibroDiario(DetallesLibrosDiarios? det)
        {
            if (det == null)
            {
                return 0;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.DetallesLibrosDiarios == null)
            {
                return 0;
            }
            DetallesLibrosDiarios detalle = new DetallesLibrosDiarios();
            detalle.IdLibroDiario = det.IdLibroDiario;
            detalle.IdVenta = det.IdVenta;
            detalle.IdMedioPago = det.IdMedioPago;
            detalle.Fecha = det.Fecha;
            detalle.Ingreso = det.Ingreso;
            detalle.Egreso = det.Egreso;
            detalle.Margen = det.Margen;
            detalle.IdDetalleLibroDiario = null;
            try
            {
                RingoContext.DetallesLibrosDiarios.Add(detalle);
                RingoContext.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            if (detalle.IdDetalleLibroDiario == null)
            {
                return 0;
            }
            return (int)detalle.IdDetalleLibroDiario;
        }

        public static Facturas? getFacturaPorId(int id)
        {
            if (id == 0)
            {
                return null;
            }
                
            RingoContext = new RingoDbContext();
            if (RingoContext.Facturas == null)
            {
                return null;
            }

            Facturas? factura = RingoContext.Facturas.Include("MediosPagos").Include("Empresas").Include("TiposFacturas").Include("Sucursales").FirstOrDefault(f => f.IdFactura == id);
            return factura;
        }

        public static List<DetallesFacturas>? getDetallesFacturas(int idFactura)
        {
            if (idFactura == 0)
            {
                return null;
            }

            RingoContext = new RingoDbContext();
            if (RingoContext.DetallesFacturas == null)
            {
                return null;
            }

            List<DetallesFacturas>? detalles = RingoContext.DetallesFacturas.Where(d => d.IdFactura == idFactura).ToList();
            if (detalles == null || detalles.Count == 0)
            {
                return null;
            }
            return detalles;

        }

        public static List<Ventas>? GetVentasPorFecha(DateTime? desde, DateTime? hasta, bool? sinCobrar)
        {
            //Primero creo el contexto y si no se conecta devuelvo null
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null)
                return null;

            //equiparo el sinCobrar con el id de factura
            //Si busco ventas sinCobrar == true. El idFactura debe ser igual a null
            //Si busco ventas sinCobrar == false. El idFactura debe ser diferente a null
            //Si quiero todas las ventas (sinCobrar == null). Con que el idFactura sea id diferente a cero lo cubre
            int? idFac = null;
            if (sinCobrar != null)
                idFac = sinCobrar == true ? 1 : null;
            else
                idFac = 0;
                

            //Creo la lista a retornar
            List<Ventas>? ventas = new();
            //Si la fecha del parametro es null la transformo en la Mínima posible si es desde o la máxima si es hasta
            if (desde == null)
                desde = DateTime.MinValue;
            if (hasta == null)
                hasta = DateTime.MaxValue;

            //Busco las venats incluyendo a los clientes de las mismas
            ventas = RingoContext.Ventas.Include("Clientes.Personas").Include("Estados").Where(v => v.FechaVenta <= hasta && v.FechaVenta >= desde
                                                                    && (idFac == 1 ? v.IdFactura == null : !v.IdFactura.Equals(idFac))
                                                                    ).OrderByDescending(x => x.FechaVenta).ToList();

            //Si es una lista vacia la transformo en null asi no hay que verificar en el front eso
            if (ventas.Count == 0)
                return null;

            return ventas;
        }

        public static List<Ventas>? GetVentasConIds(DateTime? desde, DateTime? hasta, bool? sinCobrar, string texto, List<int> idsClientes)
        {
            //Primero creo el contexto y si no se conecta devuelvo null igualmente si no hay cliente o no tiene id
            RingoContext = new RingoDbContext();
            
            if (RingoContext.Ventas == null || RingoContext.Clientes == null || RingoContext.DetallesVentas == null)
                return null;

            //equiparo el sinCobrar con el id de factura
            //Si busco ventas sinCobrar == true. El idFactura debe ser igual a null
            //Si busco ventas sinCobrar == false. El idFactura debe ser diferente a null
            //Si quiero todas las ventas (sinCobrar == null). Con que el idFactura sea id diferente a cero lo cubre
            int? idFac = null;
            if (sinCobrar != null)
                idFac = sinCobrar == true ? 1 : null;
            else
                idFac = 0;


            //Creo la lista a retornar
            List<Ventas>? ventas = new();
            //Si la fecha del parametro es null la transformo en la Mínima posible si es desde o la máxima si es hasta
            if (desde == null)
                desde = DateTime.MinValue;
            if (hasta == null)
                hasta = DateTime.Today;


            List<DetallesVentas>? detallesVentas = new();

            detallesVentas = RingoContext.DetallesVentas.Include("Prendas").Include("DetallesPrendas").Include("Estados").Where(d =>
                                (d.IdDetallePrenda != null && (d.DetallesPrendas.CodigoDetalle.Contains(texto)))
                                ||
                                (d.DescripcionProducto != null && d.DescripcionProducto.Contains(texto))
                                ).ToList();

            List<int>? idsVentas = (from det in detallesVentas select det.IdVenta).ToList();
            if(idsVentas == null)
            {
                idsVentas = new()
                {
                    0
                };
            }
            List<int> idsNroVentas = RingoContext.Ventas.Where(v => v.NumeroVenta.ToString().Contains(texto)).Select(v => (int)v.IdVenta).ToList();

            if (idsNroVentas.Count > 0)
            {
                idsVentas.AddRange(idsNroVentas);
            }
            //Busco las ventas incluyendo a los clientes de las mismas
            ventas = RingoContext.Ventas.Include("Clientes.Personas").Include("Estados").Include("Empleados").Where(v => 
                                                        (v.FechaVenta <= hasta && v.FechaVenta >= desde && v.IdVenta != null)
                                                        && (idFac == 1 ? v.IdFactura == null : !v.IdFactura.Equals(idFac))
                                                        && ((idsVentas.Contains((int)v.IdVenta) || idsClientes.Contains(v.IdCliente)) 
                                                         )).OrderByDescending(x => x.FechaVenta).ToList();

            //Si es una lista vacia la transformo en null asi no hay que verificar en el front eso
            if (ventas.Count == 0)
                return null;
            return ventas;
        }

        public static Ventas? getVentaPorNumeroVenta(int numero)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null)
                return null;

            Ventas? venta = RingoContext.Ventas.Include("Clientes.Personas").Include("Estados").Include("Empleados").Where(v =>
                                    v.NumeroVenta == numero).FirstOrDefault();
            return venta;
        }

        public static List<Ventas>? GetVentasPorProducto(DetallesVentas? detalle, bool? sinCobrar)
        {
            if (detalle == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null || RingoContext.DetallesVentas == null)
                return null;

            List<DetallesVentas>? detallesVentas = new();
            List<Ventas>? ventas = new();

            detallesVentas = RingoContext.DetallesVentas.Include("Prendas").Include("DetallesPrendas").Include("Estados").Where(d =>
                                (d.IdPrenda != null && detalle.Prendas != null && (d.Prendas.DescripcionPrenda.Contains(detalle.Prendas.DescripcionPrenda ?? "")))
                                ||
                                (d.DescripcionProducto != null && detalle.DescripcionProducto != null && d.DescripcionProducto.Contains(detalle.DescripcionProducto ?? ""))
                                ).ToList();
            if (detallesVentas.Count == 0)
                return null;
            int? idFac = null;
            if (sinCobrar != null)
                idFac = sinCobrar == true ? 1 : null;
            else
                idFac = 0;
            List<int> idVentas = detallesVentas.Select(d => d.IdVenta).Distinct().ToList();
            ventas = RingoContext.Ventas.Include("Clientes.Personas").Include("Estados").Include("Empleados").Where(v => idVentas.Contains((int)v.IdVenta)
                                && (idFac == 1 ? v.IdFactura == null : !v.IdFactura.Equals(idFac))).OrderByDescending(x => x.FechaVenta).ToList();

            if (ventas.Count == 0)
                return null;
            return ventas;
        }

        public static List<Ventas>? GetVentasPorPersona(List<int>? idsPersonas, bool? sinCobrar)
        {
            if (idsPersonas == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null || RingoContext.Clientes == null)
                return null;
            
            List<Clientes>? clientes = RingoContext.Clientes.Include("Personas").Where(cl => idsPersonas.Contains(cl.IdPersona)).ToList();
            if (clientes == null || clientes.Count == 0)
                return null;   

            List<int> idsClientes = (from cliente in clientes select (int)cliente.IdCliente).ToList();
            List<Ventas>? ventas = new();

            int? idFac = null;
            if (sinCobrar != null)
                idFac = sinCobrar == true ? 1 : null;
            else
                idFac = 0;

            ventas = RingoContext.Ventas.Include("Clientes.Personas").Include("Estados").Include("Empleados").Where(v => 
                      idsClientes.Contains((int)v.IdVenta) && (idFac == 1 ? v.IdFactura == null : !v.IdFactura.Equals(idFac))
                      ).OrderByDescending(x => x.FechaVenta).ToList();

            if (ventas.Count == 0)
                return null;
            return ventas;
        }

        public static List<DetallesVentas>? GetDetallesVentas(Ventas? venta)
        {
            if (venta == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.DetallesVentas == null)
                return null;   

            List<DetallesVentas>? detalles = RingoContext.DetallesVentas.Include("Ventas").Include("Prendas").Include("DetallesPrendas").Where(d => 
                                                d.IdVenta == venta.IdVenta).ToList();
            if (detalles == null || detalles.Count == 0)
                return null;
            return detalles;
        }

        public static FondosCajas? FondoCajaCreadoHoy()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.FondosCajas == null)
            {
                return null;
            }

            FondosCajas? fondo = RingoContext.FondosCajas.FirstOrDefault(f => f.FechaFondo.Date == DateTime.Today);
            if (fondo == null)
            {
                return null;
            }
            return fondo;

        }

        //Registrar
        public static int RegistrarVenta (Ventas? venta)
        {
            //comprobaciones de nulidad
            if (venta == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null)
                return 0;
            
            //nulifico el id para el registro autoincremental
            venta.IdVenta = null;

            //No deberían llegar las ventas sin empleados o clientes por eso no los toco

            RingoContext.Ventas.Add(venta);
            RingoContext.SaveChanges();
            if (venta.IdVenta == null)
                return 0;

            return (int)venta.IdVenta;
        }

        public static int RegistrarDetalleVenta (DetallesVentas? detalle)
        {
            if(detalle == null)
                return 0;

            RingoContext = new RingoDbContext();
            if(RingoContext.DetallesVentas == null)
                return 0;

            detalle.IdDetalleVenta = null;
            if(detalle.IdVenta == 0)
                return 0;

            RingoContext.DetallesVentas.Add(detalle);
            RingoContext.SaveChanges();
            if (detalle.IdDetalleVenta == null)
                return 0;
            return (int)detalle.IdDetalleVenta;
        }

        public static List<EstadosPrendas>? getEstadosReservadasPorNroVenta(string? nroVenta)
        {
            if (String.IsNullOrWhiteSpace(nroVenta))
            {
                return null;
            }

            RingoContext = new RingoDbContext();
            if (RingoContext.EstadosPrendas == null)
            {
                return null;
            }
            List<EstadosPrendas>? estados = RingoContext.EstadosPrendas.Include("Prendas").Include("DetallesPrendas").Include("EstadosHistorias").Where(e => 
                                                                e.Observaciones == nroVenta).ToList();
            if (estados == null || estados.Count == 0)
            {
                return null;
            }
            return estados;

        }

        public static int RegistrarFondoCajas(FondosCajas fondo)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.FondosCajas == null)
            {
                return 0;
            }
            FondosCajas nuevo = new FondosCajas();
            nuevo.IdFondoCaja = null;
            nuevo.MontoFondo = fondo.MontoFondo;
            nuevo.IdResponsableCaja = fondo.IdResponsableCaja;
            nuevo.FechaFondo = fondo.FechaFondo;
            RingoContext.FondosCajas.Add(nuevo);
            RingoContext.SaveChanges();
            if (nuevo.IdFondoCaja == null)
                return 0;
            return (int)nuevo.IdFondoCaja;
        }

        public static int RegistrarFactura(Facturas? factura)
        {
            if (factura == null)
                return 0;
            Facturas nuevo = new Facturas();
            nuevo.NumeroFactura = factura.NumeroFactura;
            nuevo.FechaFactura = DateTime.Now;
            nuevo.IdEmpresa = factura.IdEmpresa;
            nuevo.IdResponsableCaja = factura.IdResponsableCaja;
            nuevo.IdTarjetaEntidad = factura.IdTarjetaEntidad;
            nuevo.IdTipoFactura = factura.IdTipoFactura;
            nuevo.IdMedioPago = factura.IdMedioPago;
            nuevo.IdSucursal = factura.IdSucursal;
            nuevo.IdDetalleLibroDiario = factura.IdDetalleLibroDiario;
            nuevo.Total = factura.Total;
            nuevo.cuponTarjeta = factura.cuponTarjeta;

            using (var context = new RingoDbContext())
            {
                context.Facturas.Add(nuevo);
                context.SaveChanges();

                if (nuevo.IdFactura == null)
                    return 0;

                return (int)nuevo.IdFactura;
            }
        }

        public static bool updateLibroDiario(LibrosDiarios? finanzasDiarias)
        {
            if (finanzasDiarias == null)
            {
                return false;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.LibrosDiarios == null)
            {
                return false;
            }
            LibrosDiarios? finanzasModificada = RingoContext.LibrosDiarios.FirstOrDefault(f => f.IdLibroDiario == finanzasDiarias.IdLibroDiario);
            if (finanzasModificada == null)
            {
                return false;
            }
            finanzasModificada.TotalEgresos = finanzasDiarias.TotalEgresos;
            finanzasModificada.TotalIngresos = finanzasDiarias.TotalIngresos;
            finanzasModificada.IdResponsableContable = finanzasDiarias.IdResponsableContable;
            finanzasModificada.FirmaResponsable = finanzasDiarias.FirmaResponsable;

            int exito = 0;
            try
            {
                RingoContext.LibrosDiarios.Update(finanzasModificada);
                exito = RingoContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return exito > 0;
        }

        public static int RegistrarDetalleFactura(DetallesFacturas? detalle)
        {
            if (detalle == null)
                return 0;
            detalle.IdDetalleFactura = null;

            using (var context = new RingoDbContext())
            {
                context.DetallesFacturas.Add(detalle);
                context.SaveChanges();

                if (detalle.IdDetalleFactura == null)
                    return 0;

                return (int)detalle.IdDetalleFactura;
            }
        }

        //Métodos de Stock
        public static string DescontarStockPrenda(Prendas? prenda)
        {
            if (prenda == null)
                return "No hay prenda a la cual descontar stock";
            if (prenda.IdPrenda == null)
                return "La prenda a la cual descontar stock no tiene ID";
            if (prenda.Cantidad < 0)
                return "La cantidad de prenda no puede ser negativa";

            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                    return "No se puede conectar a la base de datos";

                var pren = RingoContext.Prendas.FirstOrDefault(p => p.IdPrenda == prenda.IdPrenda);

                if (pren == null)
                    return "No se encontró la prenda en la base de datos";

                using (var transaction = RingoContext.Database.BeginTransaction())
                {
                    try
                    {
                        pren.Cantidad = prenda.Cantidad;
                        RingoContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();
                        return "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                    }
                    catch (DbUpdateException ex)
                    {
                        transaction.Rollback();
                        return "Error al actualizar la base de datos: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Ocurrió un error inesperado: " + ex.Message;
                    }
                }
            }

            return String.Empty;
        }


        public static string DescontarStockDetallePrenda(DetallesPrendas? detalle)
        {
            if (detalle == null)
                return "No hay detalle de prenda al cual descontar stock";
            if (detalle.IdDetallePrenda == null)
                return "El detalle de prenda al cual descontar stock no tiene ID";
            if (detalle.CantidadPrenda < 0)
                return "La cantidad de detalles de prenda no puede ser negativa";

            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                    return "No se puede conectar a la base de datos";

                var dp = RingoContext.DetallesPrendas.FirstOrDefault(d => d.IdDetallePrenda == detalle.IdDetallePrenda);

                if (dp == null)
                    return "No se encontró el detalle de prenda en la base de datos";
                
                using (var transaction = RingoContext.Database.BeginTransaction())
                {
                    try
                    {
                        dp.CantidadPrenda = detalle.CantidadPrenda;
                        RingoContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();
                        return "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                    }
                    catch (DbUpdateException ex)
                    {
                        transaction.Rollback();
                        return "Error al actualizar la base de datos: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Ocurrió un error inesperado: " + ex.Message;
                    }
                }
            }

            return String.Empty;
        }

        public static string DescontarStockEstadoPrenda(EstadosPrendas? estado, ref int diferencia)
        {
            if (estado == null)
                return "No hay estado de prenda al cual descontar stock";
            if (estado.IdEstadosPrendas == null)
                return "El estado de prenda al cual descontar stock no tiene ID";
            if (estado.CantidadEstado < 0)
                return "La cantidad de estados de prenda no puede ser negativa";
            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                    return "No se puede conectar a la base de datos";

                //Busco el estado normal con su cantidad normal
                var ep = RingoContext.EstadosPrendas.FirstOrDefault(e => e.IdEstadosPrendas == estado.IdEstadosPrendas);

                if (ep == null)
                    return "No se encontró el estado de prenda en la base de datos";

                using (var transaction = RingoContext.Database.BeginTransaction())
                {
                    try
                    {
                        //Calculo la diferencia que la usaré para todo lo otro
                        diferencia = ep.CantidadEstado - estado.CantidadEstado;

                        //Le hago los cambios correspondientes
                        ep.CantidadEstado = estado.CantidadEstado;
                        ep.Observaciones = "";
                        RingoContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();
                        return "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                    }
                    catch (DbUpdateException ex)
                    {
                        transaction.Rollback();
                        return "Error al actualizar la base de datos: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Ocurrió un error inesperado: " + ex.Message;
                    }
                }
            }

            return String.Empty;
        }

        public static string CambiarEstadoHistoriaPrendaReservada(int id)
        {

            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                    return "No se puede conectar a la base de datos";
                List<Estados>? estados = RingoDatosEF.EstadosPorIndole("Prendas");
                if (estados == null)
                    return "No se encuentran estados para prendas";
                int? idReservada = estados.Where(e => e.Estado == "Reservada").Select(e => e.IdEstado).FirstOrDefault();
                if (idReservada == null)
                    return "Falta registrar el estado Reservada en la base de datos";

                var eh = RingoContext.EstadosHistorias.FirstOrDefault(e => e.IdEstadoHistoria == id);

                if (eh == null)
                    return "No se encontró el estado historia en la base de datos";

                using (var transaction = RingoContext.Database.BeginTransaction())
                {
                    try
                    {
                        eh.IdEstadoAnterior = eh.IdEstadoActual;
                        eh.IdEstadoActual = (int)idReservada;
                        eh.FechaCambioEstado = DateTime.Now;
                        RingoContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();
                        return "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                    }
                    catch (DbUpdateException ex)
                    {
                        transaction.Rollback();
                        return "Error al actualizar la base de datos: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Ocurrió un error inesperado: " + ex.Message;
                    }
                }
            }
            return String.Empty;
        }

        //Para crear el estado reservada en la venta
        public static int InsertEstadoPrendaReservada(EstadosPrendas? estadosPrendas, int cantidad, string nroVenta, ref string mensaje)
        {
            int id = 0;
            if (estadosPrendas == null)
            {
                mensaje = "No hay estado de prenda al cual descontar stock";
                return 0;
            }
                
            if (cantidad <= 0)
            {
                mensaje = "No se pueden reservar 0 prendas, cantidad incorrecta";
                return 0;
            }

            if (String.IsNullOrEmpty(nroVenta))
            {
                mensaje = "No se obtuvo correctamente el Número de venta";
                return 0;
            }
            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                {
                    mensaje = "No se puede conectar a la base de datos";
                    return 0;
                }
                List<Estados>? estados = RingoDatosEF.EstadosPorIndole("Prendas");
                if (estados == null)
                {
                    mensaje = "No se encuentran estados para prendas";
                    return 0;
                }
                int? idReservada = estados.Where(e => e.Estado == "Reservada").Select(e => e.IdEstado).FirstOrDefault();
                if (idReservada == null)
                {
                    mensaje = "Falta registrar el estado Reservada en la base de datos";
                    return 0;
                }

                var eh = RingoContext.EstadosHistorias.FirstOrDefault(e => e.IdEstadoHistoria == estadosPrendas.IdEstadoHistoria);
                if (eh == null)
                {
                    mensaje = "No se encontró el estado historia en la base de datos";
                    return 0;
                }

                EstadosHistorias estadoHistoria = new EstadosHistorias();
                estadoHistoria.IdEstadoActual = (int)idReservada;
                estadoHistoria.IdEstadoAnterior = eh.IdEstadoActual;
                estadoHistoria.FechaCambioEstado = DateTime.Now;
                EstadosPrendas estadoNuevo = new EstadosPrendas();
                estadoNuevo.IdPrenda = estadosPrendas.IdPrenda;
                estadoNuevo.IdDetallePrenda = estadosPrendas.IdDetallePrenda;
                estadoNuevo.CantidadEstado = cantidad;
                estadoNuevo.Observaciones = nroVenta;
                estadoNuevo.EstadosHistorias = estadoHistoria;

                RingoContext.EstadosPrendas.Add(estadoNuevo);
                try
                {
                    RingoContext.SaveChanges();
                    id = (int)estadoNuevo.IdEstadosPrendas;
                }
                catch (DbUpdateConcurrencyException)
                {
                    mensaje = "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                    return 0;
                }
                catch (DbUpdateException ex)
                {
                    mensaje = "Error al actualizar la base de datos: " + ex.Message;
                    return 0;
                }
                catch (Exception ex)
                {
                    mensaje = "Ocurrió un error inesperado: " + ex.Message;
                    return 0;
                }

            }
            return id;
        }
        // Updates
        public static bool updateVenta(Ventas? venta, ref string mensaje)
        {
            if (venta == null)
            {
                mensaje = "Error: La venta se vacía antes de modificarse";
                return false;
            }
            if (venta.IdVenta == null)
            {
                mensaje = "Error: La venta no tiene identificador para el registro";
                return false;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.Ventas == null)
            {
                mensaje = "Error: No se puede acceder a la base de datos";
                return false;
            }
            Ventas? actualizada = RingoContext.Ventas.FirstOrDefault(v => v.IdVenta == venta.IdVenta);
            if (actualizada == null)
            {
                mensaje = "Error: no se encuentra la venta a modificar en los registros";
                return false;
            }
            actualizada.IdFactura = venta.IdFactura;
            actualizada.IdResponsableVenta = venta.IdResponsableVenta;
            actualizada.IdCliente = venta.IdCliente;
            actualizada.IdEstado = venta.IdEstado;
            actualizada.FechaVenta = venta.FechaVenta;
            actualizada.DescuentoRecargo = venta.DescuentoRecargo;
            actualizada.NumeroVenta = venta.NumeroVenta;
            actualizada.ObservacionesVenta = venta.ObservacionesVenta;
            RingoContext.Ventas.Update(actualizada);
            int exito = RingoContext.SaveChanges();
            return exito > 0;

        }

        public static string CambiarEstadoVenta(Ventas? v, string estadoNuevo)
        {
            if (v == null)
            {
                return "\nError: La venta viaja vacía";
            }
            if (String.IsNullOrWhiteSpace(estadoNuevo))
            {
                return "\nError: No se puede cambiar el estado de la venta (estado nuevo vacío)";
            }

            using (var RingoContext = new RingoDbContext())
            {
                if (!RingoContext.Database.CanConnect())
                    return "\nError: No se puede conectar a la base de datos";

                //Traigo los estados para cambiar
                List<Estados>? estados = new();
                estados = RingoDatosEF.EstadosPorIndole("Ventas");
                Estados? estadoAhora = null;
                if (estados != null)
                {
                    estadoAhora = estados.FirstOrDefault(es => es.Estado == estadoNuevo);
                } else
                {
                    return "\nError al recuperar estados de la base de datos";
                }
                if (estadoAhora == null)
                {
                    return "\nEl estado nuevo no existe";
                }
                var venta = RingoContext.Ventas.FirstOrDefault(ve => ve.IdVenta == v.IdVenta);

                if (venta == null)
                {
                    return "\nNo se encuentra la venta en la Base de Datos";
                }
                venta.IdEstado = estadoAhora.IdEstado;
                venta.IdFactura = v.IdFactura;
                try
                {
                    RingoContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return "Conflicto de concurrencia: otro usuario ha modificado este registro.";
                }
                catch (DbUpdateException ex)
                {
                    return "Error al actualizar la base de datos: " + ex.Message;
                }
                catch (Exception ex)
                {
                    return "Ocurrió un error inesperado: " + ex.Message;
                }
            }
            return String.Empty;
        }

        public static string CambiarEstadoVenta(int idVenta, string nuevoEstado)
        {
            using (var context = new RingoDbContext())
            {
                var venta = context.Ventas.Find(idVenta);
                if (venta == null)
                    return "Venta no encontrada.";

                var estado = context.Estados.FirstOrDefault(e => e.Estado == nuevoEstado);
                if (estado == null)
                    return "Estado no encontrado.";

                venta.IdEstado = estado.IdEstado;
                context.SaveChanges();

                return string.Empty;
            }
        }

        /*
        public static string DescontarYActualizarEstados(List<DetallesFacturas> detallesFactura)
        {
            using (var context = new RingoDbContext())
            {
                foreach (var detalle in detallesFactura)
                {
                    // Encontrar el detalle de la prenda
                    var prenda = context.DetallesPrendas.Find(detalle.IdDetallePrenda);
                    if (prenda == null)
                        return $"Detalle de prenda con ID {detalle.IdDetallePrenda} no encontrado.";

                    // Descontar stock
                    prenda.CantidadPrenda -= detalle.Cantidad;

                    // Encontrar el estado "Reservada"
                    var estadoReservada = context.Estados.FirstOrDefault(e => e.Estado == "Reservada");
                    if (estadoReservada == null)
                        return "Estado 'Reservada' no encontrado.";

                    // Encontrar el estado "Vendida"
                    var estadoVendida = context.Estados.FirstOrDefault(e => e.Estado == "Vendida");
                    if (estadoVendida == null)
                        return "Estado 'Vendida' no encontrado.";

                    // Actualizar el estado de la prenda
                    var estadoPrenda = context.EstadosPrendas
                        .Include(ep => ep.EstadosHistorias)
                        .FirstOrDefault(ep => ep.IdDetallePrenda == detalle.IdDetallePrenda && ep.EstadosHistorias.IdEstadoActual == estadoReservada.IdEstado
                                            && ep.CantidadEstado >= detalle.Cantidad);

                    if (estadoPrenda != null)
                    {
                        estadoPrenda.EstadosHistorias.IdEstadoAnterior = estadoPrenda.EstadosHistorias.IdEstadoActual;
                        estadoPrenda.EstadosHistorias.IdEstadoActual = (int)estadoVendida.IdEstado;
                        estadoPrenda.EstadosHistorias.FechaCambioEstado = DateTime.Now;
                    }

                    context.SaveChanges();
                }

                return string.Empty;
            }
        }
        */

        public static bool ingresarDineroACaja(FondosCajas? fondoActual)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.FondosCajas == null)
            {
                return false;
            }
            FondosCajas fondo = RingoContext.FondosCajas.FirstOrDefault(f => f.IdFondoCaja == fondoActual.IdFondoCaja);
            if (fondo == null)
            {
                return false;
            }
            fondo.MontoFondo = fondoActual.MontoFondo;
            int exito = RingoContext.SaveChanges();
            if (exito == 0)
            {
                return false;
            }
            return true;
        }


        public static List<MediosPagos> getMedioPago()
        {
            RingoDbContext ringo = new RingoDbContext();
            List<MediosPagos> list = new List<MediosPagos>();
            list = ringo.MediosPagos.ToList();
            
            return list;
        }

        public static List<TarjetasEntidades>? getTarjetasEntidades()
        {
            RingoContext = new RingoDbContext();
            List<TarjetasEntidades>? list = new();
            list = RingoContext.TarjetasEntidades.Include("Tarjetas").Include("EntidadesTarjetas").ToList();
            if (list.Count == 0)
                return null;
            return list;
        }

        public static List<TiposFacturas>? getTiposFacturas()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.TiposFacturas == null)
            {
                return null;
            }
            List<TiposFacturas>? tiposFacturas = RingoContext.TiposFacturas.OrderBy(t => t.TipoFactura).ToList();
            if (tiposFacturas == null || tiposFacturas.Count == 0)
            {
                return null;
            }
            return tiposFacturas;
        }

        public static List<Contactos>? getTelefonosPersona(Personas? per)
        {
            if (per == null)
                return null;
            if (per.IdPersona == null)
                return null;

            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null || RingoContext.Contactos == null)
                return null;
            
            List<Contactos>? list = new();
            list = RingoContext.Contactos.Where(c => c.IdPersona != null && c.IdPersona == per.IdPersona).ToList();
            if (list.Count == 0)
                return null;
            return list;
        }

        public static List<Domicilios>? getDomiciliosPersona(Personas? per)
        {
            if (per == null)
                return null;
            if (per.IdPersona == null)
                return null;

            RingoContext = new RingoDbContext();
            if (RingoContext.Personas == null || RingoContext.Domicilios == null)
                return null;

            List<Domicilios>? list = new();
            list = RingoContext.Domicilios.Include("Barrios").Include("Ciudades.Provincias").Where(d => 
                                                d.IdPersona != null && d.IdPersona == per.IdPersona).ToList();
            if (list.Count == 0)
                return null;
            return list;
        }
    }
}
