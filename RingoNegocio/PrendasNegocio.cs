using iText.Kernel.Pdf.Canvas.Wmf;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Win32;
using RingoDatos;
using RingoEF;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RingoNegocio
{
    public class PrendasNegocio
    {
        public static List<Prendas>? Get(Prendas p)
        {
            return PrendasDatosEF.Get(p);
        }

        public static void editarPrenda(DetallesPrendas det)
        {
            PrendasDatosEF.editarPrenda(det);
        }

        public static string codigoSugerido()
        {
            string codigo = "000000";
            codigo = PrendasDatosEF.codigoSugerido();
            return codigo;
        }
        public static List<Proveedores> getProveedores()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            proveedores = PrendasDatosEF.getProveedores();
            return proveedores ;
        }
        public static List<Talles>? getTalles()
        {
            List<Talles>? talles = new();
            talles = PrendasDatosEF.getTalles();
            
            return talles;
        }
        public static Prendas? VerificarPrendas(Prendas p)
        {
            Prendas? prenda = new();
            prenda = PrendasDatosEF.VerificarPrenda(p);
            return prenda;
        }

        public static List<Telas>? GetTelas()
        {
            List<Telas>? resultado = new();
            resultado = PrendasDatosEF.GetTelas();
            return resultado;
        }

        public static List<CategoriaSubCategoria>? GetCateSubCate()
        {
            List<CategoriaSubCategoria>? resultado = new();
            resultado = PrendasDatosEF.GetCategoriasSubCategorias();
            if (resultado == null || resultado.Count == 0)
                return null;
            return resultado;
        }

        public static List<CategoriasPrendas>? GetCategorias(List<CategoriaSubCategoria>? catsub)
        {
            if (catsub == null || catsub.Count == 0)
                return null;
            List<CategoriasPrendas>? resultado = new();
            resultado = catsub.Where(cs => cs.CategoriasPrendas != null).Select(cs => cs.CategoriasPrendas).Distinct().ToList();
            if (resultado == null || resultado.Count == 0)
                return null;
            return resultado.OrderBy(r => r.Categoria).ToList();
        }

        public static List<SubCategoriasPrendas>? GetSubCategorias(CategoriasPrendas? c, List<CategoriaSubCategoria>? catsub)
        {
            if (c == null || catsub == null || catsub.Count == 0)
                return null;
            if (c.IdCategoriaPrenda == null)
                return null;
            List<SubCategoriasPrendas>? resultado = new();
            resultado = catsub.Where(cs => cs.SubCategoriasPrendas != null && cs.IdCategoriaPrenda != null &&
                            c.IdCategoriaPrenda == cs.IdCategoriaPrenda).Select(cs => cs.SubCategoriasPrendas).ToList();
            if (resultado == null || resultado.Count == 0)
                return null;
            return resultado;
        }

        public static List<Estados>? GetEstadosIndolePrenda()
        {
            List<Estados>? estados = new();
            estados = RingoDatosEF.EstadosPorIndole("Prendas");
            if (estados.Count < 1)
                return null;
            return estados;
        }
        
        public static List<EstadosPrendas>? GetEstadosPrendas(Prendas? p, bool sinStock)
        {
            if (p == null)
                return null;
            List<EstadosPrendas>? estados = PrendasDatosEF.GetEstadosPrendas(p, sinStock);
            return estados;
        }

        public static List<EstadosPrendas>? GetEstadosPrendas(List<Prendas>? prendas, bool sinStock)
        {
            if (prendas == null)
                return null;
            List<EstadosPrendas>? estados = PrendasDatosEF.GetEstadosPrendas(prendas, sinStock);
            return estados;
        }

        public static EstadosHistorias? getEstadoHistoria(int id)
        {
            if (id == 0)
            {
                return null;
            }

            return PrendasDatosEF.getEstadoHistoria(id);
        }

        public static List<Prendas> getPrenda(string pren, bool stock)
        {
            List<Prendas>? list = new List<Prendas>();
            list = PrendasDatosEF.getPrenda(pren, stock);
            if (list == null || list.Count == 0)
                return new();
            return list;
        }

        public static List<DetallesPrendas> getDetallesPrenda(int? pren)
        {
            List<DetallesPrendas> list = new List<DetallesPrendas>();
            list = PrendasDatosEF.getDetallesPrenda(pren);
            return list;
        }

        public static List<DetallesPrendas>? getDetallesPrendaDesdeEstados(List<EstadosPrendas>? listEstados)
        {
            if (listEstados == null)
                return null;
            if (listEstados.Count == 0)
                return null;
            List<DetallesPrendas>? detalles = new List<DetallesPrendas>();
            detalles = PrendasDatosEF.getDetallesPrenda(listEstados[0].IdPrenda);
            if (detalles == null)
                return null;
            List<DetallesPrendas> resultado = new List<DetallesPrendas>();
            for (int i = 0; i < listEstados.Count; i++)
            {
                DetallesPrendas detalle = detalles.Where(d => d.IdDetallePrenda == listEstados[i].IdDetallePrenda).FirstOrDefault();
                detalle.CantidadPrenda = listEstados[i].CantidadEstado;
                resultado.Add(detalle);
            }
            return resultado.Count > 0 ? resultado : null;
        }

        //Métodos de Inserción

        public static int InsertarPrenda(Prendas? pren ,List<EstadosPrendas>? listEstados )
        {
            // El método devolverá -1 si la prenda no se puede registrar
            int resultado = -1;
            if (pren == null)
                return resultado;
            int idCat = 0;
            if (pren.IdCateSubCate == null)
            {
                //pren.IdCateSubCate = InsertarCateSubCate(pren.CategoriaSubCategoria);
            } else
            {
                pren.CategoriaSubCategoria = null;
            }
                

            if (pren.IdCateSubCate == 0)
                return resultado;

            resultado = PrendasDatosEF.Insert(pren);
            
            if(resultado < 1)
            {
                return resultado;
            }

            if(listEstados == null || listEstados.Count == 0)
            {
                pren.IdPrenda = resultado;
                int idEstado = insertEstadoGenerico(pren);
                return idEstado;
            }

            int cantEstados = listEstados.Sum(e => e.CantidadEstado);
            int diferencia = pren.Cantidad - cantEstados;
            if (diferencia > 0)
            {
                pren.IdPrenda = resultado;
                pren.Cantidad = diferencia;
                int idEstado = insertEstadoGenerico(pren);
            }

            for(int i = 0; i < listEstados.Count; i++)
            {
                listEstados[i].IdPrenda = resultado;
                listEstados[i].Prendas = null;
                if (listEstados[i].IdDetallePrenda != null)
                    listEstados[i].DetallesPrendas = null;
                if (listEstados[i].DetallesPrendas != null)
                {
                    listEstados[i].DetallesPrendas.IdPrenda = resultado;
                    listEstados[i].DetallesPrendas.Prenda = null;
                    listEstados[i].DetallesPrendas.IdDetallePrenda = null;
                    listEstados[i].DetallesPrendas.Talle = null;
                    listEstados[i].IdDetallePrenda = PrendasDatosEF.InsertDetallePenda(listEstados[i].DetallesPrendas);
                }
                if (listEstados[i].IdDetallePrenda != null)
                    listEstados[i].DetallesPrendas = null;

                int idEstado = PrendasDatosEF.RegistrarEstadoPrenda(listEstados[i]);
            }
            
            return resultado;
        }

        public static int insertEstadoGenerico(Prendas? p)
        {
            if (p == null)
            {
                return 0;
            }
            EstadosPrendas estadosPrendas = new EstadosPrendas();
            DetallesPrendas detallesPrendas = new DetallesPrendas();
            detallesPrendas.IdPrenda = (int)p.IdPrenda;
            detallesPrendas.CantidadPrenda = p.Cantidad;
            detallesPrendas.CodigoDetalle = p.CodigoPrenda + "00";
            detallesPrendas.PrecioVenta = (int)p.PrecioVenta;
            detallesPrendas.CostoPrenda = (int)p.Costo;
            int idDetalle = PrendasDatosEF.InsertDetallePenda(detallesPrendas);
            if (idDetalle < 1)
            {
                return idDetalle;
            }
            estadosPrendas.IdPrenda = (int)(p.IdPrenda);
            estadosPrendas.IdDetallePrenda = idDetalle;
            estadosPrendas.CantidadEstado = p.Cantidad;
            estadosPrendas.Observaciones = "Alta sin detalles";
            int idEstado = PrendasDatosEF.InsertEstadoPrendaGenerico(estadosPrendas);
            return idEstado;
        }

        public static int InsertarCateSubCate(CategoriaSubCategoria? cs)
        {
            if (cs == null)
                return 0;
            return PrendasDatosEF.InsertarCategoriaSubCategoria(cs);
        }

        public static int InsertEstado(Estados? estado)
        {
            int resultado = 0;
            if(estado == null)
                return resultado;
            resultado = RingoDatosEF.InsertEstado(estado);
            return resultado;
        }

        //Métodos de anomalías
        public static bool registrarAnomalia(Estados? estado, EstadosPrendas? estadosAnterior, EstadosPrendas? estadoNuevo, ref string mensaje)
        {
            //Chequeamos que no entren campos vacíos
            if (estado == null || estadosAnterior == null || estadoNuevo == null)
            {
                mensaje = "Falta información en el envío del formulario contacte al administrador";
                return false;
            }

            //Separo la prenda, el detalle y el estado historia para trabajar más comodo
            Prendas? prenda = estadosAnterior.Prendas;
            DetallesPrendas? detalle = estadosAnterior.DetallesPrendas;
            EstadosHistorias? historia = estadosAnterior.EstadosHistorias;

            //También que el estado que quiero modificar haya llegado correctamente
            if (historia == null)
            {
                mensaje = "Falta información sobre el estado de la prenda a modificar, contacte al administrador";
                return false;
            }
            if (prenda == null || detalle == null)
            {
                mensaje = "Falta información sobre la prenda a modificar, contacte al administrador";
                return false;
            }

            //separo la cantidad a modifocar para control
            int cantidad = estadoNuevo.CantidadEstado;

            //Distingo el estado anterior
            string? estadoViejo = historia.EstadoActual;
            if (estadoViejo == null)
            {
                estadoViejo = PrendasDatosEF.getEstadoPorId(historia.IdEstadoActual);
            }
            if (String.IsNullOrWhiteSpace(estadoViejo))
            {
                mensaje = "Problemas al obtener información sobre el estado de la prenda a modificar, contacte al administrador";
                return false;
            }

            //Preparo los movimientos de stock
            //Primero miro si estoy dando de baja una prenda lo resto
            if (estado.Estado == "No Apta" && estadoViejo != "No Apta")
            {
                prenda.Cantidad -= estadoNuevo.CantidadEstado;
                detalle.CantidadPrenda -= estadoNuevo.CantidadEstado;
            }

            //y si estoy volviendo a alta lo sumo
            if (estadoViejo == "No Apta" && estado.Estado != "No Apta")
            {
                prenda.Cantidad += estadoNuevo.CantidadEstado;
                detalle.CantidadPrenda += estadoNuevo.CantidadEstado;
            }

            //Si la cantidad es la totalidad de las prendas que había antes, directamente cambio el estado actual en estado historia
            if (cantidad == estadosAnterior.CantidadEstado)
            {
                if (!updateEstadoHistoria(estado, historia, ref mensaje))
                {
                    return false;
                }

                if (!updateEstadoPrenda(estadoNuevo, ref mensaje))
                {
                    return false;
                }
            }
            else
            {
                //Si no es igual hago los cambios correspondientes
                //Primero resto la cantidad del estado anterior
                estadosAnterior.CantidadEstado -= cantidad;
                if (!updateEstadoPrenda(estadosAnterior, ref mensaje))
                {
                    return false;
                }

                //Ahora busco todos los estados de la prenda detallada
                List<EstadosPrendas>? estadosActuales = PrendasDatosEF.GetEstadoPrenda(detalle);
                if (estadosActuales == null)
                {
                    //Si no hay es porque hay un error
                    mensaje = "Error al recuperar los estados de la prenda";
                    return false;
                }

                //inicio una variable que me va a decir si registro o no este estado
                bool registrar = true;

                //Busco si hay un estado con el mismo estado y falla que el que quiero registrar
                EstadosPrendas? estadoIgual = estadosActuales.Where(e => e.EstadosHistorias.IdEstadoActual == estado.IdEstado
                                                    && e.Observaciones == estadoNuevo.Observaciones).FirstOrDefault();

                if (estadoIgual != null)
                {
                    //Si lo hay sumo la cantidad al que ya existe
                    estadoIgual.CantidadEstado += cantidad;
                    if (!updateEstadoPrenda(estadoIgual, ref mensaje))
                    {
                        return false;
                    }
                }
                else
                {
                    //Si no hay tengo que registrarlo
                    //hago los cambios para que registre tanto el estado prenda como el historia y se lo envío adentro
                    estadoNuevo.IdEstadosPrendas = null;
                    historia.IdEstadoActual = (int)estado.IdEstado;
                    estadoNuevo.EstadosHistorias = historia;
                    estadoNuevo.Prendas = null;
                    estadoNuevo.DetallesPrendas = null;
                    int id = PrendasDatosEF.RegistrarEstadoPrenda(estadoNuevo);
                    if (id == 0)
                    {
                        mensaje = "Error al registrar el nuevo estado";
                        return false;
                    }
                }
            }

            detalle.Prenda = prenda;

            //Ahora actualizo la prenda y el detalle para que queden bien con el stock
            if (!actualizarStockPrenda(detalle, ref mensaje))
            {
                return false;
            }


            return true;
        }



        public static bool actualizarStockPrenda(DetallesPrendas? detalle, ref string mensaje)
        {
            if (detalle == null)
            {
                mensaje = "Problemas con el envío de información de la prenda";
                return false;
            }
            if (detalle.Prenda == null)
            {
                mensaje = "Problemas con el envío de información de la prenda genérica";
                return false;
            }

            int editadoPrenda = PrendasDatosEF.updatePrenda(detalle.Prenda, ref mensaje);
            int editadoDetalle = PrendasDatosEF.updateDetallePrenda(detalle, ref mensaje);

            if (editadoPrenda < 1)
            {
                mensaje = "Problemas la modificación de stock de la prenda genérica";
            }
            if (editadoDetalle < 1)
            {
                mensaje = "Problemas la modificación de stock de la prenda";
            }
            return String.IsNullOrWhiteSpace(mensaje);

        }

        public static bool updateEstadoHistoria(Estados? estadoNuevo, EstadosHistorias? historia, ref string mensaje)
        {
            if (estadoNuevo == null)
            {
                mensaje = "Cambio de estado vacío";
                return false;
            }

            if (estadoNuevo.IdEstado == null)
            {
                mensaje = "Cambio de estado imposible de acceder";
                return false;
            }

            if (historia == null)
            {
                mensaje = "Estado a modificar vacío";
                return false;
            }

            EstadosHistorias estadosHistorias = new EstadosHistorias();
            estadosHistorias.IdEstadoHistoria = historia.IdEstadoHistoria;
            estadosHistorias.IdEstadoAnterior = historia.IdEstadoActual;
            estadosHistorias.IdEstadoActual = (int)estadoNuevo.IdEstado;

            int modificado = PrendasDatosEF.updateEstadoHistoria(estadosHistorias, ref mensaje);

            return modificado > 0;
        }

        public static bool updateEstadoPrenda (EstadosPrendas? estadoNuevo, ref string mensaje)
        {
            if (estadoNuevo == null)
            {
                mensaje = "Estado de la prenda vacío";
                return false;
            }

            EstadosPrendas estadosPrendas = new EstadosPrendas();
            estadosPrendas.IdEstadosPrendas = estadoNuevo.IdEstadosPrendas;
            estadosPrendas.IdPrenda = estadoNuevo.IdPrenda;
            estadosPrendas.IdDetallePrenda = estadoNuevo.IdDetallePrenda;
            estadosPrendas.IdEstadoHistoria = estadoNuevo.IdEstadoHistoria;
            estadosPrendas.CantidadEstado = estadoNuevo.CantidadEstado;
            estadosPrendas.Observaciones = estadoNuevo.Observaciones;

            int exito = PrendasDatosEF.updateEstadosPrendas(estadosPrendas, ref mensaje);
            return exito > 0;
        }

        //Método oculto para regulaizar el stock
        public static string limpiarStock()
        {
            string mensaje = "Limpieza de prendas iniciada Resultados:";

            List<Prendas>? prendas = PrendasDatosEF.getPrenda("", true);
            if (prendas == null || prendas.Count == 0)
            {
                return mensaje + " No se pudieron encontrar prendas";
            }

            string resultados = limpiarPrendas(prendas);
            if (String.IsNullOrWhiteSpace(resultados))
            {
                mensaje += "\n Sin problemas";
            } else
            {
                mensaje += resultados;
            }

            return mensaje;
        }

        public static string limpiarPrendas(List<Prendas> prendas)
        {
            string resultados = "";

            List<Estados>? estados = RingoDatosEF.EstadosPorIndole("Prendas");
            if (estados == null || estados.Count == 0)
            {
                return "\n Error grave, no se encuentran los estados de indole Prendas";
            }

            Estados? Apta = estados.FirstOrDefault(e => e.Estado == "Apta");
            if (Apta == null)
            {
                return "\n Error grave, no se encuentra el estado Apta de indole Prendas";
            }

            Estados? Outlet = estados.FirstOrDefault(e => e.Estado == "Outlet");
            if (Outlet == null)
            {
                return "\n Error grave, no se encuentra el estado Outlet de indole Prendas";
            }

            List<int> idsEstados = new List<int>();
            idsEstados.Add((int)Apta.IdEstado);
            idsEstados.Add((int)Outlet.IdEstado);

            foreach (Prendas p in prendas)
            {
                List<DetallesPrendas>? detalles = PrendasDatosEF.getDetallesPrenda(p.IdPrenda);
                if (detalles == null || detalles.Count == 0)
                {
                    int result = insertEstadoGenerico(p);
                    if (result < 1)
                    {
                        resultados += $"\nProblema grave con la prenda codigo = {p.CodigoPrenda} / No se pudo insertar estado genérico";
                    } else
                    {
                        resultados += $"\nEstado genérico creado para la prenda código = {p.CodigoPrenda}";
                    }
                    continue;
                }
                foreach (DetallesPrendas detalle in detalles)
                {
                    if (detalle.CantidadPrenda < 0)
                    {
                        detalle.CantidadPrenda = 0;
                        string detNegativo = "";
                        int res = PrendasDatosEF.updateDetallePrenda(detalle, ref detNegativo);
                        if (res < 1)
                        {
                            resultados += "\n --" + detNegativo;
                        } else
                        {
                            resultados += "\n --Corregido stock negativo";
                        }
                    }
                }
                int diferencia = p.Cantidad - detalles.Sum(d => d.CantidadPrenda);
                if (diferencia != 0)
                {
                    resultados += $"\nProblemas de stock en prenda con el codigo = {p.CodigoPrenda}";
                    resultados += limpiarDetallesPrendas(detalles, p, diferencia);
                }
                resultados += "\n--Limpieza de estados iniciada";
                string estadosModificados = limpiarEstadosPrendas(detalles, idsEstados);
                resultados += String.IsNullOrWhiteSpace(estadosModificados) ? "\nNo hay estados con problemas" : estadosModificados;
            }

            return resultados;
        }

        public static string limpiarDetallesPrendas(List<DetallesPrendas> detallesPrendas, Prendas p, int diferencia)
        {
            string resultados = "";
            if (detallesPrendas.Count == 0)
            {
                return "\n  -Problema al limpiar detalles de prenda, no viaja información";
            }
            if (diferencia < 0)
            {
                p.Cantidad += diferencia;
                int prendaModificada = PrendasDatosEF.updatePrenda(p, ref resultados);
                return "\n  -Se intentó modificar la prenda con resultado: " + resultados;
            }

            DetallesPrendas? detalle = detallesPrendas.FirstOrDefault(ep => ep.CantidadPrenda >= diferencia);
            if (detalle == null)
            {
                return "Error fatal";
            }

            detalle.CantidadPrenda += diferencia;
            int detalleModificado = PrendasDatosEF.updateDetallePrenda(detalle, ref resultados);
            return $"\n  -Se intentó modificar el detalle de prenda codigo = {detalle.CodigoDetalle} con resultado: " + resultados;
        }

        public static string limpiarEstadosPrendas(List<DetallesPrendas> detallesPrendas, List<int> idsEstados)
        {
            string mensaje = "";
                        
            foreach (DetallesPrendas detalle in detallesPrendas)
            {
                List<EstadosPrendas>? estadosPrendas = PrendasDatosEF.GetEstadoPrenda(detalle);
                if (estadosPrendas == null || estadosPrendas.Count == 0)
                {
                    EstadosPrendas estado = new EstadosPrendas();
                    estado.IdDetallePrenda = detalle.IdDetallePrenda;
                    estado.IdPrenda = detalle.IdPrenda;
                    estado.CantidadEstado = detalle.CantidadPrenda;
                    int idEstadoPrenda = PrendasDatosEF.InsertEstadoPrendaGenerico(estado);
                    string error = "";
                    EstadosPrendas? estadoP = PrendasDatosEF.getEstadoPrendaPorId(idEstadoPrenda, ref error);
                    if (estadoP == null)
                    {
                        mensaje += error;
                        continue;
                    }
                    mensaje += $"\n  --El detalle con código = {detalle.CodigoDetalle} No tenía estado, Se registro el estado id = {idEstadoPrenda}";
                    estadosPrendas = new List<EstadosPrendas>();
                    estadosPrendas.Add(estadoP);
                }
                
                List<EstadosPrendas>? estadosStock = estadosPrendas.Where(ep => ep.EstadosHistorias != null && idsEstados.Contains(ep.EstadosHistorias.IdEstadoActual)).ToList();
                if (estadosStock ==  null || estadosStock.Count == 0)
                {
                    EstadosPrendas estado = new EstadosPrendas();
                    estado.IdDetallePrenda = detalle.IdDetallePrenda;
                    estado.IdPrenda = detalle.IdPrenda;
                    estado.CantidadEstado = detalle.CantidadPrenda;
                    int idEstadoPrenda = PrendasDatosEF.InsertEstadoPrendaGenerico(estado);
                    string error = "";
                    EstadosPrendas? estadoP = PrendasDatosEF.getEstadoPrendaPorId(idEstadoPrenda, ref error);
                    if (estadoP == null)
                    {
                        mensaje += error;
                        continue;
                    }
                    mensaje += $"\n  --El detalle con código = {detalle.CodigoDetalle} No tenía estado Apta, Se registro el estado id = {idEstadoPrenda}";
                    continue;
                }
                foreach (EstadosPrendas estadosPrendasVer in estadosStock)
                {
                    if (estadosPrendasVer.CantidadEstado < 0)
                    {
                        estadosPrendasVer.CantidadEstado = Math.Abs(estadosPrendasVer.CantidadEstado);
                        string error = "";
                        EstadosPrendas estado = new EstadosPrendas();
                        estado.IdEstadosPrendas = estadosPrendasVer.IdEstadosPrendas;
                        estado.IdEstadoHistoria = estadosPrendasVer.IdEstadoHistoria;
                        estado.IdDetallePrenda = estadosPrendasVer.IdDetallePrenda;
                        estado.IdPrenda = estadosPrendasVer.IdPrenda;
                        estado.CantidadEstado = estadosPrendasVer.CantidadEstado;
                        estado.Observaciones = estadosPrendasVer.Observaciones;
                        int exito = PrendasDatosEF.updateEstadosPrendas(estado, ref error);
                    }
                }
                int cantidadEstadosStock = estadosStock.Sum(e => e.CantidadEstado);
                int diferencia = detalle.CantidadPrenda - cantidadEstadosStock;
                EstadosPrendas? estadoApta = estadosStock.Where(ep => ep.EstadosHistorias.EstadosActuales.Estado == "Apta").FirstOrDefault();
                string errores = "";
                if (diferencia > 0)
                {
                    if (estadoApta == null)
                    {
                        EstadosPrendas estado = new EstadosPrendas();
                        estado.IdDetallePrenda = detalle.IdDetallePrenda;
                        estado.IdPrenda = detalle.IdPrenda;
                        estado.CantidadEstado = detalle.CantidadPrenda;
                        int idEstadoPrenda = PrendasDatosEF.InsertEstadoPrendaGenerico(estado);
                        string error = "";
                        EstadosPrendas? estadoP = PrendasDatosEF.getEstadoPrendaPorId(idEstadoPrenda, ref error);
                        if (estadoP == null)
                        {
                            mensaje += error;
                            continue;
                        }
                        mensaje += $"\n  --El detalle con código = {detalle.CodigoDetalle} No tenía estado Apta, Se registro el estado id = {idEstadoPrenda}";
                        continue;
                    }
                    else
                    {
                        estadoApta.CantidadEstado += diferencia;
                        estadoApta.Prendas = null;
                        estadoApta.DetallesPrendas = null;
                        estadoApta.EstadosHistorias = null;
                        int exito = PrendasDatosEF.updateEstadosPrendas(estadoApta, ref errores);
                    }
                    if (String.IsNullOrWhiteSpace(errores))
                    {
                        errores = "\n  --Diferencias corregidas";
                    }
                    mensaje += errores;
                } 
                else if (diferencia < 0)
                {
                    diferencia = cantidadEstadosStock - detalle.CantidadPrenda;
                    EstadosPrendas? estadoDescontar = estadosStock.FirstOrDefault(ep => ep.CantidadEstado >= diferencia);
                    if (estadoDescontar == null)
                    {
                        return "Error fatal 2";
                    }
                    estadoDescontar.CantidadEstado -= diferencia;
                    estadoDescontar.Prendas = null;
                    estadoDescontar.DetallesPrendas = null;
                    estadoDescontar.EstadosHistorias = null;
                    int exito = PrendasDatosEF.updateEstadosPrendas(estadoDescontar, ref errores);
                    mensaje += errores;
                }
            }

            return mensaje;

        }

        //Método principal para modificar prendas
        public static bool updatePrendas(Prendas? prendaNueva, bool cambiaPrenda, bool cambiaPrecioVentaDetalles, bool cambiaCostoDetalles, List<EstadosPrendas>? modificar, List<EstadosPrendas>? registrar, List<EstadosPrendas>? eliminar, ref string mensaje)
        {
            mensaje = "";
            bool exito = true;
            string mens = "";

            //Intento actuar con los 3 listados primero y separo los booleanos
            bool exitoReg = insertDetallesModificacion(prendaNueva, registrar, ref mens);
            bool exitoMod = updateDetallesModificacion(prendaNueva, modificar, ref mens);
            bool exitoDel = deleteDetallesModificacion(prendaNueva, eliminar, ref mens);

            exito = exitoReg && exitoDel && exitoMod;

            //Busco los estados para actualizar los stocks 
            List<DetallesPrendas>? detalles = PrendasDatosEF.getDetallesPrenda((int)prendaNueva.IdPrenda);
            
            if (detalles == null || detalles.Count == 0)
            {
                mensaje += "\nError al traer prendas detalladas";
                return false;
            }

            List<Estados>? estados = RingoDatosEF.EstadosPorIndole("Prendas");
            if (estados == null || estados.Count == 0)
            {
                mensaje += "\n Error grave, no se encuentran los estados de indole Prendas";
                return false;
            }

            Estados? Apta = estados.FirstOrDefault(e => e.Estado == "Apta");
            if (Apta == null)
            {
                mensaje += "\n Error grave, no se encuentra el estado Apta de indole Prendas";
                return false;
            }

            Estados? Outlet = estados.FirstOrDefault(e => e.Estado == "Outlet");
            if (Outlet == null)
            {
                mensaje += "\n Error grave, no se encuentra el estado Outlet de indole Prendas";
                return false;
            }

            List<int> idsEstados = new List<int>();
            idsEstados.Add((int)Apta.IdEstado);
            idsEstados.Add((int)Outlet.IdEstado);

            int stockPrenda = 0;
            foreach (DetallesPrendas detalle in detalles)
            {
                if (cambiaCostoDetalles)
                {
                    detalle.CostoPrenda = (decimal)prendaNueva.Costo;
                }
                if (cambiaPrecioVentaDetalles)
                {
                    detalle.PrecioVenta = (decimal)prendaNueva.PrecioVenta;
                }
                int stockInicial = detalle.CantidadPrenda;
                List<EstadosPrendas>? estadosDetalle = PrendasDatosEF.GetEstadoPrenda(detalle);
                if (estadosDetalle == null || estadosDetalle.Count == 0)
                {
                    mensaje += "\nError al encontrar estados para la prenda detallada codigo = " + detalle.CodigoDetalle;
                    continue;
                }
                List<EstadosPrendas>? estadosParaStock = estadosDetalle.Where(ep => ep.CantidadEstado > 0 && ep.EstadosHistorias != null && idsEstados.Contains(ep.EstadosHistorias.IdEstadoActual)).ToList();
                if (estadosParaStock == null || estadosParaStock.Count == 0)
                {
                    detalle.CantidadPrenda = 0;
                } else
                {
                    detalle.CantidadPrenda = estadosParaStock.Sum(ep => ep.CantidadEstado);
                }
                int exitoDet = PrendasDatosEF.updateDetallePrenda(detalle, ref mens);
                if (exitoDet < 1)
                {
                    stockPrenda += stockInicial;
                    mensaje += "\n" + mens;
                    exito = false;
                } else
                {
                    stockPrenda += detalle.CantidadPrenda;
                } 
            }

            if (prendaNueva != null && cambiaPrenda)
            {
                prendaNueva.Cantidad = stockPrenda;
                int resultado = PrendasDatosEF.updatePrenda(prendaNueva, ref mens);
                if (resultado > 0)
                {
                    mensaje += "\nPrenda genérica modificada";
                }
                else
                {
                    exito = false;
                    mensaje += "\nError al modificar la prenda: " + mens;
                }
            }
            return exito;

        }

        public static bool insertDetallesModificacion(Prendas? prendaNueva, List<EstadosPrendas>? registrar, ref string mensaje)
        {
            if (registrar != null && registrar.Count > 0)
            {
                int errores = 0;
                foreach (EstadosPrendas estado in registrar)
                {
                    estado.DetallesPrendas.IdPrenda = (int)prendaNueva.IdPrenda;
                    int idDetalle = PrendasDatosEF.InsertDetallePenda(estado.DetallesPrendas);
                    if (idDetalle < 1)
                    {
                        mensaje += "\n--Error al registrar una prenda detallada";
                        errores++;
                    }
                    else
                    {
                        estado.IdDetallePrenda = idDetalle;
                        if (estado.IdPrenda == null || estado.IdPrenda == 0)
                        {
                            estado.IdPrenda = (int)prendaNueva.IdPrenda;
                        }
                        estado.DetallesPrendas = null;
                        estado.Prendas = null;
                        int idEstado = PrendasDatosEF.RegistrarEstadoPrenda(estado);
                        if (idEstado < 1)
                        {
                            mensaje += "\n--Error al registrar estado a la prenda detallada codigo = " + estado.DetallesPrendas.CodigoDetalle;
                            errores++;
                        }
                    }
                }
                if (errores > 0)
                {
                    return false;
                }
                else
                {
                    mensaje += "\n--Detalles registrados correctamente";
                    return true;
                }
            }
            return true;
        }

        public static bool updateDetallesModificacion(Prendas? prenda, List<EstadosPrendas>? modificar, ref string mensaje)
        {
            if (modificar != null && modificar.Count > 0)
            {
                
                int errores = 0;
                foreach (EstadosPrendas estado in modificar)
                {
                    estado.DetallesPrendas.IdPrenda = (int)prenda.IdPrenda;
                    string mens = "";
                    if (estado.EstadosHistorias != null)
                    {
                        estado.EstadosHistorias.EstadosActuales = null;
                        int exitoEH = PrendasDatosEF.updateEstadoHistoria(estado.EstadosHistorias, ref mens);
                        if (exitoEH < 1)
                        {
                            errores++;
                            mens += "\n--" + mens;
                        } else
                        {
                            mens = "";
                        }
                    }
                    int exitoEP = PrendasDatosEF.updateEstadosPrendas(estado, ref mens);
                    if (exitoEP < 1)
                    {
                        mensaje += "\n" + mens;
                        errores++;
                    } else
                    {
                        exitoEP = PrendasDatosEF.updateDetallePrenda(estado.DetallesPrendas, ref mens);
                    }
                    if (exitoEP < 1)
                    {
                        mensaje += "\n" + mens;
                        errores++;
                    }
                }
                if (errores > 0)
                {
                    return false;
                }
                else
                {
                    mensaje += "\n--Detalles modificados correctamente";
                    return true;
                }
            }
            return true;
        }

        public static bool deleteDetallesModificacion(Prendas? prenda, List<EstadosPrendas>? eliminar, ref string mensaje)
        {
            if (eliminar != null && eliminar.Count > 0)
            {

                int errores = 0;
                foreach (EstadosPrendas estado in eliminar)
                {
                    string mens = "";
                    
                    if (!PrendasDatosEF.borrarEstadoPrenda(estado, ref mens))
                    {
                        if (estado.EstadosHistorias != null)
                        {
                            Estados? noApta = RingoDatosEF.getEstadoPorDescripcion("No Apta", "Prendas", ref  mens);
                            if (noApta != null)
                            {
                                estado.EstadosHistorias.IdEstadoAnterior = estado.EstadosHistorias.IdEstadoActual;
                                estado.EstadosHistorias.IdEstadoActual = (int)noApta.IdEstado;
                            }
                            int exitoEH = PrendasDatosEF.updateEstadoHistoria(estado.EstadosHistorias, ref mens);
                            if (exitoEH < 1)
                            {
                                errores++;
                                mens += "\n--" + mens;
                            } else
                            {
                                estado.CantidadEstado = 0;
                            }
                            
                        }
                        int exitoEP = PrendasDatosEF.updateEstadosPrendas(estado, ref mens);
                        if (exitoEP < 1)
                        {
                            mensaje += "\n" + mens;
                            errores++;
                        }
                        
                    }
                    estado.DetallesPrendas.CantidadPrenda -= estado.CantidadEstado;
                    int exito = PrendasDatosEF.updateDetallePrenda(estado.DetallesPrendas, ref mens);
                    if (exito < 1)
                    {
                        mensaje += "\n" + mens;
                        errores++;
                    }
                }
                if (errores > 0)
                {
                    return false;
                }
                else
                {
                    mensaje += "\n--Detalles eliminados correctamente";
                    return true;
                }
            }
            return true;
        }
    }
}
