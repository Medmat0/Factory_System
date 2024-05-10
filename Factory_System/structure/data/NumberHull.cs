using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public struct NumberHull
{
    public int Number { get; }
    public Hull Hull { get; }

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
}