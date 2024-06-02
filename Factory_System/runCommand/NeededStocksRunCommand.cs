using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.runCommand;

public class NeededStocksRunCommand : ICommandRun
{
    public NeededStocksRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }

    private Dictionary<StartShipName, StartShip> StarShips { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        AddInDatabase();
        ViewInConsole();
    }

    private void AddInDatabase()
    {
        foreach (var (_, starShip) in StarShips)
        {
            Database.AddPiece(starShip.Thruster.WithMultiplyNumber(starShip.Number));
            Database.AddPiece(starShip.Engine.WithMultiplyNumber(starShip.Number));
            Database.AddPiece(starShip.Hull.WithMultiplyNumber(starShip.Number));
            Database.AddPiece(starShip.Wings.WithMultiplyNumber(starShip.Number));
        }
    }


    private void ViewInConsole()
    {
        var content = "";

        foreach (var (_, starShip) in StarShips)
        {
            content += $"{starShip.Number} {starShip.Name}\n";
            content += $"{starShip.Engine.NumberPieces()} {starShip.Engine.TypePiecePrecise()} :\n";
            content += $"{starShip.Hull.NumberPieces()} {starShip.Hull.TypePiecePrecise()}\n";
            content += $"{starShip.Thruster.NumberPieces()} {starShip.Thruster.TypePiecePrecise()}\n";
            content += $"{starShip.Wings.NumberPieces()} {starShip.Wings.TypePiecePrecise()}\n";
        }

        content += "Total :\n";
        foreach (var (_, starShip) in StarShips)
        {
            var numberPiecesWing = Database.NumberPiece(starShip.Wings);
            var numberPiecesThruster = Database.NumberPiece(starShip.Thruster);
            var numberPiecesEngine = Database.NumberPiece(starShip.Engine);
            var numberPiecesHull = Database.NumberPiece(starShip.Hull);
            content += $"{numberPiecesWing} {starShip.Wings.TypePiecePrecise()}\n";
            content += $"{numberPiecesThruster} {starShip.Thruster.TypePiecePrecise()}\n";
            content += $"{numberPiecesHull} {starShip.Hull.TypePiecePrecise()}\n";
            content += $"{numberPiecesEngine} {starShip.Engine.TypePiecePrecise()}\n";
        }

        Console.Write(content);
    }
}