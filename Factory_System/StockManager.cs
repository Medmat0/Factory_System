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
            new Piece("Engine_ES1", 2),
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

        // add builder design  for vaisseau  : Exemple  cargo.withHull_HC1()
        //                                                   .withEngine()  .... 


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
            Console.WriteLine("Inventaire des pièces disponibles :");

            Dictionary<string, int> pieceQuantities = new Dictionary<string, int>();
            Dictionary<string, int> vaisseauQuantities = new Dictionary<string, int>();

            foreach (var piece in PiecesInStock)
            {
                if (!pieceQuantities.ContainsKey(piece.Name))
                    pieceQuantities[piece.Name] = 0;

                pieceQuantities[piece.Name] += piece.Quantity;
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

            // Afficher les pièces avec leurs quantités
            foreach (var kvp in pieceQuantities)
            {
                Console.WriteLine($"{kvp.Value} {kvp.Key}");
            }
        }



        public void DisplayNeededStocks(Dictionary<string, int> vaisseauxQuantites)
        {
            Console.WriteLine("Needed pieces :");

            Dictionary<string, Dictionary<string, int>> neededStocks = new Dictionary<string, Dictionary<string, int>>();

            foreach (var kvp in vaisseauxQuantites)
            {
                string vaisseauName = kvp.Key;
                int quantity = kvp.Value;

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

                            neededStocks[vaisseauName][piece.Name] += piece.Quantity * quantity;
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

        // instruction c'est le logique de produce , les noms d' assemblage des peices c'est a nous de gere 
        // produce c'est juste 2 sortie , si y'a le stocks -> updateStock  sinon Error Message

        // can t handle multiple args in cmd for now , ( 4 vaisseau1 , 3 vaisseau3 ....) 
        /*   public bool VerifyStockCommand(string[] args)
           {
               foreach (string arg in args)
               {
                   bool found = false;
                   foreach (Vaisseau vaisseau in AvailableVaisseaux)
                   {
                       if (vaisseau.Name == arg)
                       {

                           found = true;
                           foreach (Piece piece in vaisseau.Pieces)
                           {
                               Piece stockPiece = PiecesInStock.Find(p => p.Name == piece.Name);
                               if (stockPiece == null || stockPiece.Quantity < piece.Quantity)
                               {
                                   return false;
                               }
                               else
                               {
                                   return true;
                               }
                           }


                       }
                   }
                   if (!found)
                   {
                       return false;
                   }
               }
               return true;
           }

           */
        public bool VerifyStockCommand(Dictionary<string, int> vaisseauxQuantites)
        {
            Dictionary<string, int> totalPieceRequirements = new Dictionary<string, int>();

            foreach (var kvp in vaisseauxQuantites)
            {
                string vaisseauName = kvp.Key;
                int quantity = kvp.Value;

                bool found = false;
                foreach (Vaisseau vaisseau in AvailableVaisseaux)
                {
                    if (vaisseau.Name == vaisseauName)
                    {
                        found = true;
                        foreach (Piece piece in vaisseau.Pieces)
                        {
                            if (!totalPieceRequirements.ContainsKey(piece.Name))
                                totalPieceRequirements[piece.Name] = 0;

                            totalPieceRequirements[piece.Name] += piece.Quantity * quantity;
                        }
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"ERROR: Vaisseau '{vaisseauName}' n'est pas reconnu");
                    return false;
                }
            }

            foreach (var kvp in totalPieceRequirements)
            {
                Piece stockPiece = PiecesInStock.Find(p => p.Name == kvp.Key);
                if (stockPiece == null || stockPiece.Quantity < kvp.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public bool InstructionsCommand(Dictionary<string, int> vaisseauxQuantites)
        {
            foreach (var kvp in vaisseauxQuantites)
            {
                string vaisseauName = kvp.Key;
                int quantity = kvp.Value;

                bool found = false;
                foreach (Vaisseau vaisseau in AvailableVaisseaux)
                {
                    if (vaisseau.Name == vaisseauName)
                    {
                        found = true;

                        Console.WriteLine($"PRODUCING {quantity} {vaisseau.Name}");

                        // Liste pour stocker les assemblages temporaires
                        List<string> assemblies = new List<string>();

                        foreach (Piece piece in vaisseau.Pieces)
                        {
                            assemblies.Add(piece.Name);
                        }

                        string previousAssembly = null;
                        for (int i = 0; i < assemblies.Count; i++)
                        {
                            string currentPiece = assemblies[i];
                            string currentAssembly = previousAssembly != null ? $"{previousAssembly} {currentPiece}" : currentPiece;
                            string assemblyName = $"TMP{i + 1}";
                            Console.WriteLine($"ASSEMBLE {assemblyName} {currentAssembly}");
                            previousAssembly = assemblyName;
                        }

                        Console.WriteLine($"FINISHED {vaisseau.Name}");

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"ERROR: Vaisseau '{vaisseauName}' n'est pas reconnu");
                    return false;
                }
            }

            return true;
        }

        public bool ProduceCommand(Dictionary<string, int> vaisseauxQuantites)
        {
            foreach (var kvp in vaisseauxQuantites)
            {
                string vaisseauName = kvp.Key;
                int quantity = kvp.Value;

                bool found = false;
                foreach (Vaisseau vaisseau in AvailableVaisseaux)
                {
                    if (vaisseau.Name == vaisseauName)
                    {
                        found = true;

                        // Produire les vaisseaux
                        foreach (Piece piece in vaisseau.Pieces)
                        {
                            Piece stockPiece = PiecesInStock.Find(p => p.Name == piece.Name);
                            if (stockPiece != null)
                            {
                                stockPiece.Quantity -= piece.Quantity * quantity;
                            }
                        }


                        break;
                    }
                }


                if (!found)
                {
                    Console.WriteLine($"ERROR: Vaisseau '{vaisseauName}' n'est pas reconnu");
                    return false;
                }else
                {
                    Console.WriteLine("STOCK_UPDATED");

                }
            }

            return true;
        }






    }






}

        