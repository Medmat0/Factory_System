using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class AddTemplateRunCommand : ICommandRun
{
    public AddTemplateRunCommand(string args)
    {
        var pieceParse = new ParsePiece(args);
        pieceParse.Parse();
        PiecesStartShip = pieceParse.PiecesStartShip;
        StartShipName = pieceParse.StartShipName;
    }

    public CookBook Cookbook { get; } = Singleton<CookBook>.Instance;
    public Dictionary<string, Pieces> PiecesStartShip { get; set; }

    public string StartShipName { get; }


    public void Run()
    {
        var pieces = PiecesStartShip.Values.ToList();
        var startShip = new StartShip(pieces, StartShipName, 1);
        Cookbook.AddStartShip(startShip);
    }
}