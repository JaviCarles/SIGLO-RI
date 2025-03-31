using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Contactos
    {
        [Key]
        public int? IdContacto { get; set; }

        [ForeignKey("Personas")]
        public int? IdPersona { get; set; }

        [ForeignKey("Empresas")]
        public int? IdEmpresa { get; set; }

        [ForeignKey("Sucursales")]
        public int? IdSucursal { get; set; }

        [ForeignKey("UsersRedesSociales")]
        public int? IdUserRedSocial { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(10)]
        public string? codArea { get; set; }

        [Column(TypeName = "bit")]
        public bool? esFijo { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public Personas? Personas { get; set; }

        public Empresas? Empresas { get; set; }

        public Sucursales? Sucursales { get; set; }

        public UsersRedesSociales? UsersRedesSociales { get; set; }

        [NotMapped]
        public string? UsuarioRedSocial
        {
            get
            {
                if (UsersRedesSociales != null)
                    return UsersRedesSociales.UsuarioRedSocial;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? NombreRedSocial
        {
            get
            {
                if (UsersRedesSociales != null)
                    return UsersRedesSociales.NombreRedSocial;
                else
                    return null;
            }
        }

        [NotMapped]
        public string? Tipo
        {
            get
            {
                if (esFijo != null)
                    return (bool)esFijo ? "Fijo" : "Celular";
                else
                    return null;
            }
        }

        [NotMapped]
        public string? NumeroCompleto
        {
            get
            {
                if (Telefono == null)
                    return null;
                bool fijo = esFijo ?? false;
                if (!fijo)
                {
                    return $"{codArea}-15{Telefono}";
                }
                return $"{codArea}-{Telefono}";
            } set
            {
                _numeroCompleto = value;
            }
        }
        private string? _numeroCompleto;
    }
}
