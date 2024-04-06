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
        public List<Piece> AvailablePieces { get; } = new List<Piece>
    {
        new Piece("Hull_HE1", 10),
        new Piece("Hull_HS1", 10),
        new Piece("Hull_HC1", 10),
        new Piece("Engine_EE1", 5),
        new Piece("Engine_ES1", 5),
        new Piece("Engine_EC1", 5),
        new Piece("Wings_WE1", 8),
        new Piece("Wings_WS1", 8),
        new Piece("Wings_WC1", 8),
        new Piece("Thruster_TE1", 12),
        new Piece("Thruster_TS1", 12),
        new Piece("Thruster_TC1", 12)
    };


        public List<Vaisseau> AvailableVaisseaux { get; } = new List<Vaisseau>
    {
        new Vaisseau("Explorer", new List<Piece>
        {
            new Piece("Hull_HE1", 1),
            new Piece("Engine_EE1", 1),
            new Piece("Wings_WE1", 1),
            new Piece("Thruster_TE1", 1)
        }),
        new Vaisseau("Speeder", new List<Piece>
        {
            new Piece("Hull_HS1", 1),
            new Piece("Engine_ES1", 1),
            new Piece("Wings_WS1", 1),
            new Piece("Thruster_TS1", 2)
        }),
        new Vaisseau("Cargo", new List<Piece>
        {
            new Piece("Hull_HC1", 1),
            new Piece("Engine_EC1", 1),
            new Piece("Wings_WC1", 1),
            new Piece("Thruster_TC1", 1)
        })
    };

        public StockManager()
        {
            PiecesInStock = new List<Piece>();
            PiecesInStock.Add(new Piece("Hull_HE1", 10));
            PiecesInStock.Add(new Piece("Engine_EE1", 5));
            PiecesInStock.Add(new Piece("Wings_WE1", 8));
            PiecesInStock.Add(new Piece("Thruster_TE1", 12));
        }

        public void DisplayStocks()
        {
            Console.WriteLine("Disponible stock :");

            Dictionary<string, int> pieceQuantities = new Dictionary<string, int>();

            Dictionary<string, int> vaisseauQuantities = new Dictionary<string, int>();

            foreach (var piece in PiecesInStock)
            {
                if (!pieceQuantities.ContainsKey(piece.Name))
                    pieceQuantities[piece.Name] = 0;

                pieceQuantities[piece.Name]++;
            }

            foreach (var vaisseau in AvailableVaisseaux)
            {
                if (!vaisseauQuantities.ContainsKey(vaisseau.Name))
                    vaisseauQuantities[vaisseau.Name] = 0;

                vaisseauQuantities[vaisseau.Name]++;
            }

            foreach (var kvp in vaisseauQuantities)
            {
                Console.WriteLine($"{kvp.Value} {kvp.Key}");
            }

            foreach (var kvp in pieceQuantities)
            {
                Console.WriteLine($"{kvp.Value} {kvp.Key}");
            }
        }
    }
}
