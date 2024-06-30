using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.parse;

public class ParseStarShip
{
    public ParseStarShip(string args)
    {
        Args = args;
    }

    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    public Dictionary<string, StartShip> StartShips { get; } = new();
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
                StdOut.WriteLine(
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
        if (StartShips.TryGetValue(starShip.Name, out var existingStartShip))
        {
            var updatedStartShip = existingStartShip.WithAddNumber(existingStartShip.Number + value);
            StartShips[starShip.Name] = (StartShip)updatedStartShip;
        }
        else
        {
            var newStartShip = new StartShip(starShip.ListPieces, starShip.Name, value);
            StartShips[starShip.Name] = newStartShip;
        }
    }
}