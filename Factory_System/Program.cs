// See https://aka.ms/new-console-template for more information

namespace Factory_System;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Welcome the factory vaissaux : \n");
            while (true)
            {
                Console.WriteLine("Entre your command !");
                var userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                    new Run(userInput).Try();
                else
                    Console.WriteLine("You must enter a command.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}