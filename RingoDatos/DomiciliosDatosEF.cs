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
    public class DomiciliosDatosEF
    {
        static RingoDbContext RingoContext;


        //Consultas
        public static List<Ciudades>? CiudadesGet ()
        {
            List<Ciudades>? ciudades = new List<Ciudades>();
            RingoContext = new RingoDbContext();
            if (RingoContext.Ciudades == null)
                return null;
            ciudades = (from ciudad in RingoContext.Ciudades orderby ciudad.NombreCiudad select ciudad).ToList();
            
            return ciudades;
        }

        public static List<Domicilios>? DomiciliosPorPersona(Personas p)
        {
            List<Domicilios>? domicilios = new();
            RingoContext = new RingoDbContext();
            if (RingoContext.Domicilios == null)
                return null;
            domicilios = RingoContext.Domicilios.Include("Ciudades.Provincias").Where(d => d.IdPersona != null && d.IdPersona == p.IdPersona).Include("Barrios").ToList();
            if (domicilios.Count == 0)
                return null;
            return domicilios;
        }

        public static Domicilios? DomicilioPorId(int? id)
        {
            if (id == null)
                return null;


            Domicilios? domicilio = new();
            try
            {
                RingoContext = new RingoDbContext();
                domicilio = RingoContext.Domicilios.Where(d => d.IdDomicilio == id).FirstOrDefault();
            }
            catch (Exception) { }

            return domicilio;
        }

        public static List<Barrios>? BarriosPorCiudad(Ciudades? c)
        {
            if (c == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Barrios == null)
                return null;
            List<Barrios>? barrios = new();
            barrios = RingoContext.Barrios.Where(b => b.IdCiudad == c.IdCiudad).OrderBy(b => b.NombreBarrio).ToList();
            if (barrios == null || barrios.Count == 0)
                return null;
            return barrios;
        }

        public static Barrios? getGenericos()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Barrios == null || RingoContext.Ciudades == null || RingoContext.Provincias == null)
            {
                return null;
            }
            Barrios? generico = RingoContext.Barrios.Include("Ciudades.Provincias").FirstOrDefault(b => b.NombreBarrio == "---");
            Ciudades ciudad = new Ciudades();
            ciudad.NombreCiudad = "---";
            Provincias provincia = new Provincias();
            provincia.NombreProvincia = "---";
            if (generico != null)
            {
                if (generico.Ciudades != null)
                {
                    if (generico.Ciudades.Provincias == null)
                    {
                        Provincias? existeP = RingoContext.Provincias.FirstOrDefault(p => p.NombreProvincia == "---");
                        if (existeP == null)
                        {
                            int idProv = InsertProvincia(provincia);
                            if (idProv == 0)
                            {
                                return null;
                            }
                            provincia.IdProvincia = idProv;
                        } else
                        {
                            provincia = existeP;
                            ciudad.IdProvincia = (int)existeP.IdProvincia;
                        }
                        
                        generico.Ciudades.Provincias = provincia;
                    }
                    return generico;
                } else
                {
                    Provincias? existeP = RingoContext.Provincias.FirstOrDefault(p => p.NombreProvincia == "---");
                    if (existeP == null)
                    {
                        int idProv = InsertProvincia(provincia);
                        if (idProv == 0)
                        {
                            return null;
                        }
                        provincia.IdProvincia = idProv;
                        ciudad.IdProvincia = idProv;
                    }
                    else
                    {
                        provincia = existeP;
                        ciudad.IdProvincia = (int)existeP.IdProvincia;
                    }
                                        
                    int idCiudad = InsertCiudad(ciudad);
                    if (idCiudad == 0)
                    {
                        return null;
                    }
                    ciudad.Provincias = provincia;
                    generico.IdCiudad = idCiudad;
                    updateBarrio(generico);
                    generico.Ciudades = ciudad;
                    return generico;
                }
            } else
            {
                generico = new Barrios();
                generico.NombreBarrio = "---";
                Provincias? existeP = RingoContext.Provincias.FirstOrDefault(p => p.NombreProvincia == "---");
                if (existeP == null)
                {
                    int idProv = InsertProvincia(provincia);
                    if (idProv == 0)
                    {
                        return null;
                    }
                    provincia.IdProvincia = idProv;
                    ciudad.IdProvincia = idProv;
                }
                else
                {
                    provincia = existeP;
                    ciudad.IdProvincia = (int)existeP.IdProvincia;
                }
                Ciudades? existeC = RingoContext.Ciudades.Include("Provincias").FirstOrDefault(c => c.NombreCiudad == "---");
                if (existeC == null)
                {
                    int idCiudad = InsertCiudad(ciudad);
                    if (idCiudad == 0)
                    {
                        return null;
                    }
                    ciudad.IdCiudad = idCiudad;
                } else if (existeC.IdProvincia != provincia.IdProvincia)
                {
                    int idCiudad = InsertCiudad(ciudad);
                    if (idCiudad == 0)
                    {
                        return null;
                    }
                    ciudad.IdCiudad = idCiudad;
                } else
                {
                    ciudad = existeC;
                }
                ciudad.IdProvincia = (int)provincia.IdProvincia;
                ciudad.Provincias = provincia;
                generico.IdCiudad = (int)ciudad.IdCiudad;
                int idBarrio = insertBarrio(generico);
                generico.IdBarrio = idBarrio;
                generico.Ciudades = ciudad;
            }
            return generico;
        }

        public static int insertBarrio(Barrios? barrio)
        {
            if (barrio == null)
            {
                return 0;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.Barrios == null)
            {
                return 0;
            }
            Barrios barrioNuevo = new Barrios();
            barrioNuevo.IdCiudad = barrio.IdCiudad;
            barrioNuevo.NombreBarrio = barrio.NombreBarrio;
            RingoContext.Barrios.Add(barrioNuevo);
            int exito = RingoContext.SaveChanges();
            if (exito < 1)
            {
                return 0;
            }
            return (int)barrioNuevo.IdBarrio; 

        }

        public static bool updateBarrio(Barrios? barrio)
        {
            if (barrio == null)
            {
                return false;
            }
            RingoContext = new RingoDbContext();
            if (RingoContext.Barrios == null)
            {
                return false;
            }

            Barrios? ba = RingoContext.Barrios.FirstOrDefault(b => b.IdBarrio == barrio.IdBarrio);
            if (ba == null)
            {
                return false;
            }
            ba.IdCiudad = barrio.IdCiudad;
            barrio.NombreBarrio = barrio.NombreBarrio;
            RingoContext.Barrios.Update(ba);
            int exito = RingoContext.SaveChanges();
            return exito > 0;
        }


        public static List<Barrios>? BarrioTodos()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Barrios == null)
            {
                return null;
            }

            List<Barrios>? barrios = RingoContext.Barrios.OrderBy(b => b.NombreBarrio).ToList();
            if (barrios == null || barrios.Count == 0)
            {
                return null;
            }
            return barrios;
        }

        public static List<Ciudades>? CiudadesPorProvincia(Provincias? p)
        {
            if (p == null)
                return null;
            if (p.IdProvincia == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Ciudades == null)
                return null;
            List<Ciudades>? ciudades = new();
            ciudades = RingoContext.Ciudades.Where(c => c.IdCiudad != null 
                        && c.IdProvincia == p.IdProvincia).OrderBy(c => c.NombreCiudad).ToList();
            if (ciudades == null || ciudades.Count == 0)
                return null;
            return ciudades;
        }

        public static List<Ciudades>? CiudadesTodas()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Ciudades == null)
                return null;
            List<Ciudades>? ciudades = RingoContext.Ciudades.OrderBy(c => c.NombreCiudad).ToList();
            if (ciudades == null || ciudades.Count == 0)
                return null;
            return ciudades;
        }

        public static List<Provincias>? Provincias()
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Provincias == null)
                return null;
            List<Provincias>? provincias = new();
            provincias = RingoContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
            if (provincias == null ||  provincias.Count == 0)
                return null;
            return provincias;
        }

        public static Ciudades? CiudadPorDomicilio(Domicilios? d)
        {
            if (d == null)
                return null;

            Ciudades? ciudad = new();
            try
            {
                RingoContext = new RingoDbContext();
                ciudad = RingoContext.Ciudades.Where(c => d.IdCiudad != null && c.IdCiudad == d.IdCiudad).FirstOrDefault();
            }
            catch (Exception) { }

            return ciudad;
        }

        public static Provincias? ProvinciaPorCiudad (Ciudades? c)
        {
            if (c == null)
                return null;
            RingoContext = new RingoDbContext();
            if (RingoContext.Provincias == null || RingoContext.Ciudades == null)
                return null;
            Provincias? provincia = new();
            provincia = RingoContext.Provincias.Where(p => p.IdProvincia == c.IdProvincia).FirstOrDefault();
            return provincia;
        }

        //Registros
        public static int InsertProvincia (Provincias? p)
        {
            if (p == null)
                return 0;
            if (RingoContext.Provincias == null)
                return 0;
            RingoContext = new RingoDbContext();
            p.IdProvincia = null;
            RingoContext.Provincias.Add(p);
            RingoContext.SaveChanges();
            if (p.IdProvincia == null)
                return 0;

            return (int)p.IdProvincia;
        }

        public static int InsertCiudad(Ciudades? c)
        {
            if (c == null)
                return 0;
            if (RingoContext.Ciudades == null)
                return 0;
            RingoContext = new RingoDbContext();
            c.IdCiudad = null;
            RingoContext.Ciudades.Add(c);
            RingoContext.SaveChanges();
            if (c.IdCiudad == null)
                return 0;

            return (int)c.IdCiudad;
        }

        public static int InsertDomicilio(Domicilios? d)
        {
            if (d == null)
                return 0;
            RingoContext = new RingoDbContext();
            if (RingoContext.Domicilios == null)
                return 0;
            d.IdDomicilio = null;
            int id = 0;
            if (d.IdCiudad == null)
                id = InsertCiudad(d.Ciudades);
            else
                id = (int)d.IdCiudad;

            if (id > 0)
            {
                if (d.Barrios != null)
                {
                    d.Barrios.IdCiudad = id;
                    d.Barrios.Ciudades = null;
                }
                d.IdCiudad = id;  
            } else
            {
                d.Barrios = null;
                d.IdCiudad = null;
                d.IdBarrio = null;
                d.Ciudades = null;
            }

            RingoContext.Domicilios.Add(d);
            RingoContext.SaveChanges();
            if (d.IdDomicilio == null)
                return 0;

            return (int)d.IdDomicilio;
        }

        //updates
        public static List<Domicilios>? DomiciliosAEliminar(List<Domicilios>? list)
        {
            if (list == null || list.Count == 0)
                return null;

            using var RingoContext = new RingoDbContext();
            if (RingoContext.Domicilios == null)
                return null;

            int idPer = (int)list[0].IdPersona;
            var domicilios = RingoContext.Domicilios.Where(d => d.IdPersona == idPer).ToList();
            if (domicilios == null || domicilios.Count == 0)
                return null;

            var eliminar = domicilios.Where(d => !list.Any(e => e.IdDomicilio != null && e.IdDomicilio == d.IdDomicilio)).ToList();
            if (eliminar == null || eliminar.Count == 0)
                return null;
            return eliminar;
        }

        public static int EliminarDomicilios(List<Domicilios> list)
        {
            RingoContext = new RingoDbContext();
            if (RingoContext.Domicilios == null)
                return 0;
            RingoContext.RemoveRange(list);
            RingoContext.SaveChanges();
            return list.Count;
        }

        public static int EliminarDomicilio(int domicilioId)
        {
            using (var RingoContext = new RingoDbContext())
            {
                var domicilio = RingoContext.Domicilios.Find(domicilioId);
                if (domicilio == null)
                    return 0;

                RingoContext.Remove(domicilio);
                RingoContext.SaveChanges();
                return 1;
            }
        }




        public static bool UpdateDomicilio(Domicilios? d)
        {
            if (d == null)
                return false;
            RingoContext = new RingoDbContext();
            if (RingoContext.Domicilios == null || RingoContext.Ciudades == null || RingoContext.Barrios == null)
                return false;
            int id = 0;
            if (d.IdDomicilio == null)
                id = InsertDomicilio(d);
            if (id > 0)
                return true;
            
            var domicilio = RingoContext.Domicilios.FirstOrDefault(dom => dom.IdDomicilio == d.IdDomicilio);
            if (domicilio == null)
                return false;
            domicilio.Calle = d.Calle;
            domicilio.Altura = d.Altura;
            domicilio.Piso = d.Piso;
            domicilio.Departamento = d.Departamento;
            domicilio.ObservacionesBarrio = d.ObservacionesBarrio;
            domicilio.IdBarrio = d.IdBarrio;
            domicilio.IdCiudad = d.IdCiudad;
            domicilio.Barrios = d.Barrios;
            domicilio.Ciudades = d.Ciudades;
            domicilio.IdPersona = d.IdPersona;
            domicilio.IdCiudad = d.IdCiudad;
            domicilio.Ciudades = d.Ciudades;

            if (domicilio.Ciudades != null)
            {
                id = 0;
                Ciudades ciudad = domicilio.Ciudades;
                id = InsertCiudad(ciudad);
                if (id > 0)
                {
                    domicilio.IdCiudad = id;
                    domicilio.Ciudades = null;
                }
            }
            domicilio.IdBarrio = d.IdBarrio;
            domicilio.Barrios = d.Barrios;
            if (domicilio.Barrios != null)
            {
                if (domicilio.IdCiudad != null)
                    domicilio.Barrios.IdCiudad = (int)domicilio.IdCiudad;
                else
                    domicilio.Barrios = null;
            }

            
            RingoContext.SaveChanges();
            return true;

        }
    }
}
