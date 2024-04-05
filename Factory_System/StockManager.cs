using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System
{
    internal class StockManager
    {
        public List<Piece> PiecesInStock { get; set; }

        public StockManager()
        {
            PiecesInStock = new List<Piece>();
        }

        public void DisplayStocks()
        {
            foreach (var piece in PiecesInStock)
            {
                Console.WriteLine($"Piece: {piece.Name}, Quantity: {piece.Quantity}");
            }
        }
    }
}
