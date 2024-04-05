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

        public ClientCommand(StockManager stockManager)
        {
            this.stockManager = stockManager;
        }

    }
}
