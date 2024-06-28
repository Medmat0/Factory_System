using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.runCommand;

public class VerifyRunCommand : ICommandRun
{
    public VerifyRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private Database Database { get; } = Singleton<Database>.Instance;

    private Dictionary<StartShipName, StartShip> StarShips { get; }

    public void Run()
    {
        var result = NumberPiece();
        Console.Write(result ? "AVAILABLE\n" : "UNAVAILABLE\n");
    }

    private bool NumberPiece()
    {
        foreach (var (_, starShip) in StarShips)
        {
            if (starShip.Engine.NumberPieces() >= Database.NumberPiece(starShip.Engine)) return false;
            if (starShip.Hull.NumberPieces() >= Database.NumberPiece(starShip.Hull)) return false;
            if (starShip.Thruster.NumberPieces() >= Database.NumberPiece(starShip.Thruster)) return false;
            if (starShip.Wings.NumberPieces() >= Database.NumberPiece(starShip.Wings)) return false;
        }

        return true;
    }
}