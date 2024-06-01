using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System.Model
{
    public class Piece
    {
        public Enum Name { get; set; }
        public int Quantity { get; set; }

        public Piece(Enum name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
