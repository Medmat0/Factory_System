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

            public void ProcessCommand(string command)
            {
            string[] commandParts = command.Split(' ');

            if (commandParts.Length == 2 && commandParts[0] == "NEEDED_STOCKS")
            {
                string[] args = commandParts[1].Split(',');
                stockManager.DisplayNeededStocks(args);
            }
            else if(commandParts.Length >= 2 && commandParts[0] == "VERIFY")
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
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }

        
    }
