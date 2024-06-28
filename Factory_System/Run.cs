using Factory_System.runCommand;
using Factory_System.validation;

namespace Factory_System;

public class Run
{
    public Run(string input)
    {
        Input = input;
    }

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
            Console.WriteLine($"Argument error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Invalid operation: {ex.Message}");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Key not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}