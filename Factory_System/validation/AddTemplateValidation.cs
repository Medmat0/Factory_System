using Factory_System.parse;
using Factory_System.structure.data;
using Factory_System.structure.piece;

namespace Factory_System.validation;

public class AddTemplateValidation(string? command) : ICommandValidation
{
    private string? Args { get; } = command;

    public bool Validation()
    {
        if (Args == null) throw new ArgumentNullException(nameof(Args), "Arguments (Args) cannot be null.");
        var pieceParse = new ParsePiece(Args);
        pieceParse.Parse();
        var pieces = pieceParse.PiecesStartShip.Values.ToList();
        var validationStarShipCook = new ValidationStarShipCook(pieces);
        return validationStarShipCook.ValidatePiece();
    }


    public bool FindTypeOfPiece(string name)
    {
        if (Enum.TryParse(name, out Hull _)) return true;
        return Enum.TryParse(name, out Thruster _) || Enum.TryParse(name, out Engine _);
    }


    public Pieces BuildPiece(string name, int numberPiece)
    {
        if (Enum.TryParse(name, out Hull hullResult)) return new NumberHull(numberPiece, hullResult);
        if (Enum.TryParse(name, out Thruster thrusterResult)) return new NumberThruster(numberPiece, thrusterResult);
        if (Enum.TryParse(name, out Engine engineResult)) return new NumberEngine(numberPiece, engineResult);

        if (Enum.TryParse(name, out Wing wingResult)) return new NumberWing(numberPiece, wingResult);

        throw new Exception("Is not a good type of piece");
    }
}