using Factory_System.singleton;

namespace Factory_System;

public class StdInConsole : SdtInInterface
{
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    public void execute(string? path)
    {
        if (path != null) throw new Exception();
        Run();
    }

    private void Run()
    {
        try
        {
            StdOut.WriteLine("Welcome to the starship factory:\n");

            while (true)
            {
                StdOut.WriteLine("Enter your command :");
                var userInput = Console.ReadLine();

                if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    StdOut.WriteLine("Exiting the program. Goodbye!");
                    break;
                }

                if (!string.IsNullOrEmpty(userInput))
                    try
                    {
                        new Run(userInput).Try();
                    }
                    catch (ArgumentException ex)
                    {
                        StdOut.WriteLine("Invalid argument: " + ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        StdOut.WriteLine("Operation error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        StdOut.WriteLine("An unexpected error occurred: " + ex.Message);
                    }
                else
                    StdOut.WriteLine("You must enter a command.");
            }
        }
        catch (Exception ex)
        {
            StdOut.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}