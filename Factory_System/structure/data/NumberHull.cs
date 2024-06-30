using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class NumberHull : Pieces
{
    public NumberHull(int number, Hull hull)
    {
        Number = number;
        Hull = hull;
    }

    public NumberHull(Hull hull)
    {
        Hull = hull;
        Number = 1;
    }

    public int Number { get; protected set; }

    public TypePiece TypePiece { get; } = TypePiece.Hull;

    public Hull Hull { get; }


    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new NumberHull(number + Number, Hull);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new NumberHull(number * Number, Hull);
    }

    public override Pieces WithRemoveNumber(int number)
    {
        return new NumberHull(Number - number, Hull);
    }

    public override string TypePiecePrecise()
    {
        return Hull.ToString();
    }

    public override string View()
    {
        return Number + " " + TypePiecePrecise();
    }
}