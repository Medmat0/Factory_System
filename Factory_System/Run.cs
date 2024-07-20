using Factory_System.runCommand;
using Factory_System.singleton;
using Factory_System.validation;

namespace Factory_System;

public class Run
{
    public Run(string input)
    {
        Input = input;
    }

    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private string Input { get; }

    public void Try()
    {
        try
        {
            var command = new CommandValidation(Input);
            var verification = command.SplitIntoCommandAndArgs().VerifyByCommand();
            new CommandRunBuilder(verification.CommandAndArgs).Run();
        }
        catch (ArgumentException ex)
        {
            StdOut.WriteLine($"Argument error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            StdOut.WriteLine($"Invalid operation: {ex.Message}");
        }
        catch (KeyNotFoundException ex)
        {
            StdOut.WriteLine($"Key not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            StdOut.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}