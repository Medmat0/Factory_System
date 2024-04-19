using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System
{
        internal class ClientCommand
        {
            private StockManager stockManager;

            public ClientCommand(StockManager manager)
            {
                stockManager = manager;
            }


        /*   public void ProcessCommand(string command)
           {
               string[] commandParts = command.Split(' ');

               if (commandParts.Length == 2 && commandParts[0] == "NEEDED_STOCKS")
               {
                   string[] args = commandParts[1].Split(',');
                   stockManager.DisplayNeededStocks(args);
               }
               else if (commandParts.Length >= 2 && commandParts[0] == "VERIFY")
               {
                   string[] args = commandParts[1].Split(',');
                   if (stockManager.VerifyStockCommand(args))
                   {
                       Console.WriteLine("AVAILABLE");
                   }
                   else
                   {
                       Console.WriteLine("UNAVAILABLE");
                   }
               }
               else if (command == "STOCKS")
               {
                   stockManager.DisplayStocks();
               }
               else if (commandParts.Length >= 2 && commandParts[0] == "PRODUCE")
               {
                   // Extraire les quantités et les noms des vaisseaux
                   List<string> vaisseaux = new List<string>();
                   foreach (var part in commandParts.Skip(1))
                   {
                       string[] vaisseauInfo = part.Split(' ');
                       if (vaisseauInfo.Length == 2 && int.TryParse(vaisseauInfo[0], out int quantity))
                       {
                           for (int i = 0; i < quantity; i++)
                           {
                               vaisseaux.Add(vaisseauInfo[1]);
                           }
                       }
                       else
                       {
                           Console.WriteLine("Invalid command.");
                           return;
                       }
                   }

                   // Produire les vaisseaux
                   if (stockManager.ProduceCommand(vaisseaux.ToArray()))
                   {
                       Console.WriteLine("STOCK_UPDATED");
                   }
               }
               else
               {
                   Console.WriteLine("Invalid command.");
               }
           }
        */

        /*public void ProcessCommand(string command)
        {
            string[] commandParts = command.Split(',');
            string[] instructionParts = commandParts[0].Trim().Split(' ');

            if (instructionParts.Length < 0)
            {
                Console.WriteLine("Invalid command.");
                return;
            }

            string instruction = instructionParts[0].ToUpperInvariant();
            Console.WriteLine("$ instruction is  : ", instruction);

            if (instruction == "VERIFY" || instruction == "NEEDED_STOCKS")
            {
                Dictionary<string, int> vaisseauxQuantites = new Dictionary<string, int>();

                for (int i = 1; i < instructionParts.Length; i++)
                {
                    string[] vaisseauInfo = instructionParts[i].Split(' ');

                    if (vaisseauInfo.Length != 2 || !int.TryParse(vaisseauInfo[0], out int quantity))
                    {
                        Console.WriteLine("Invalid command.");
                        return;
                    }

                    vaisseauxQuantites[vaisseauInfo[1]] = vaisseauxQuantites.ContainsKey(vaisseauInfo[1]) ? vaisseauxQuantites[vaisseauInfo[1]] + quantity : quantity;
                }

                if (instruction == "VERIFY")
                {
                    if (stockManager.VerifyStockCommand(vaisseauxQuantites))
                    {
                        Console.WriteLine("AVAILABLE");
                    }
                    else
                    {
                        Console.WriteLine("UNAVAILABLE");
                    }
                }
                else if (instruction == "NEEDED_STOCKS")
                {
                    stockManager.DisplayNeededStocks(vaisseauxQuantites);
                }
            }
            else if (instruction == "PRODUCE")
            {
                List<string> vaisseaux = new List<string>();

                for (int i = 1; i < instructionParts.Length; i++)
                {
                    string[] vaisseauInfo = instructionParts[i].Split(' ');

                    if (vaisseauInfo.Length != 2 || !int.TryParse(vaisseauInfo[0], out int quantity))
                    {
                        Console.WriteLine("Invalid command.");
                        return;
                    }

                    for (int j = 0; j < quantity; j++)
                    {
                        vaisseaux.Add(vaisseauInfo[1]);
                    }
                }

                if (stockManager.ProduceCommand(vaisseaux.ToArray()))
                {
                    Console.WriteLine("STOCK_UPDATED");
                }
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }


        */
        public void ProcessCommand(string command)
        {
            string[] vaisseaux = command.Split(',');

            string[] instructionParts = vaisseaux[0].Trim().Split(' ');
            // mtn pour les 2 maj ou min
            string instruction = instructionParts[0].ToUpperInvariant();

            switch (instruction)
            {
                case "VERIFY":
                    string[] parts3 = command.Split(',');

                    string[] firstPart3 = parts3[0].Split(' ');
                    if (firstPart3.Length != 3 || !int.TryParse(firstPart3[1], out int quantity01))
                    {
                        Console.WriteLine("Invalid command.");
                        return;
                    }

                    string vaisseauName3 = firstPart3[2];

                    Dictionary<string, int> vaisseauxQuantites4 = new Dictionary<string, int>();
                    vaisseauxQuantites4[vaisseauName3] = quantity01;

                    for (int i = 1; i < parts3.Length; i++)
                    {
                        string[] vaisseauPart = parts3[i].Trim().Split(' ');
                        if (vaisseauPart.Length != 2 || !int.TryParse(vaisseauPart[0], out int vaisseauQuantity4))
                        {
                            Console.WriteLine("Invalid command.");
                            return;
                        }

                        vaisseauxQuantites4[vaisseauPart[1]] = vaisseauQuantity4;
                    }

                    if (stockManager.VerifyStockCommand(vaisseauxQuantites4))
                    {
                        Console.WriteLine("AVAILABLE");
                    }
                    else
                    {
                        Console.WriteLine("UNAVAILABLE");
                    }
                    break;


                    
                case "NEEDED_STOCKS":
                    string[] parts = command.Split(',');

                    string[] firstPart = parts[0].Split(' ');
                    if (firstPart.Length != 3 || !int.TryParse(firstPart[1], out int quantity))
                    {
                        Console.WriteLine("Invalid command.");
                        return;
                    }

                    string vaisseauName = firstPart[2];

                    Dictionary<string, int> vaisseauxQuantites1 = new Dictionary<string, int>();
                    vaisseauxQuantites1[vaisseauName] = quantity;

                    for (int i = 1; i < parts.Length; i++)
                    {
                        string[] vaisseauPart = parts[i].Trim().Split(' ');
                        if (vaisseauPart.Length != 2 || !int.TryParse(vaisseauPart[0], out int vaisseauQuantity4))
                        {
                            Console.WriteLine("Invalid command.");
                            return;
                        }

                        vaisseauxQuantites1[vaisseauPart[1]] = vaisseauQuantity4;
                    }

                    stockManager.DisplayNeededStocks(vaisseauxQuantites1);
                    break;
                case "STOCKS":
                    stockManager.DisplayStocks();
                    break;

                case "PRODUCE":
                    string[] parts1 = command.Split(',');

                    string[] firstPart1 = parts1[0].Split(' ');
                    if (firstPart1.Length != 3 || !int.TryParse(firstPart1[1], out int quantity9))
                    {
                        Console.WriteLine("Invalid command.");
                        return;
                    }

                    string vaisseauName1 = firstPart1[2];

                    Dictionary<string, int> vaisseauxQuantites = new Dictionary<string, int>();
                    vaisseauxQuantites[vaisseauName1] = quantity9;

                    for (int i = 1; i < parts1.Length; i++)
                    {
                        string[] vaisseauPart = parts1[i].Trim().Split(' ');
                        if (vaisseauPart.Length != 2 || !int.TryParse(vaisseauPart[0], out int vaisseauQuantity4))
                        {
                            Console.WriteLine("Invalid command.");
                            return;
                        }

                        vaisseauxQuantites[vaisseauPart[1]] = vaisseauQuantity4;
                    }

                    stockManager.ProduceCommand(vaisseauxQuantites);
                        
                    break;


                   

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }





    }



}
