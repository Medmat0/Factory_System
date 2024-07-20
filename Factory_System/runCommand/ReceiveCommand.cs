using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class ReceiveCommand : ICommandRun
{
    
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;
    private Database Database { get; } = Singleton<Database>.Instance;
    private List<Pieces> Pieces { get; set; }
    public ReceiveCommand(string args)
    {
        var pieces = new ParseAllPiece(args);
        pieces.Parse();
        var piecesGoInBdd = pieces.PiecesStartShip.Values.ToList();
        Pieces = piecesGoInBdd;
    }

    public void Run()
    {
        foreach (var pieces in Pieces)
        {
            Database.AddPiece(pieces);
        }
    }
}