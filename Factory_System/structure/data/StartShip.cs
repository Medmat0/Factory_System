using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class StartShip(
    string name,
    NumberWing wings,
    NumberThruster thruster,
    Engine engine,
    Hull hull,
    StartShipName startShipName,
    int number)
    : Pieces
{
    public NumberWing Wings { get; } = wings;
    public NumberThruster Thruster { get; } = thruster;
    public NumberEngine Engine { get; } = new(engine);
    public NumberHull Hull { get; } = new(hull);

    public string Name { get; } = name;

    public int Number { get; } = number;

    public StartShipName StartShipName { get; } = startShipName;

    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new StartShip(Name, Wings, Thruster, Engine.Engine, Hull.Hull, StartShipName, number + Number);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new StartShip(Name, Wings, Thruster, Engine.Engine, Hull.Hull, StartShipName, number * Number);
    }

    public override Pieces WithRemoveNumber(int number)
    {
        return new StartShip(Name, Wings, Thruster, Engine.Engine, Hull.Hull, StartShipName, Number - number);
    }

    public override string TypePiecePrecise()
    {
        return Name;
    }
}