using RingoDatos;
using RingoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoNegocio
{
    public class ContactosMetodos
    {

        //Consultas
        
        public static List<RedesSociales>? redesSociales ()
        {
            List<RedesSociales>? redesSociales = new();
            redesSociales = ContactosDatosEF.RedesSociales();
            return redesSociales;
        }

        public static List<Contactos>? ContactosPorPersona  (Personas p)
        {
            if (p == null)
                return null;
            if (p.IdPersona == null)
                return null;
            List<Contactos>? contactos = new();
            contactos = ContactosDatosEF.ContactosPorPersona(p);
            return contactos;
        }

        //Inserts

        public static int InsertContacto(Contactos? c)
        {
            if (c == null)
                return 0;
            int id = 0;
            id = ContactosDatosEF.InsertContacto(c);
            return id;
        }

        //Update
        public static List<string>? UpdateContactos (List<Contactos>? c)
        {
            List<string>? resultados = new();
            if (c == null || c.Count == 0)
                return null;
            List<Contactos>? eliminar = new();
            eliminar = ContactosDatosEF.ContactosAEliminar(c);
            int eliminados = 0;
            if (eliminar != null && eliminar.Count > 0) 
                eliminados = ContactosDatosEF.EliminarContactos(eliminar);
            string mensajeEliminados = "";
            if (eliminados > 0)
            {
                mensajeEliminados = "\nContactos eliminados: " + eliminados;
            }
            for (int i = 0; i < c.Count; i++)
            {
                if (ContactosDatosEF.UpdateContacto(c[i]))

                    resultados.Add("\nContacto " + (i + 1) + " modificado correctamemte");
                else
                    resultados.Add("\nContacto " + (i + 1) + " no se pudo modificar");
            }
            resultados.Add(mensajeEliminados);
            return resultados;
        }

    }
}
