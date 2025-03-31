using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class DomiciliosMetodos
    {
        //Consulta
        public static Domicilios? DomicilioPorId(int? id)
        {
            if (id == null)
                return null;
            Domicilios? domicilio = new();
            domicilio = DomiciliosDatosEF.DomicilioPorId(id);
            return domicilio;
        }

        public static Barrios? getGenericosDomicilios()
        {
            return DomiciliosDatosEF.getGenericos();
        }

        public static List<Ciudades>? Ciudades()
        {
            List<Ciudades>? ciudades = new List<Ciudades>();
            ciudades = DomiciliosDatosEF.CiudadesGet();
            return ciudades;
        }

        public static List<Provincias>? ProvinciasTodas ()
        {
            List<Provincias>? provincias = new();
            provincias = DomiciliosDatosEF.Provincias();
            return provincias;
        }
        
        public static List<Ciudades>? CiudadesTodas()
        {
            return DomiciliosDatosEF.CiudadesTodas();
        }

        public static List<Barrios>? BarriosTodos()
        {
            return DomiciliosDatosEF.BarrioTodos();
        }

        
        public static List<Ciudades>? CiudadesPorProvincia (Provincias p)
        {
            List<Ciudades>? ciudades = new();
            ciudades = DomiciliosDatosEF.CiudadesPorProvincia(p);
            return ciudades;
        }

        public static List<Domicilios>? DomiciliosPersona (Personas p)
        {
            if (p == null)
                return null;
            if (p.IdPersona == null)
                return null;
            List<Domicilios>? domicilios = new();
            domicilios = DomiciliosDatosEF.DomiciliosPorPersona(p);
            return domicilios;
        }

        public static Ciudades? CiudadPorDomicilio (Domicilios d)
        {
            if (d == null)
                return null;
            Ciudades? ciudad = new();
            ciudad = DomiciliosDatosEF.CiudadPorDomicilio(d);
            return ciudad;
        }

        public static List<Barrios>? BarriosPorCiudad (Ciudades? c)
        {
            if (c == null)
                return null;
            List<Barrios>? barrios = new();
            barrios = DomiciliosDatosEF.BarriosPorCiudad(c);
            return barrios;
        }

        //Insert

        public static int InsertCiudad(Ciudades? c)
        {
            if (c == null || c.IdCiudad > 0)
                return 0;

            return DomiciliosDatosEF.InsertCiudad(c);
        }

        public static int InsertDomicilio(Domicilios? d)
        {
            if (d == null || d.IdDomicilio > 0)
                return 0;
            Domicilios? dom = new();
            dom = DomicilioCorregido(d);
            return DomiciliosDatosEF.InsertDomicilio(dom);
        }

        //Control
        public static Domicilios? DomicilioCorregido (Domicilios? d)
        {
            if (d == null)
                return null;
            if (d.IdBarrio != null)
                d.Barrios = null;
            if (d.IdCiudad != null)
                d.Ciudades = null;
            if (d.Barrios != null)
            {
                if (d.IdCiudad != null)
                    d.Barrios.IdCiudad = (int)d.IdCiudad;
                d.Barrios.Ciudades = null;
            }
            if (d.Ciudades != null)
                d.Ciudades.Provincias = null;
            return d;
        }


        //Modificacion
        public static List<string>? UpdateDomicilios (List<Domicilios>? d)
        {
            if (d == null || d.Count == 0)
                return null;
            List<string>? resultados = new();
            List<Domicilios>? eliminar = new();
            eliminar = DomiciliosDatosEF.DomiciliosAEliminar(d);
            int eliminados = 0;
            if (eliminar != null)
                eliminados = DomiciliosDatosEF.EliminarDomicilios(eliminar);
            string mensajeEliminados = "";
            if (eliminados > 0)
            {
                mensajeEliminados = "\nDomicilios eliminados: " + eliminados;
            }
            for (int i = 0; i < d.Count; i++)
            {
                Domicilios? dom = DomicilioCorregido(d[i]);
                if (DomiciliosDatosEF.UpdateDomicilio(dom))
                    resultados.Add("\nDomicilio "+(i+1)+" modificado correctamemte");
                else
                    resultados.Add ("\nDomicilio " + (i + 1) + " no se pudo modificar");
            }
            resultados.Add(mensajeEliminados);
            return resultados;
        }
    }
}
