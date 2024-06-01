using Factory_System.Model.piece;

namespace Factory_System.structure.data;

public struct NumberWing
{
    public int Number { get; }
    public Wing Wing { get; }

    public NumberWing(int number, Wing wing)
    {
        Number = number;
        Wing = wing;
    }

    public NumberWing(Wing wing)
    {
        Number = 1;
        Wing = wing;
    }
}