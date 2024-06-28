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

    private Dictionary<string, StartShip> StarShips { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        AddInDatabase();
        ViewInConsole();
    }

    private void AddInDatabase()
    {
        foreach (var (_, starShip) in StarShips)
        foreach (var pieces in starShip.ListPieces)
            Database.AddPiece(pieces.WithMultiplyNumber(pieces.NumberPieces()));
    }


    private void ViewInConsole()
    {
        var content = "";

        foreach (var (_, starShip) in StarShips)
        foreach (var piece in starShip.ListPieces)
            content += $"{Database.NumberPiece(piece)} {piece.TypePiecePrecise()}\n";

        content += "Total :\n";
        //TODO solve this with number of pieces individuel
        foreach (var (_, starShip) in StarShips)
        foreach (var piece in starShip.ListPieces)
            content += $"{Database.NumberPiece(piece)} {piece.TypePiecePrecise()}\n";

        Console.Write(content);
    }
}