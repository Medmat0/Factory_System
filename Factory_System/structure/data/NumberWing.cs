using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class NumberWing : Pieces
{
    public NumberWing(int number, Wing wing)
    {
        Number = number;
        Wing = wing;
    }

    public NumberWing(Wing wing)
    {
        Number = 2;
        Wing = wing;
    }

    public int Number { get; }

    public TypePiece TypePiece { get; } = TypePiece.Wing;

    public Wing Wing { get; }

    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new NumberWing(number + Number, Wing);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new NumberWing(number * Number, Wing);
    }


    public override Pieces WithRemoveNumber(int number)
    {
        return new NumberWing(Number - number, Wing);
    }

    public override string TypePiecePrecise()
    {
        return Wing.ToString();
    }
}