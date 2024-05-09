namespace Factory_System;

public class Database
{

    public Dictionary<string, StarShipStruct> Map { get; } = new Dictionary<string, StarShipStruct>();


    public Boolean AddNewStarShip(StarShipStruct starShipStruct, string name)
    {
        if (Map.ContainsKey(name))
        {
            return false;
        }
        Map[name] = starShipStruct;
        return true;
    }
}