namespace Factory_System.validation;

public class StockValidation(string? args) : ICommandValidation
{
    private string? Args { get; } = args;

    public bool Validation()
    {
        if (Args == null) return true;

        throw new Exception("une erreur est arrivé");
    }
}