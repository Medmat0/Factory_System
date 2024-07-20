using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class StarShipBuilder
{
    public StarShipBuilder()
    {
        Wings = new List<NumberWing>();
        Thrusters = new List<NumberThruster>();
        Engines = new List<NumberEngine>();
        Hulls = new List<NumberHull>();
    }

    private List<NumberWing> Wings { get; }
    private List<NumberThruster> Thrusters { get; }
    private List<NumberEngine> Engines { get; }
    private List<NumberHull> Hulls { get; }


    private int Number { get; set; } = 1;

    private string StartShipName { get; set; }

    public StarShipBuilder AddWings(Wing wing)
    {
        Wings.Add(new NumberWing(wing));
        return this;
    }

    public StarShipBuilder AddWings(Wing wing, int quantity)
    {
        Wings.Add(new NumberWing(quantity, wing));
        return this;
    }

    public StarShipBuilder AddThrusters(Thruster thruster, int quantity)
    {
        Thrusters.Add(new NumberThruster(quantity, thruster));
        return this;
    }

    public StarShipBuilder AddThrusters(Thruster thruster)
    {
        Thrusters.Add(new NumberThruster(thruster));
        return this;
    }

    public StarShipBuilder AddHull(Hull hull)
    {
        Hulls.Add(new NumberHull(hull));
        return this;
    }

    public StarShipBuilder AddHull(Hull hull, int quantity)
    {
        Hulls.Add(new NumberHull(quantity, hull));
        return this;
    }

    public StarShipBuilder AddEngine(Engine engine)
    {
        Engines.Add(new NumberEngine(engine));
        return this;
    }

    public StarShipBuilder AddEngine(Engine engine, int quantity)
    {
        Engines.Add(new NumberEngine(quantity, engine));
        return this;
    }

    public StarShipBuilder AddStartShipName(string name)
    {
        StartShipName = name;
        return this;
    }

    public StarShipBuilder AddNumber(int number)
    {
        Number = number;
        return this;
    }

    public StartShip Build()
    {
        var result = new List<Pieces>();
        result.AddRange(Thrusters);
        result.AddRange(Engines);
        result.AddRange(Wings);
        result.AddRange(Hulls);
        return new StartShip(result, StartShipName, Number);
    }
}