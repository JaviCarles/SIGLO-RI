using Microsoft.EntityFrameworkCore;
using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class VentasNegocio
    {

        public static Empleados? cajeroActual()
        {
            Empleados? cajero = Llaves.EmpleadoUsuario;
            if (cajero == null)
                return new();
            return cajero;
        }

        //Registro
        public static int RegistrarNuevaVenta(Ventas? v, ref string mensaje)
        {
            //Valido que la venta no entre null
            if (v == null)
            {
                mensaje = "\nNo se envió ningna venta a registrar";
                return 0;
            }
            //Valido que el usuario que realiza la venta esté logueado
            if (Llaves.EmpleadoUsuario == null)
            {
                mensaje = "\nEl usuario no está registrado correctamente (como empleado)";
                return 0;
            }
            //Le cargo la llave de empleado a la venta o cero si no esta registrado (id == null)
            v.IdResponsableVenta = Llaves.EmpleadoUsuario.IdEmpleado == null ? 0 : (int)Llaves.EmpleadoUsuario.IdEmpleado;
            if (v.IdResponsableVenta == 0)
            {
                mensaje = "\nEl empleado a cargo de la venta no está registrado correctamente";
                return 0;
            }
            else
            {
                //nulifico la entidad empleado dentro de la venta ya que tengo el id
                v.Empleados = null;
            }

            //Valido que las entidades relacionadas no se registren por duplicado
            if (v.IdCliente > 0)
                v.Clientes = null;
            //Traigo los estados para agregar
            List<Estados>? estados = new();
            estados = RingoDatosEF.EstadosPorIndole("Ventas");
            Estados? estado = null;
            if (estados != null)
            {
                estado = estados.FirstOrDefault(es => es.Estado == "En Curso");
            }
            if (estado != null)
            {
                v.IdEstado = estado.IdEstado;
            } else
            {
                mensaje += "\nError al registrar el estado de venta. Faltan los estados de índole Ventas";
            }
            v.FechaVenta = DateTime.Now;
            v.IdFactura = null;
            v.Facturas = null;

            int idVenta = VentasDatosEF.RegistrarVenta(v);
            if (idVenta == 0)
            {
                mensaje = "\nError al registrar la venta. Corrobore la conexión a la Base de Datos";
                return 0;
            }
            v.Estados = estado;
            return idVenta;

        }

        public static List<int>? RegistrarDetallesVenta (List<DetallesVentas>? detalles, int idVenta, List<List<int>>? matrizIds, ref string mensaje)
        {
            //Controlo los datos primero que no viaje nada vacío
            if (detalles == null || detalles.Count == 0)
            {
                mensaje += "\nNo hay detalles para registrar en la venta";
                return null;
            }
            if (idVenta == 0)
            {
                mensaje += "\nNo hay Venta registrada o no se puede acceder a ella";
                return null;
            }
            if (matrizIds == null)
            {
                mensaje += "\nError con los stocks reservados";
                return null;
            }

            //Creo la lista de ids y empiezo a iterar
            List<int> ids = new();
            for (int i = 0; i < detalles.Count; i++)
            {
                int index = matrizIds[0].IndexOf(detalles[i].IdVenta);
                if (index == -1)
                {
                    mensaje += $"Error no se registra el detalle de venta nro {i + 1}";
                    continue;
                }
                int idEstado = 0;
                
                try
                {
                    idEstado = matrizIds[0][index];
                }
                catch (Exception)
                {
                    mensaje += $"Error no se registra el detalle de venta nro {i + 1}";
                    continue;
                }
                if (idEstado < 1)
                {
                    mensaje += $"Error no se registra el detalle de venta nro {i + 1}";
                    continue;
                }
                DetallesVentas nuevo = new();
                nuevo.Cantidad = detalles[i].Cantidad;
                nuevo.IdVenta = idVenta;
                nuevo.IdPrenda = detalles[i].IdPrenda;
                nuevo.IdDetallePrenda = detalles[i].IdDetallePrenda;
                nuevo.DescripcionProducto = $"E{idEstado}- {detalles[i].DescripcionProducto}";
                nuevo.SubTotal = detalles[i].SubTotal;
                ids.Add(VentasDatosEF.RegistrarDetalleVenta(nuevo));
                if (ids[i] < 1)
                    mensaje += "\nError al registrar el detalle nro: " + (i + 1);
            }
            return ids;
        }

        public static int GenerarNumeroVenta()
        {
            return VentasDatosEF.GenerarNumeroVenta();
        }

        public static List<DetallesLibrosDiarios> getMovimientosFinancieros(DateTime fecha)
        {
            List<DetallesLibrosDiarios> lista = new();
            
            try 
            { 
                lista = VentasDatosEF.getMovimientosFinancieros(fecha);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener los movimientos financieros: {ex.Message}");
            }
            return lista;
        }

        //Stock
        public static List<List<int>>? ReservarStock(List<EstadosPrendas>? estados, string nroVenta, ref string mensaje)
        {
            if (estados == null || estados.Count == 0)
            {
                mensaje += "\n No se puede registrar la venta. Problemas con los estados de prendas";
                return null;
            }

            //Creo las listas correspondientes
            List<List<int>> matriz = new List<List<int>>();
            List<int> idsAptas = new List<int>();
            List<int> idsReservados = new List<int>();
            List<int> idsErrores = new List<int>();

            //Recorro los estados
            for (int i = 0; i < estados.Count; i++)
            {
                //Empiezo a llenar la lista de las aptas
                idsAptas.Add((int)estados[i].IdEstadosPrendas);

                //Creo las entidades y las variables para despues
                int idReservada = 0;

                //El id de error es simbólico y es para saber que error me dió por lo que los números son diferentes segun lo que falla
                //Por el momento no se usa más que para debugueo
                int idError = 0;

                Prendas? pr = estados[i].Prendas;
                //Si no tiene prenda recorro la siguiente
                if (pr == null)
                {
                    mensaje += $"\nProblemas con la prenda del item nro {i+1}. No viaja correctammente a la BD";
                    idError = 1;
                    continue;
                }

                //Lo mismo con detalle
                DetallesPrendas? dp = estados[i].DetallesPrendas;
                if (dp == null)
                {
                    mensaje += $"\nProblemas con el detalle de la prenda del item nro {i + 1}. No viaja correctammente a la BD";
                    idError += 2;
                    continue;
                }

                //Creo la variable que contendrá los mensajes de errores y la de la diferencia para hacer la reserva
                string mensajeDatos = String.Empty;
                int diferencia = 0;

                //Accedo al método que descuenta y trae la diferencia
                mensajeDatos = VentasDatosEF.DescontarStockEstadoPrenda(estados[i], ref diferencia);
                if (!String.IsNullOrEmpty(mensajeDatos))
                {
                    mensaje += mensajeDatos;
                    idError += 4;
                    continue;
                }
                mensajeDatos = "";

                //Una vez descontado el estado apta creo la reservada
                idReservada = VentasDatosEF.InsertEstadoPrendaReservada(estados[i], diferencia, nroVenta, ref mensajeDatos);
                //A{ado el id a la lista y si es menor a 1 que es error aviso del mismo
                idsReservados.Add(idReservada);
                if (idReservada < 1)
                {
                    mensaje += mensajeDatos;
                    idError += 8;
                    continue;
                }
                if (diferencia < 0)
                {
                    mensaje += "¡Cuidado se hizo una venta superior al stock del producto! Recuerde corregir antes de la facturación";
                }

                mensajeDatos = VentasDatosEF.DescontarStockPrenda(pr);
                if (!String.IsNullOrEmpty(mensajeDatos))
                {
                    mensaje += mensajeDatos;
                    idError += 20;
                    continue;
                }

                mensajeDatos = VentasDatosEF.DescontarStockDetallePrenda(dp);
                if (!String.IsNullOrEmpty(mensajeDatos))
                {
                    mensaje += mensajeDatos;
                    idError += 40;
                    continue;
                }
                idsErrores.Add(idError);
                
            }
            //Una vez terminada la iteración añado las listas a la matriz
            matriz.Add(idsAptas);
            matriz.Add(idsReservados);
            matriz.Add(idsErrores);
            return matriz;
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

            return VentasDatosEF.CambiarEstadoVenta(v, estadoNuevo);
        }

        //Consultas
        public static FondosCajas? FondoCajaCreadoHoy()
        {
            FondosCajas? fondo = VentasDatosEF.FondoCajaCreadoHoy();
            if (fondo == null)
            {
                return null;
            }
            return fondo;
        }

        public static List<Ventas>? GetVentasComleto(DateTime? fechaDesde, DateTime fechaHasta, string? textoBuscado, bool cobradas, bool noCobradas, bool envio, ref string mensaje)
        {
            //Comparo si busco sin cobrar, no cobradas o ambas
            bool? sinCobrar = null;
            sinCobrar = cobradas ? !cobradas : null;
            sinCobrar = noCobradas ? noCobradas : null;
            string texto = textoBuscado ?? "";
            List<Ventas>? ventas = null;
            if (String.IsNullOrWhiteSpace(texto))
            {
                ventas = VentasDatosEF.GetVentasPorFecha(fechaDesde, fechaHasta, sinCobrar);
                if (ventas == null)
                {
                    mensaje = "\nNo se encontraron ventas en la fecha seleccionada";
                }
                if (envio && ventas != null)
                {
                    List<Ventas>? conEnvio = ventas.Where(v => v.Estados != null && v.Estados.Estado == "Envio Pendiente").ToList();
                    if (conEnvio == null || conEnvio.Count == 0)
                    {
                        mensaje = "\nNo se encontraron ventas con Envio Pendiente en la fecha seleccionada";
                        conEnvio = null;
                    }
                    return conEnvio;
                }
                return ventas;
            }

            List<int>? idsClientes = PersonasDatosEF.GetIdsClientesPorTexto(texto);
            if (idsClientes == null)
            {
                idsClientes = new()
                {
                    0
                };
            }
            ventas = VentasDatosEF.GetVentasConIds(fechaDesde, fechaHasta, sinCobrar, texto, idsClientes);
            if (ventas == null || ventas.Count == 0)
            {
                mensaje += "\nNo se encontró ninguna venta con el texto ingresado";
                return null;
            }

            if (envio && ventas != null)
            {
                List<Ventas>? conEnvio = ventas.Where(v => v.Estados != null && v.Estados.Estado == "Envio Pendiente").ToList();
                if (conEnvio == null || conEnvio.Count == 0)
                {
                    mensaje = "\nNo se encontraron ventas con Envio Pendiente y el texto ingresado en la fecha seleccionada";
                    conEnvio = null;
                }
                return conEnvio;
            }

            return ventas;
        }

        public static List<DetallesVentas>? GetDetallesVentas(Ventas? venta)
        {
            if (venta == null)
                return null;
            List<DetallesVentas>? detalles = VentasDatosEF.GetDetallesVentas(venta);
            if (detalles == null || detalles.Count == 0)
                return null;
            return detalles;
        }

        public static List<MediosPagos> getMediosPago()
        {
            List<MediosPagos> list = new List<MediosPagos>();
            list = VentasDatosEF.getMedioPago();
            
            return list;
        }

        public static Ventas? getVentaPorNumeroVenta(int numero)
        {
            if (numero == 0)
                return null;
            Ventas? venta = VentasDatosEF.getVentaPorNumeroVenta(numero);
            return venta;
        }

        public static List<TarjetasEntidades>? getTarjetasEntidades()
        {
            List<TarjetasEntidades>? list = new();
            list = VentasDatosEF.getTarjetasEntidades();
            if (list == null || list.Count == 0)
                return null;
            return list;
        }

        public static List<TiposFacturas>? getTiposFacturas()
        {
            List<TiposFacturas>? tiposFacturas = new();
            tiposFacturas = VentasDatosEF.getTiposFacturas();
            if (tiposFacturas == null)
            {
                return new();
            }
            return tiposFacturas;
        }

        public static List<string>? getTelefonosCliente(Clientes? cliente)
        {
            if (cliente == null)
            {
                return null;
            }
            if (cliente.Personas == null)
            {
                return null;
            }
            List<Contactos>? contactos = VentasDatosEF.getTelefonosPersona(cliente.Personas);
            if (contactos == null || contactos.Count == 0)
            {
                return null;
            }

            List<string>? list = new();

            foreach (Contactos contacto in contactos)
            {
                string telefono = "";
                telefono += contacto.codArea + "-";
                telefono += contacto.Telefono;
                list.Add(telefono);
            }
            return list;

        }

        public static List<string>? getDomiciliosCliente(Clientes? cliente)
        {
            if (cliente == null)
            {
                return null;
            }
            if (cliente.Personas == null)
            {
                return null;
            }

            List<Domicilios>? dom = VentasDatosEF.getDomiciliosPersona(cliente.Personas);
            if (dom == null || dom.Count == 0)
            {
                return null;
            }

            List<string>? list = new();
            foreach (Domicilios d in dom)
            {
                string domicilio = "";
                domicilio += d.Calle == null ? "" : d.Calle + " ";
                domicilio += d.Altura == null ? "" : d.Altura + " ";
                domicilio += d.Piso == null ? "" : "| Piso: " + d.Piso;
                domicilio += d.Departamento == null ? "" : " | Depto: " + d.Departamento;
                domicilio += d.Barrios == null ? "" : " | Barrio: " + d.Barrios.NombreBarrio;
                domicilio += d.ObservacionesBarrio == null ? "" : " " + d.ObservacionesBarrio;
                domicilio += d.Ciudades == null ? "" : " | " + d.NombreCiudad + ", " + d.Ciudades.NombreProvincia;
                list.Add(domicilio);
            }
            return list;
        }



        public static bool RegistrarFacturaCompleta(Ventas? venta, List<DetallesVentas>? detallesVenta, bool envio, string? telefonoEnvio, string? direccionEnvio, ref string mensaje)
        {
            // Validar objetos
            if (venta == null)
            {
                mensaje = "Error con la venta, está viajando vacía al registro";
                return false;
            }
            if (detallesVenta == null)
            {
                mensaje = "Error no viajan las prendas cobradas al registro";
                return false;
            }
            if (venta.Facturas == null)
            {
                mensaje = "Error no viajan los datos de cobro al registro";
                return false;
            }
            if (venta.Clientes == null)
            {
                mensaje = "Error no viajan los datos del cliente al registro";
                return false;
            }
            if (Llaves.EmpleadoUsuario == null)
            {
                mensaje = "Error con la sesión, el usuario no es empleado";
                return false;
            }
            venta.Facturas.IdResponsableCaja = (int)Llaves.EmpleadoUsuario.IdEmpleado;
            string nroVenta = venta.NumeroVenta.ToString();

            if (Llaves.Empresa == null)
            {
                mensaje = "Error con el sistema, no se puede acceder a la información de la empresa";
                return false;
            }
            venta.Facturas.IdEmpresa = (int)Llaves.Empresa.IdEmpresa;

            if (Llaves.Sucursal == null)
            {
                mensaje = "Error con el sistema, no se puede acceder a la información de sucursal";
                return false;
            }
            venta.Facturas.IdSucursal = (int)Llaves.Sucursal.IdSucursal;

            int idFactura = VentasDatosEF.RegistrarFactura(venta.Facturas);
            if (idFactura == 0)
            {
                mensaje = "Error al registrar la factura.";
                return false;
            }
            venta.IdFactura = idFactura;
            string cambioEstado = VentasDatosEF.CambiarEstadoVenta(venta, "Cobrada");
            if (!String.IsNullOrWhiteSpace(cambioEstado))
            {
                mensaje = "Error en el cambio de estado de la venta"+cambioEstado;
                return false;
            }

            List<DetallesFacturas> detallesFacturas = new List<DetallesFacturas>();
            // Crear detalles de la factura
            string mensajeDetalle = "";
            int contador = 1;
            LibrosDiarios? libroDiario = Llaves.LibroDiario;
            if (libroDiario == null)
            {
                Llaves.LibroDiario = RingoDatosEF.registrarLibroDiario(venta.Empleados);
                libroDiario = Llaves.LibroDiario;
            }
            if (libroDiario == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            DetallesLibrosDiarios detalleFinanciero = new DetallesLibrosDiarios();
            detalleFinanciero.IdLibroDiario = (int)libroDiario.IdLibroDiario;
            detalleFinanciero.IdMedioPago = venta.Facturas.IdMedioPago;
            detalleFinanciero.IdVenta = (int)venta.IdVenta;
            detalleFinanciero.Ingreso = venta.Facturas.Total;
            detalleFinanciero.Egreso = 0;

            foreach (var detalle in detallesVenta)
            {
                DetallesFacturas detalleFactura = new DetallesFacturas
                {
                    IdFactura = idFactura,
                    IdPrenda = detalle.IdPrenda,
                    IdDetallePrenda = detalle.IdDetallePrenda,
                    Cantidad = detalle.Cantidad,
                    SubTotal = detalle.SubTotal,
                    DescripcionProducto = detalle.DescripcionProducto
                };

                int idDetalleFactura = VentasDatosEF.RegistrarDetalleFactura(detalleFactura);
                if (idDetalleFactura == 0)
                {
                    mensajeDetalle += $"\nError al registrar el detalle n°{contador} de la factura.";
                }
                detalleFactura.IdDetalleFactura = idDetalleFactura;
                detallesFacturas.Add(detalleFactura);
                contador++;
            }

            mensaje = mensajeDetalle;
            decimal costos = 0;
            mensajeDetalle = "";
            // Descontar stock y actualizar estados de prendas
            List<EstadosPrendas> estadosReservadas = VentasDatosEF.getEstadosReservadasPorNroVenta(nroVenta);
            if (estadosReservadas == null)
            {
                mensaje += "\nNo se encontraron las prendas reservadas por la venta";
                return false;
            }

            foreach (EstadosPrendas estado in estadosReservadas)
            {
                string mensajeStock = "";
                try
                {
                    decimal totalCosto = estado.DetallesPrendas.CostoPrenda * estado.CantidadEstado;
                    costos += totalCosto;
                } catch (Exception ex)
                {
                    mensajeDetalle += "\nError : " + ex.Message;
                }
                
                if (!PrendasDatosEF.borrarEstadoPrenda(estado, ref mensajeStock))
                {
                    mensajeDetalle += $"\n{mensajeStock}";
                }
            }

            if (!String.IsNullOrWhiteSpace(mensajeDetalle))
            {
                mensaje += mensajeDetalle;
                return false;
            }

            /*
            string actualizarEstados = VentasDatosEF.DescontarYActualizarEstados(detallesFacturas);
            if (!string.IsNullOrEmpty(actualizarEstados))
            */

            if (costos == 0)
            {
                mensaje = "Error al descontar los egresos financieros";
                return false;
            }
            detalleFinanciero.Fecha = DateTime.Now;
            detalleFinanciero.Egreso = costos;
            detalleFinanciero.Margen = detalleFinanciero.Ingreso - detalleFinanciero.Egreso;
            if (!VentasDatosEF.insertDetalleFinanciero(detalleFinanciero))
            {
                mensaje = "Error al registrar el movimiento financiero";
                return false;
            }

            libroDiario.TotalIngresos += detalleFinanciero.Ingreso;
            libroDiario.TotalEgresos += detalleFinanciero.Egreso;

            if (!VentasDatosEF.updateLibroDiario(libroDiario))

            {
                mensaje = "Error al sumar los movimientos financieros";
                return false;
            }

            string estadoNuevo = envio ? "Envio Pendiente" : "Entregada";
            string estadoFinal = VentasDatosEF.CambiarEstadoVenta(venta, estadoNuevo);
            if (!String.IsNullOrWhiteSpace(estadoFinal))
            {
                mensaje = "Error en el cambio de estado de la venta " + estadoFinal;
                return false;
            }

            mensaje = "Factura registrada y estado de stock actualizado con éxito.";
            return true;
        }


        public static bool entregarVentaConEnvio(Ventas? venta, ref string mensaje)
        {
            if (venta == null)
            {
                mensaje = "\nNo se envía una venta a entregar";
                return false;
            }
            if (venta.Estados == null)
            {
                mensaje = "\nLa venta a entregar tiene problema con los estados";
                return false;
            }

            string estado = VentasDatosEF.CambiarEstadoVenta(venta, "Entregada");
            if (!String.IsNullOrWhiteSpace(estado))
            {
                mensaje = "Error no se pudo proceder al cambio por los siguientes errores"+estado;
                return false;
            }
            return true;

        }

        public static bool descontarStockCobrado(int idEstadoPrenda, ref decimal costo, ref string mensaje)
        {
            if (idEstadoPrenda == 0)
            {
                mensaje = "No hay estado para descontar stock";
                return false;
            }

            EstadosPrendas? estadoPrenda = PrendasDatosEF.getEstadoPrendaPorId(idEstadoPrenda, ref mensaje);
            if (estadoPrenda == null)
            {
                return false;
            }
            if (estadoPrenda.Prendas == null)
            {
                mensaje = "Error al obttener la prenda genérica ligada al estado";
                return false;
            }
            if (estadoPrenda.DetallesPrendas == null)
            {
                mensaje = "Error al obtener la prenda ligada al estado";
                return false;
            }
            if (estadoPrenda.EstadosHistorias == null)
            {
                mensaje = "Error al obtener el registro de estados de la prenda";
                return false;
            }
            Estados? vendida = RingoDatosEF.getEstadoPorDescripcion("Vendida", "Prendas", ref mensaje);
            if (vendida == null)
            {
                mensaje = "Error al recuperar el estado de venta";
                return false;
            }

            costo += estadoPrenda.DetallesPrendas.CostoPrenda;
            costo *= estadoPrenda.CantidadEstado;
            if (estadoPrenda.EstadosHistorias.IdEstadoAnterior != null)
            {
                estadoPrenda.EstadosHistorias.IdEstadoActual = (int)estadoPrenda.EstadosHistorias.IdEstadoAnterior;
            }
            if (!PrendasNegocio.updateEstadoHistoria(vendida, estadoPrenda.EstadosHistorias, ref mensaje))
            {
                return false;
            }
            if (!PrendasNegocio.updateEstadoPrenda(estadoPrenda, ref mensaje))
            {
                return false;
            }
            return true;

        }

        public static FondosCajas? registrarFondoCajas(decimal monto, ref string mensaje) 
        {
            FondosCajas fondosCajas = new FondosCajas();
            fondosCajas.MontoFondo = monto;
            fondosCajas.FechaFondo = DateTime.Now;
            fondosCajas.IdResponsableCaja = (int)Llaves.EmpleadoUsuario.IdEmpleado;
            int id = VentasDatosEF.RegistrarFondoCajas(fondosCajas);
            if (id == 0)
            {
                return null;
            }
            fondosCajas.IdFondoCaja = id;

            /*
            string mensajeFinanzas = "";
            if (!registrarFinanzasFondoCajas(monto, ref mensajeFinanzas))
            {
                mensaje += mensajeFinanzas;
                return null;
            }
            */

            return fondosCajas;
        }

        public static bool registrarFinanzasFondoCajas(decimal monto, ref string mensaje)
        {
            //Poner fondo en los libros diarios
            LibrosDiarios? libroDiario = Llaves.LibroDiario;
            if (libroDiario == null)
            {
                Llaves.LibroDiario = RingoDatosEF.registrarLibroDiario(Llaves.EmpleadoUsuario);
                libroDiario = Llaves.LibroDiario;
            }
            if (libroDiario == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            if (libroDiario.IdLibroDiario == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            List<MediosPagos>? mediosDePago = VentasDatosEF.getMedioPago();
            if (mediosDePago == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            MediosPagos? efectivo = mediosDePago.FirstOrDefault(m => m.FormaPago == "Efectivo");
            if (efectivo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }

            DetallesLibrosDiarios detalle = new DetallesLibrosDiarios();
            detalle.IdLibroDiario = (int)libroDiario.IdLibroDiario;
            detalle.IdMedioPago = efectivo.IdMedioPago;
            detalle.Fecha = DateTime.Now;
            detalle.Ingreso = monto;
            detalle.Egreso = monto;
            detalle.Margen = detalle.Ingreso - detalle.Egreso;
            int idDetalle = VentasDatosEF.insertDetalleLibroDiario(detalle);
            if (idDetalle == 0)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }

            Facturas fondo = new Facturas();
            List<TiposFacturas>? tipos = VentasDatosEF.getTiposFacturas();
            if (tipos == null || tipos.Count == 0)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            TiposFacturas? tipo = tipos.FirstOrDefault();
            if (tipo == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            if (Llaves.Empresa == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            if (Llaves.Empresa.IdEmpresa == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            if (Llaves.EmpleadoUsuario == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            List<TarjetasEntidades>? tarjEnt = VentasDatosEF.getTarjetasEntidades();
            if (tarjEnt == null || tarjEnt.Count == 0)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            TarjetasEntidades? nula = tarjEnt.Where(t => t.Tarjeta == " -- " && t.Entidad == " -- ").FirstOrDefault();
            if (nula == null)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            fondo.NumeroFactura = "_FondoCajas";
            fondo.IdTipoFactura = (int)tipo.IdTipoFactura;
            fondo.IdEmpresa = (int)Llaves.Empresa.IdEmpresa;
            fondo.FechaFactura = DateTime.Now;
            fondo.IdMedioPago = (int)efectivo.IdMedioPago;
            fondo.IdTarjetaEntidad = nula.IdTarjetaEntidad;
            fondo.Total = monto;
            int id = VentasDatosEF.RegistrarFactura(fondo);
            if (id < 1)
            {
                mensaje = "Error al registrar movimientos financieros";
                return false;
            }
            return true;
        }

        public static bool volverPrendasAStock(List<DetallesVentas>? detallesVentas, string nroVenta, ref string mensaje)
        {
            if (detallesVentas == null)
            {
                mensaje = "Error al enviar las prendas a devolver el stock a la normalidad";
                return false;
            }
            string mensajeDetalle = "";
            int contador = 1;
            List<int> idEstadosAptas = new List<int>();

            foreach (DetallesVentas detalle in detallesVentas)
            {
                // Extraer el IdEstadosPrendas desde DescripcionProducto
                if (!string.IsNullOrEmpty(detalle.DescripcionProducto) && detalle.DescripcionProducto.StartsWith("E"))
                {
                    int startIndex = 1; // Después de "E"
                    int dashIndex = detalle.DescripcionProducto.IndexOf("-");
                    if (dashIndex > startIndex)
                    {
                        string idEstadosPrendasStr = detalle.DescripcionProducto.Substring(startIndex, dashIndex - startIndex).Trim();
                        if (int.TryParse(idEstadosPrendasStr, out int idEstadosPrendas))
                        {
                            idEstadosAptas.Add(idEstadosPrendas); // Agregar a la lista
                            //Agrego el stock al estado prenda
                            EstadosPrendas? estado = PrendasDatosEF.getEstadoPrendaPorId(idEstadosPrendas, ref mensajeDetalle);
                            int exito = 0;
                            if (estado != null)
                            {
                                estado.CantidadEstado += detalle.Cantidad;
                                exito = PrendasDatosEF.updateEstadosPrendas(estado, ref mensajeDetalle);
                            }
                            if (exito < 1)
                            {
                                mensajeDetalle += "\nError al sumar stock al estado prenda";
                            }
                        }
                        else
                        {
                            mensajeDetalle += $"\nError al obtener el estado a modificar del detalle n°{contador}";
                        }
                    }
                    else
                    {
                        mensajeDetalle += $"\nError al obtener el estado a modificar del detalle n°{contador}";
                    }
                }
                else
                {
                    mensajeDetalle += $"\nError al obtener el estado a modificar del detalle n°{contador}";
                }

                contador++;
            }
            
            mensaje = mensajeDetalle;
            if (idEstadosAptas.Count == 0)
            {
                return false;
            }

            mensajeDetalle = "";
            
            List<EstadosPrendas> estadosPrendas = new();
            foreach (int id in idEstadosAptas)
            {
                EstadosPrendas? estado = PrendasDatosEF.getEstadoPrendaPorId(id, ref mensajeDetalle);
                if (estado != null)
                {
                    estadosPrendas.Add(estado);
                } else
                {
                    mensajeDetalle += $"\nEl estado de prenda con id {id} no se puede recuperar";
                    mensaje += mensajeDetalle;
                }
            }
            if (estadosPrendas.Count == 0)
            {
                return false;
            }

            List<EstadosPrendas> estadosReservadas = VentasDatosEF.getEstadosReservadasPorNroVenta(nroVenta);
            if (estadosReservadas == null)
            {
                mensaje += "\nNo se encontraron las prendas reservadas por la venta";
                return false;
            }

            foreach (EstadosPrendas estado in estadosReservadas)
            {
                string mensajeStock = "";
                Prendas p = estado.Prendas;
                p.Cantidad += estado.CantidadEstado;

                DetallesPrendas d = estado.DetallesPrendas;
                d.CantidadPrenda += estado.CantidadEstado;

                if (PrendasDatosEF.updatePrenda(p, ref mensajeStock) < 1)
                {
                    mensajeDetalle += $"\n{mensajeStock}";
                }
                mensajeStock = "";
                if (PrendasDatosEF.updateDetallePrenda(d, ref mensajeStock) < 1)
                {
                    mensajeDetalle += $"\n{mensajeStock}";
                }

                if (!PrendasDatosEF.borrarEstadoPrenda(estado, ref mensajeStock))
                {
                    mensajeDetalle += $"\n{mensajeStock}";
                }
            }

           
            return String.IsNullOrWhiteSpace(mensaje);
        }


        public static bool setMontoFondoCajas(FondosCajas? fondo)
        {
            if (fondo == null)
            {
                return false;
            }
            return VentasDatosEF.ingresarDineroACaja(fondo);
        }
    }
}
