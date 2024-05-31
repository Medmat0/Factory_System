// See https://aka.ms/new-console-template for more information

namespace Factory_System;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Welcome to the starship factory:\n");

            while (true)
            {
                Console.WriteLine("Enter your command :");
                var userInput = Console.ReadLine();

                if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }

                if (!string.IsNullOrEmpty(userInput))
                {
                    try
                    {
                        new Run(userInput).Try();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Invalid argument: " + ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Operation error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("You must enter a command.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

}