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
    public class ContactosDatosEF
    {
        public static RingoDbContext ringoContext = new RingoDbContext();

        //Consultas
        public static Contactos? ContactoPorId (int id)
        {
            ringoContext = new RingoDbContext();
            if (id < 1 || ringoContext.Contactos == null)
                return null;
            Contactos? contacto = ringoContext.Contactos.Where(c => c.IdContacto == id).FirstOrDefault();
            return contacto;
        }

        public static UsersRedesSociales? UsuarioRedesPorContacto (Contactos? c)
        {
            if (c == null)
                return null;
            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null || ringoContext.UsersRedesSociales == null)
                return null;
            UsersRedesSociales? usuario = new();
            usuario = (from user in ringoContext.UsersRedesSociales
                       join C in ringoContext.Contactos on user.IdUserRedSocial equals C.IdUserRedSocial
                       where c.IdUserRedSocial != null && c.IdUserRedSocial.Equals(user.IdUserRedSocial)
                       select user).FirstOrDefault();
            return usuario;
        }

        public static List<Contactos>? ContactosPorPersona(Personas? p)
        {
            
            List<Contactos>? contactos = new();
            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null)
                return null;
            contactos = ringoContext.Contactos.Include("UsersRedesSociales.RedesSociales").Where(c => c.IdPersona != null && c.IdPersona == p.IdPersona).ToList();
            if (contactos.Count == 0)
                return null;
            return contactos;
        }

        public static List<Contactos>? ContactosPorEmpresa(Empresas? e)
        {
            if (e == null)
                return null;

            List<Contactos>? contactos = new();
            try
            {
                ringoContext = new RingoDbContext();
                contactos = ringoContext.Contactos.Include("UsersRedesSociales").Where(c => c.IdEmpresa != null && c.IdEmpresa == e.IdEmpresa).ToList();
            }
            catch (Exception) { }

            return contactos;
        }

        public static List<Contactos>? ContactosPorSucursal(Sucursales? s)
        {
            if (s == null)
                return null;

            List<Contactos>? contactos = new();
            try
            {
                ringoContext = new RingoDbContext();
                contactos = ringoContext.Contactos.Include("UsersRedesSociales").Where(c => c.IdSucursal != null && c.IdSucursal == s.IdSucursal).ToList();
            }
            catch (Exception) { }

            return contactos;
        }

        public static List<RedesSociales>? RedesSociales()
        {
            List<RedesSociales>? redesSociales = new();
            ringoContext = new RingoDbContext();
            if (ringoContext.RedesSociales == null)
                return null;
            redesSociales = ringoContext.RedesSociales.Where(r => r.IdRedSocial != null).OrderBy(r => r.NombreRedSocial).ToList();
            return redesSociales;
        }

        public static RedesSociales? RedSocialPorContacto(Contactos c)
        {
            if (c == null)
                return null;
            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null || ringoContext.RedesSociales == null || ringoContext.UsersRedesSociales == null)
                return null;
            RedesSociales? redSocial = new();
            redSocial = (from R in ringoContext.RedesSociales
                         join U in ringoContext.UsersRedesSociales on R.IdRedSocial equals U.IdRedSocial
                         join C in ringoContext.Contactos on U.IdUserRedSocial equals C.IdUserRedSocial
                         where C.IdUserRedSocial != null select R).FirstOrDefault();
            return redSocial;
        }


        //Inserts
        public static int InsertRedSocial (RedesSociales? r)
        {
            if (r == null)
                return 0;
            ringoContext = new RingoDbContext();
            if (ringoContext == null || ringoContext.RedesSociales == null)
                return 0;
            r.IdRedSocial = null;
            ringoContext.RedesSociales.Add(r);
            ringoContext.SaveChanges();
            if (r.IdRedSocial == null)
                return 0;
            return (int)r.IdRedSocial;
        }

        public static int InsertUserRedSocial(UsersRedesSociales? u)
        {
            if (u == null)
                return 0;
            ringoContext = new RingoDbContext();
            if (ringoContext == null || ringoContext.RedesSociales == null || ringoContext.UsersRedesSociales == null)
                return 0;
            u.IdUserRedSocial = null;
            u.RedesSociales = null;
            ringoContext.UsersRedesSociales.Add(u);
            ringoContext.SaveChanges();
            if (u.IdUserRedSocial == null)
                return 0;
            return (int)u.IdUserRedSocial;
        }

        public static int InsertContacto(Contactos? c)
        {
            if (c == null)
                return 0;
            ringoContext = new RingoDbContext();
            if (ringoContext == null || ringoContext.Contactos == null)
                return 0;
            if (c.UsersRedesSociales != null)
                c.UsersRedesSociales.RedesSociales = null;
            c.IdContacto = null;
            ringoContext.Contactos.Add(c);
            ringoContext.SaveChanges();
            if (c.IdContacto == null)
                return 0;
            return (int)c.IdContacto;
        }


        public static int insertContactosProveedor(Contactos? contacto)
        {
            if (contacto == null)
            {
                return 0;
            }
            if (contacto.IdEmpresa == null)
            {
                return 0;
            }

            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null)
            {
                return 0;
            }

            ringoContext.Add(contacto);
            ringoContext.SaveChanges();
            if (contacto.IdContacto == null)
            {
                return 0;
            }
            return 1;
        }

        //Updates

        public static List<Contactos>? ContactosAEliminar(List<Contactos>? list)
        {
            if (list == null || list.Count == 0)
                return null;

            using var ringoContext = new RingoDbContext();

            if (ringoContext.Contactos == null)
                return null;
            int idPer = 0;
            idPer = list[0].IdPersona != null ? (int)list[0].IdPersona : 0;
            if (idPer == 0)
                return null;

            var contactosBD = ringoContext.Contactos
                .Where(c => c.IdPersona == idPer)
                .ToList();

            if (contactosBD.Count == 0)
                return null;

            var contactosNoEnLista = contactosBD
                .Where(d => !list.Any(c => c.IdContacto != null && c.IdContacto == d.IdContacto))
                .ToList();

            if (contactosNoEnLista.Count == 0)
                return null;

            return contactosNoEnLista;
        }

        public static int EliminarContactos(List<Contactos> list)
        {
            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null)
                return 0;
            ringoContext.RemoveRange(list);
            ringoContext.SaveChanges();
            return list.Count;
        }

        public static bool UpdateContacto (Contactos? contacto)
        {
            if (contacto == null)
                return false;
            ringoContext = new RingoDbContext();
            if (ringoContext.Contactos == null || ringoContext.UsersRedesSociales == null || ringoContext.RedesSociales == null)
                return false;

            int id = 0;
            if (contacto.IdContacto == null)
                id = InsertContacto(contacto);
            if (id > 0)
                return true;
            var con = ringoContext.Contactos.FirstOrDefault(c => c.IdContacto == contacto.IdContacto);
            if (con == null)
                return false;
            con.Email = contacto.Email;
            con.codArea = contacto.codArea;
            con.Telefono = contacto.Telefono;
            con.esFijo = contacto.esFijo;
            if (contacto.IdUserRedSocial != null)
                contacto.UsersRedesSociales = null;
            if (contacto.UsersRedesSociales != null)
                contacto.UsersRedesSociales.RedesSociales = null;
            con.UsersRedesSociales = contacto.UsersRedesSociales;
            con.IdUserRedSocial = contacto.IdUserRedSocial;

            ringoContext.SaveChanges();
            return true;

        }

    }
}
