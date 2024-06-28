using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class NumberEngine : Pieces
{
    public NumberEngine(int number, Engine engine)
    {
        Number = number;
        Engine = engine;
    }

    public NumberEngine(Engine engine)
    {
        Number = 1;
        Engine = engine;
    }

    public int Number { get; }
    public Engine Engine { get; }

    public TypePiece TypePiece { get; } = TypePiece.Engine;

    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new NumberEngine(number + Number, Engine);
    }


    public override Pieces WithRemoveNumber(int number)
    {
        return new NumberEngine(Number - number, Engine);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new NumberEngine(Number * number, Engine);
    }

    public override string TypePiecePrecise()
    {
        return Engine.ToString();
    }
}