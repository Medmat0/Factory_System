using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public struct NumberThruster
{
    public int Number { get; }

    public Thruster Thruster { get; }

    public NumberThruster(int number, Thruster thruster)
    {
        Number = number;
        Thruster = thruster;
    }

    public NumberThruster(Thruster thruster)
    {
        Number = 1;
        Thruster = thruster;
    }
}