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
        catch (Exception e)
        {
            Console.WriteLine($"ERROR {e.Message}");
        }
    }
}