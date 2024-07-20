using Factory_System.parse;
using ArgumentNullException = System.ArgumentNullException;

namespace Factory_System.validation;

public class ReceiveValidation(string? command): ICommandValidation
{
    
    private string? Args { get; } = command;
    
    public bool Validation()
    {
        if (Args == null) throw new ArgumentNullException(nameof(Args), "Arguments (Args) cannot be null.");

        var pieceParse = new ParseAllPiece(Args);
        return pieceParse.Parse();
    }
}