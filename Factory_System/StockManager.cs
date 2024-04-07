﻿using System;
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
            new Piece("Hull_HE1", 5),
            new Piece("Engine_EE1", 9),
            new Piece("Wings_WE1", 3),
            new Piece("Thruster_TE1", 5)
        }),
        new Vaisseau("Speeder", new List<Piece>
        {
            new Piece("Hull_HS1", 6),
            new Piece("Engine_ES1", 2),
            new Piece("Wings_WS1", 1),
            new Piece("Thruster_TS1", 6)
        }),
        new Vaisseau("Cargo", new List<Piece>
        {
            new Piece("Hull_HC1", 6),
            new Piece("Engine_EC1", 1),
            new Piece("Wings_WC1", 5),
            new Piece("Thruster_TC1", 10)
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


        public void DisplayNeededStocks(string[] args)
        {
            Console.WriteLine("Needed pieces :");

            Dictionary<string, Dictionary<string, int>> neededStocks = new Dictionary<string, Dictionary<string, int>>();

            foreach (string vaisseauName in args)
            {
                foreach (Vaisseau vaisseau in AvailableVaisseaux)
                {
                    if (vaisseau.Name == vaisseauName)
                    {
                        if (!neededStocks.ContainsKey(vaisseauName))
                            neededStocks[vaisseauName] = new Dictionary<string, int>();

                        foreach (Piece piece in vaisseau.Pieces)
                        {
                            if (!neededStocks[vaisseauName].ContainsKey(piece.Name))
                                neededStocks[vaisseauName][piece.Name] = 0;

                            neededStocks[vaisseauName][piece.Name]++;
                        }
                        break;
                    }
                }
            }

            foreach (var vaisseauOb in neededStocks)
            {
                Console.WriteLine($"{vaisseauOb.Key} :");
                foreach (var pieceVaisOb in vaisseauOb.Value)
                {
                    Console.WriteLine($"{pieceVaisOb.Value} {pieceVaisOb.Key}");
                }
            }

            Console.WriteLine("Total :");
            Dictionary<string, int> totalNeededStocks = new Dictionary<string, int>();
            foreach (var vaisseauOb in neededStocks)
            {
                foreach (var pieceVaisOb in vaisseauOb.Value)
                {
                    if (!totalNeededStocks.ContainsKey(pieceVaisOb.Key))
                        totalNeededStocks[pieceVaisOb.Key] = 0;

                    totalNeededStocks[pieceVaisOb.Key] += pieceVaisOb.Value;
                }
            }
            foreach (var vaisseauOb in totalNeededStocks)
            {
                Console.WriteLine($"{vaisseauOb.Value} {vaisseauOb.Key}");
            }
        }




        public bool VerifyStockCommand(string[] args)
        {
            foreach (string arg in args)
            {
                bool found = false;
                foreach (Vaisseau vaisseau in AvailableVaisseaux)
                {
                    if (vaisseau.Name == arg)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {

                    return false;
                }
            }
            return true;
        }
    }


        

   

}
