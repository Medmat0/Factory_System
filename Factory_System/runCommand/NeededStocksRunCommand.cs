using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class NeededStocksRunCommand : ICommandRun
{
    public NeededStocksRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private Dictionary<string, StartShip> StarShips { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        ViewInConsole();
    }


    private void ViewInConsole()
    {
        StdOut.WriteLine(ViewFirstPart() + ViewSecondPart());
    }

    private string ViewFirstPart()
    {
        var content = "";
        foreach (var (_, starShip) in StarShips)
        {
            content += starShip.NumberPieces() + " " + starShip.Name + ":\n";
            foreach (var piece in starShip.ListPieces) content += $"{piece.View()}\n";
        }

        return content;
    }

    private string ViewSecondPart()
    {
        var listPieces = StarShips.Values.Select(ship => CreateListWithShip(ship)).SelectMany(l => l).ToList();

        var piecesNeeded = listPieces.GroupBy(p => p.TypePiecePrecise())
            .Select(g => new
            {
                PieceType = g.Key,
                TotalQuantity = g.Sum(p => p.NumberPieces())
            })
            .OrderBy(p => p.PieceType);

        var content = "Total:\n";
        foreach (var piece in piecesNeeded) content += $"{piece.TotalQuantity} {piece.PieceType}\n";
        return content;
    }

    private List<Pieces> CreateListWithShip(StartShip ship)
    {
        return ship.ListPieces.Select(piece => piece.WithMultiplyNumber(ship.NumberPieces())).ToList();
    }
}