using Factory_System.structure.data;
using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.singleton;

public class CookBook
{
    private List<StartShip> ListStarShipStructs { get; } =
    [
        new StarShipBuilder()
            .name("Explorer")
            .addEngine(Engine.Engine_EE1)
            .addHull(Hull.Hull_HE1)
            .addWings(Wing.Wings_WE1)
            .addThrusters(Thruster.Thruster_TE1)
            .build(),
        new StarShipBuilder()
            .name("Speeder")
            .addEngine(Engine.Engine_ES1)
            .addHull(Hull.Hull_HS1)
            .addWings(Wing.Wings_WS1)
            .addThrusters(Thruster.Thruster_TS1, 2)
            .build(),
        new StarShipBuilder()
            .name("Speeder")
            .addEngine(Engine.Engine_ES1)
            .addHull(Hull.Hull_HS1)
            .addWings(Wing.Wings_WS1)
            .addThrusters(Thruster.Thruster_TS1)
            .build()
    ];

    public StartShip? GetOneStarShipWithName(string name)
    {
        var index = ListStarShipStructs.FindIndex(s => s.Name == name);
        if (index >= 0) return ListStarShipStructs[index];

        return null;
    }

    public StartShip GetStarShipsWithEnum(StartShipName startShipName)
    {
        var starShip = ListStarShipStructs.FirstOrDefault(s => s.StartShipName == startShipName);

        if (starShip == null)
            throw new KeyNotFoundException($"Starship with name '{startShipName}' not found in the cookbook.");

        return starShip;
    }
}