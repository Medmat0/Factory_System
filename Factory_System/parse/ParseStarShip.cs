using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.parse;

public class ParseStarShip
{
    public ParseStarShip(string args)
    {
        Args = args;
    }

    public Dictionary<StartShipName, StarShipStruct> StarShipStructs { get; } = new();
    public string Args { get; }

    public bool Parse()
    {
        var cookbook = Singleton<CookBook>.Instance;

        var listShipAndNumber = Args?.Split(",").ToList();
        for (var i = 0; i < listShipAndNumber?.Count; i++)
        {
            var numberAndShip = listShipAndNumber[i].Trim().Split(" ");
            if (numberAndShip.Length != 2) throw new Exception("failed to parse");
            var starShip = cookbook.GetOneStarShipWithName(numberAndShip[1].Trim());
            if (starShip == null) throw new Exception("failed to find a starship");
            try
            {
                var numbVal = int.Parse(numberAndShip[0].Trim());
                AddStartShip(starShip.Value, numbVal);
            }
            catch (FormatException)
            {
                throw new Exception("failed to parse into int");
            }
        }

        return true;
    }

    private void AddStartShip(StarShipStruct starShipStruct, int number)
    {
        if (StarShipStructs.ContainsKey(starShipStruct.StartShipName))
        {
            var numberActually = StarShipStructs[starShipStruct.StartShipName].Number;
            StarShipStructs[starShipStruct.StartShipName] = new StarShipStruct(
                starShipStruct.Name,
                starShipStruct.StartShipName,
                starShipStruct.Wing,
                starShipStruct.Thruster,
                starShipStruct.Engine,
                starShipStruct.Hull,
                numberActually + number
            );
            return;
        }

        StarShipStructs[starShipStruct.StartShipName] = new StarShipStruct(
            starShipStruct.Name,
            starShipStruct.StartShipName,
            starShipStruct.Wing,
            starShipStruct.Thruster,
            starShipStruct.Engine,
            starShipStruct.Hull,
            number
        );
    }
}