using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.piece;

namespace Factory_System.runCommand;

public class InstructionRunCommand: ICommandRun
{
    public InstructionRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShips = temp.StartShips;
    }
    
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private Dictionary<string, StartShip> StarShips { get; }
    private CookBook CookBook { get; } = Singleton<CookBook>.Instance;

    public void Run()
    {
        foreach (var startShip in StarShips.Values.ToList())
        {
            var startShipDb = CookBook.GetOneStarShipWithName(startShip.Name);
            if (startShipDb == null)
            {
                StdOut.WriteLine("The StartShip Not exist");
                break;
            }
            StdOut.WriteLine($"PRODUCING {startShipDb.Name}");
            ViewGet(startShipDb.ListPieces);
            ViewAssemble(startShipDb.ListPieces);
            StdOut.WriteLine($"FINISHED {startShipDb.Name}");
        }
    }

    private void ViewGet(List<Pieces> piecesList)
    {
        foreach (var pieces in piecesList)
        {
            StdOut.WriteLine($"GET_OUT_STOCK {pieces.NumberPieces()} {pieces.TypePiecePrecise()}");
        }
    }

    private void ViewAssemble(List<Pieces> piecesList)
    {
        var goodPiece = piecesList.SelectMany(pieces => CreateListOnePiece(pieces)).ToList();
        for (int i = 0; i < goodPiece.Count; i++)
        {
            var tmp = $"tmp{i}";
            goodPiece = AssemblePieces(goodPiece, tmp);
        }
        
    }
    

    private List<Pieces> AssemblePieces(List<Pieces> piecesList, string tmp)
    {
        var piecesResult = new List<Pieces>();
        for (int i = 0; i < piecesList.Count; i+=2)
        {
            if (i+1 == piecesList.Count)
            {
                break;
            }
            StdOut.WriteLine($"Assemble {tmp}{i} {piecesList[i].TypePiecePrecise()} {piecesList[i+1].TypePiecePrecise()}");
            piecesResult.Add(new NumberAssembly($"{tmp}{i}"));
        }

        if (piecesList.Count % 2 == 2)
        {
            return piecesResult;
        }

        var last  = piecesList.Last();
        piecesResult.Add(last);
        return piecesResult;

    }

    private List<Pieces> CreateListOnePiece(Pieces pieces)
    {
        var piecesNumber = pieces.NumberPieces();
        var piecesResult = new List<Pieces>();
        for (int i = 0; i < piecesNumber; i++)
        {
            piecesResult.Add(BuildPiece(pieces.TypePiecePrecise()));
        }

        return piecesResult;

    }
    
    private Pieces BuildPiece(string input)
    {
        if (Enum.TryParse(input, out Thruster thruster)) return new NumberThruster(thruster);
        if (Enum.TryParse(input, out Engine engine)) return new NumberEngine(engine);
        if (Enum.TryParse(input, out Wing wing)) return new NumberWing(wing);
        if (Enum.TryParse(input, out Hull hull)) return new NumberHull(hull);
        throw new Exception("It's not possible to find  pieces");
    }
}