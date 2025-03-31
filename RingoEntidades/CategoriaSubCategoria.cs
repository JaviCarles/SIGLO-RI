using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class CategoriaSubCategoria
    {
        [Key]
        public int? IdCateSubCate { get; set; }

        [ForeignKey("CategoriasPrendas")]
        public int? IdCategoriaPrenda { get; set; }

        [ForeignKey("SubCategoriasPrendas")]
        public int? IdSubCategoriaPrenda { get; set; }

        public CategoriasPrendas? CategoriasPrendas { get; set; }

        public SubCategoriasPrendas? SubCategoriasPrendas { get; set; }

        [NotMapped]
        public string? Categoria
        {
            get
            {
                if (CategoriasPrendas != null)
                    return CategoriasPrendas.Categoria;
                return null;
            }
            set
            {
                _categoria = value;
            }
        }
        private string? _categoria;

        [NotMapped]
        public string? SubCategoria
        {
            get
            {
                if (SubCategoriasPrendas != null)
                    return SubCategoriasPrendas.SubCategoria;
                return null;
            }
            set
            {
                _subCategoria = value;
            }
        }
        private string? _subCategoria;

    }
}
