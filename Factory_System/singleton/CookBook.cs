using Factory_System.Model.@enum;
using Factory_System.Model.piece;
using Factory_System.structure.data;

namespace Factory_System.singleton;

public class CookBook
{
    public List<StarShipStruct> ListStarShipStructs { get; } =
    [
        new StarShipStruct(
            "Explorer",
            StartShipName.Explorer,
            new List<Model.Piece>
            {
                new Model.Piece(Wing.Wings_WE1, 1),
                new Model.Piece(Thruster.Thruster_TE1, 1),
                new Model.Piece(Engine.Engine_EE1, 1),
                new Model.Piece(Hull.Hull_HE1, 1)
            }
        ),

        new StarShipStruct(
            "Speeder",
            StartShipName.Speeder,
            new List<Model.Piece>
            {
                new Model.Piece(Wing.Wings_WS1, 1),
                new Model.Piece(Thruster.Thruster_TS1, 2),
                new Model.Piece(Engine.Engine_ES1, 1),
                new Model.Piece(Hull.Hull_HS1, 1)
            }
        ),

        new StarShipStruct(
            "Cargo",
            StartShipName.Cargo,
            new List<Model.Piece>
            {
                new Model.Piece(Wing.Wings_WC1, 1),
                new Model.Piece(Thruster.Thruster_TC1, 1),
                new Model.Piece(Engine.Engine_EC1, 1),
                new Model.Piece(Hull.Hull_HC1, 1)
            }
        )
    ];



    public StarShipStruct? GetOneStarShipWithName(string name)
    {
        var index = ListStarShipStructs.FindIndex(s => s.Name == name);
        if (index >= 0) return ListStarShipStructs[index];

        return null;
    }

    public StarShipStruct GetStarShipsWithEnum(StartShipName startShipName)
    {
        var starShip = ListStarShipStructs.FirstOrDefault(s => s.StartShipName == startShipName);

        if (starShip.Equals(default(StarShipStruct)))
        {
            throw new KeyNotFoundException($"Starship with name '{startShipName}' not found in the cookbook.");
        }

        return starShip;
    }


}