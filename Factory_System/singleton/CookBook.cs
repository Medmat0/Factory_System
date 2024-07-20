using Factory_System.structure.data;
using Factory_System.structure.piece;

namespace Factory_System.singleton;

public class CookBook
{
    private List<StartShip> ListStarShipStructs { get; } =
    [
        new StarShipBuilder()
            .AddStartShipName("Explorer")
            .AddEngine(Engine.Engine_EE1)
            .AddHull(Hull.Hull_HE1)
            .AddWings(Wing.Wings_WE1, 2)
            .AddThrusters(Thruster.Thruster_TE1)
            .Build(),
        new StarShipBuilder()
            .AddStartShipName("Speeder")
            .AddEngine(Engine.Engine_ES1)
            .AddHull(Hull.Hull_HS1)
            .AddWings(Wing.Wings_WS1, 2)
            .AddThrusters(Thruster.Thruster_TS1, 2)
            .Build(),
        new StarShipBuilder()
            .AddStartShipName("Speeder")
            .AddEngine(Engine.Engine_ES1)
            .AddHull(Hull.Hull_HS1)
            .AddWings(Wing.Wings_WE1, 2)
            .AddThrusters(Thruster.Thruster_TS1, 2)
            .Build()
    ];

    public StartShip? GetOneStarShipWithName(string name)
    {
        var index = ListStarShipStructs.FindIndex(s => s.Name == name);
        return index >= 0 ? ListStarShipStructs[index] : null;
    }

    public void AddStartShip(StartShip startShip)
    {
        ListStarShipStructs.Add(startShip);
    }
}