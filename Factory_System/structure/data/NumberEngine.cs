using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public struct NumberEngine
{
    public int Number { get; }
    public Engine Engine { get; }

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
}