using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class SubCategoriasPrendas
    {
        [Key]
        public int? IdSubCategoriaPrenda { get; set; }

        [MaxLength(100)]
        public string SubCategoria { get; set; }

    }
}
