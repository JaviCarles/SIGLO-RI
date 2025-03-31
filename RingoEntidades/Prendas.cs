using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class Prendas
    {
        [Key]
        public int? IdPrenda { get; set; }

        [MaxLength(30)]
        public string CodigoPrenda { get; set; }

        [ForeignKey("CategoriaSubCategoria")]
        public int? IdCateSubCate { get; set; }

        [ForeignKey("Telas")]
        public int? IdTela { get; set; }

        [ForeignKey("Proveedores")]
        public int? IdProveedor { get; set; }

        [MaxLength(150)]
        public string DescripcionPrenda { get; set; }

        public int Cantidad { get; set; }

        public int? Costo { get; set; }

        public int? PrecioVenta { get; set; }

        public CategoriaSubCategoria? CategoriaSubCategoria { get; set; }

        public Telas? Telas { get; set; }

        public Proveedores? Proveedores { get; set; }



        [NotMapped]
        public string? SubCategoria
        {
            get
            {
                if (CategoriaSubCategoria != null)
                    return CategoriaSubCategoria.SubCategoria;
                else
                    return null;
            } set
            {
                _subCategoria = value;
            }
        }
        private string? _subCategoria;

        [NotMapped]
        public string? Categoria
        {
            get
            {
                if (CategoriaSubCategoria != null)
                    return CategoriaSubCategoria.Categoria;
                else
                    return null;
            }
            set
            {
                _categoria = value;
            }
        }
        private string? _categoria;

        [NotMapped]
        public string? TelaPrenda
        {
            get
            {
                if (Telas != null)
                    return Telas.Tela;
                else
                    return null;
            } set
            {
                _tela = value;
            }
        }
        private string? _tela;

        [NotMapped]
        public string? nombreProveedor
        {
            get
            {
                if (Proveedores != null)
                    return Proveedores.Empresas.RazonSocial;
                return null;
            } set
            {
                _empresas = value;
            }
        }
        private string? _empresas;
    }
}
