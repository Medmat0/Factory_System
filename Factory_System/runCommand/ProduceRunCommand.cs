using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class ProduceRunCommand : ICommandRun
{
    
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;
    public ProduceRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private Dictionary<string, StartShip> StarShips { get; }
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
        foreach (var (_, starShip) in StarShips)
            if (starShip.ListPieces.Any(piece => piece.NumberPieces() > Database.NumberPiece(piece)))
                return false;

        return true;
    }

    private void BuildStarShip()
    {
        foreach (var (_, startShip) in StarShips)
        {
            foreach (var piece in startShip.ListPieces) Database.RemovePiece(piece);
            Database.AddPiece(startShip);
        }
        StdOut.WriteLine("STOCK_UPDATED\n");
    }
}