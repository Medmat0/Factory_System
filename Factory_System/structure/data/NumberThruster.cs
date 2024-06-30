using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class NumberThruster : Pieces
{
    public NumberThruster(int number, Thruster thruster)
    {
        Thruster = thruster;
        Number = number;
    }

    public NumberThruster(Thruster thruster)
    {
        Thruster = thruster;
        Number = 1;
    }

    public int Number { get; }

    public Thruster Thruster { get; }

    public TypePiece TypePiece { get; } = TypePiece.Thruster;

    public override Pieces WithAddNumber(int number)
    {
        return new NumberThruster(number + Number, Thruster);
    }

    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new NumberThruster(Number * number, Thruster);
    }

    public override Pieces WithRemoveNumber(int number)
    {
        return new NumberThruster(Number - number, Thruster);
    }

    public override string TypePiecePrecise()
    {
        return Thruster.ToString();
    }

    public override string View()
    {
        return Number + " " + TypePiecePrecise();
    }
}