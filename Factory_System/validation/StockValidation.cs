using Factory_System.parse;

namespace Factory_System.validation;

public class StockValidation(string? args) : ICommandValidation
{
    private string? Args { get; } = args;

    public bool Validation()
    {
        if (Args == null)
        {
            throw new ArgumentNullException(nameof(Args), "Arguments (Args) cannot be null.");
        }

        return new ParseStarShip(Args).Parse();
    }

}