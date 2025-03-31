using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoFront
{
    public class Item
    {
        public string Descripcion { get; set; }
        public int Value { get; set; }


        public Item(string displayText, int value)
        {
            Descripcion = displayText;
            Value = value;
        }
    }
}
