namespace Factory_System.structure.data;

public abstract class Pieces
{
    public abstract int NumberPieces();

    public abstract Pieces WithAddNumber(int number);

    public abstract Pieces WithMultiplyNumber(int number);

    public abstract Pieces WithRemoveNumber(int number);

    public abstract string TypePiecePrecise();

    public abstract string View();
}