namespace Factory_System;

public class StdInConsole : SdtInInterface
{
    public void execute(string? path)
    {
        if (path != null)
        {
            throw new Exception();
        }
        Run();
    }

    private void  Run()
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
                else
                    Console.WriteLine("You must enter a command.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}