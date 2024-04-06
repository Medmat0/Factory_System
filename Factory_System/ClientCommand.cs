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
            if (command == "STOCK")
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
