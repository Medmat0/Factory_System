using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.runCommand;

public class ProduceRunCommand : ICommandRun
{
    public ProduceRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private Dictionary<StartShipName, StartShip> StarShips { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        var numberOfPieces = NumberPiece();

        if (!numberOfPieces)
            throw new InvalidOperationException(
                "Error in Conception: the number of pieces is invalid or could not be determined.");

        BuildStarShip();
    }

    private bool NumberPiece()
    {
        foreach (var (_, starShipStruct) in StarShips)
        {
            if (starShipStruct.Number > Database.NumberPiece(starShipStruct.Engine)) return false;
            if (starShipStruct.Number > Database.NumberPiece(starShipStruct.Hull)) return false;
            if (starShipStruct.Number > Database.NumberPiece(starShipStruct.Thruster)) return false;
            if (starShipStruct.Number > Database.NumberPiece(starShipStruct.Wings)) return false;
        }

        return true;
    }

    private void BuildStarShip()
    {
        foreach (var (_, startShip) in StarShips)
        {
            Database.RemovePiece(startShip.Thruster);
            Database.RemovePiece(startShip.Hull);
            Database.RemovePiece(startShip.Wings);
            Database.RemovePiece(startShip.Engine);
            Database.AddPiece(startShip);
        }
    }
}