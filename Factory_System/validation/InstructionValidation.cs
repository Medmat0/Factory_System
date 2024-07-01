using Factory_System.parse;

namespace Factory_System.validation;

public class InstructionValidation(string? command) : ICommandValidation
{
    
    private string? Args { get; } = command;
    
    public bool Validation()
    {
        if (Args == null) throw new ArgumentNullException(nameof(Args), "Arguments (Args) cannot be null.");
        var parseStarShip = new ParseStarShip(Args);
        if (!parseStarShip.Parse())
        {
            throw new Exception("something if happen");
        }

        return true;

    }
}