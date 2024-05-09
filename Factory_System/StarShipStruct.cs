namespace Factory_System;

public struct StarShipStruct
{
    public string Name { get; }
    public Wing Wing { get; }
    public Thruster Thruster { get; }
    public Engine Engine { get; }
    public Hull Hull { get; }

    public StarShipStruct(string name, Wing wing, Thruster thruster, Engine engine, Hull hull)
    {
        Name = name;
        Wing = wing;
        Thruster = thruster;
        Engine = engine;
        Hull = hull;
    }
}