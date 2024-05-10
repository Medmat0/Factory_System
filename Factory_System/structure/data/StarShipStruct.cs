using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public readonly struct StarShipStruct
{
    public StarShipStruct(string name, StartShipName startShipName, Wing wing, Thruster thruster, Engine engine,
        Hull hull, int number)
    {
        Name = name;
        StartShipName = startShipName;
        Engine = engine;
        Wing = wing;
        Thruster = thruster;
        Hull = hull;
        Number = number;
    }

    public StarShipStruct(string name, StartShipName startShipName, Wing wing, Thruster thruster, Engine engine,
        Hull hull)
    {
        Name = name;
        StartShipName = startShipName;
        Engine = engine;
        Wing = wing;
        Thruster = thruster;
        Hull = hull;
        Number = 1;
    }

    public string Name { get; }
    public StartShipName StartShipName { get; }
    public Wing Wing { get; }
    public Thruster Thruster { get; }
    public Engine Engine { get; }
    public Hull Hull { get; }
    public int Number { get; }
}