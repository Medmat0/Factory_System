using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class VerifyRunCommand : ICommandRun
{
    public VerifyRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private Database Database { get; } = Singleton<Database>.Instance;

    private Dictionary<string, StartShip> StarShips { get; }

    public void Run()
    {
        var result = NumberPiece();
        StdOut.WriteLine(result ? "AVAILABLE\n" : "UNAVAILABLE\n");
    }

    private bool NumberPiece()
    {
        foreach (var (_, starShip) in StarShips)
            if (starShip.ListPieces.Any(piece => piece.NumberPieces() > Database.NumberPiece(piece)))
                return false;

        return true;
    }
}