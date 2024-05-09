namespace Factory_System;

public class CookBook
{
    private List<StarShipStruct> ListStarShipStructs { get;  } =
    [
        new StarShipStruct(
            "Explorer",
            Wing.Wings_WE1,
            Thruster.Thruster_TE1,
            Engine.Engine_EE1,
            Hull.Hull_HE1
        ),

        new StarShipStruct(
            "Speeder",
            Wing.Wings_WS1,
            Thruster.Thruster_TS1,
            Engine.Engine_ES1,
            Hull.Hull_HS1
        ),

        new StarShipStruct(
            "Cargo",
            Wing.Wings_WC1,
            Thruster.Thruster_TC1,
            Engine.Engine_EC1,
            Hull.Hull_HC1
        )
    ];


    public StarShipStruct? GetOneStarShipWithName(string name)
    {
        var index = ListStarShipStructs.FindIndex(s => s.Name == name);
        if (index >= 0) {
            return ListStarShipStructs[index];
        }

        return null;
    }
}