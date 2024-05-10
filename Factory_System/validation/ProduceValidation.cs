using Factory_System.parse;

namespace Factory_System.validation;

public class ProduceValidation(string? args) : ICommandValidation
{
    private string? Args { get; } = args;

    public bool Validation()
    {
        if (Args == null) throw new Exception("nos ARGS");
        return new ParseStarShip(Args).Parse();
    }
}