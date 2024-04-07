// See https://aka.ms/new-console-template for more information

namespace Factory_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StockManager stockManager = new StockManager();
                ClientCommand commandClient = new ClientCommand(stockManager);


                Console.WriteLine("Welcome the factory vaissaux : \n");
                Console.WriteLine("Entre your command !");
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    commandClient.ProcessCommand(userInput);
                }
                else
                {
                    Console.WriteLine("You must enter a command.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

}