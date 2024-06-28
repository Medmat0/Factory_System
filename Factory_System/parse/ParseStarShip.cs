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

    public Dictionary<StartShipName, StartShip> StartShips { get; } = new();
    public CookBook Cookbook { get; } = Singleton<CookBook>.Instance;
    public string Args { get; }

    public bool Parse()
    {
        var listShipAndNumber = Args?.Split(",").ToList();
        if (listShipAndNumber == null || listShipAndNumber.Count == 0)
            throw new ArgumentException("Arguments are either null or empty. Please provide valid input.");

        for (var i = 0; i < listShipAndNumber.Count; i++)
        {
            var numberAndShip = listShipAndNumber[i].Trim().Split(" ");
            if (numberAndShip.Length != 2)
                throw new ArgumentException(
                    $"Invalid argument format at position {i}. Expected format: 'number shipName'.");

            var starShip = Cookbook.GetOneStarShipWithName(numberAndShip[1].Trim());
            if (starShip == null)
            {
                // Log the error and continue for dont stop the process
                Console.WriteLine(
                    $"Warning: Starship '{numberAndShip[1].Trim()}' not found in the cookbook. Skipping this entry.");
                continue;
            }

            try
            {
                var numbVal = int.Parse(numberAndShip[0].Trim());
                AddStartShip(starShip, numbVal);
            }
            catch (FormatException)
            {
                throw new FormatException(
                    $"Failed to parse '{numberAndShip[0].Trim()}' into an integer at position {i}. Please provide a valid number.");
            }
        }

        return true;
    }


    private void AddStartShip(StartShip starShip, int value)
    {
        var numberActually = value;
        if (StartShips.TryGetValue(starShip.StartShipName, out var ship)) numberActually += ship.Number;

        StartShips[starShip.StartShipName] = new StarShipBuilder()
            .name(starShip.Name)
            .addEngine(starShip.Engine.Engine)
            .addHull(starShip.Hull.Hull)
            .addWings(starShip.Wings.Wing)
            .addThrusters(starShip.Thruster.Thruster, starShip.Thruster.NumberPieces())
            .addNumber(numberActually)
            .build();
    }
}