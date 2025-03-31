﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoEntidades
{
    public class CategoriasPrendas
    {
        [Key]
        public int? IdCategoriaPrenda { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }
    }
}
