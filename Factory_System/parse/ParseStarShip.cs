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
        if (listShipAndNumber == null || listShipAndNumber.Count == 0)
        {
            throw new ArgumentException("Arguments are either null or empty. Please provide valid input.");
        }

        for (var i = 0; i < listShipAndNumber.Count; i++)
        {
            var numberAndShip = listShipAndNumber[i].Trim().Split(" ");
            if (numberAndShip.Length != 2)
            {
                throw new ArgumentException($"Invalid argument format at position {i}. Expected format: 'number shipName'.");
            }

            var starShip = cookbook.GetOneStarShipWithName(numberAndShip[1].Trim());
            if (starShip == null)
            {
                // Log the error and continue for dont stop the process
                Console.WriteLine($"Warning: Starship '{numberAndShip[1].Trim()}' not found in the cookbook. Skipping this entry.");
                continue;
            }

            try
            {
                var numbVal = int.Parse(numberAndShip[0].Trim());
                AddStartShip(starShip.Value, numbVal);
            }
            catch (FormatException)
            {
                throw new FormatException($"Failed to parse '{numberAndShip[0].Trim()}' into an integer at position {i}. Please provide a valid number.");
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