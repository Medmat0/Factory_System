using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System.Model
{
    internal class Piece
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Piece(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
