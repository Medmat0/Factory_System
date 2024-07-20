using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.piece;

namespace Factory_System.parse;

public class ParseAllPiece
{
    
    public ParseAllPiece(string args)
    {
        Args = args;
    }
    public Dictionary<string, Pieces> PiecesStartShip { get; set; } = new();
    
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;
    
    private CookBook CookBook { get;  } = Singleton<CookBook>.Instance;
    private string Args { get; }
    
    public bool Parse()
    {
        var listNameAndNumber = Args.Split(",").ToList();
        
        var listPiece = listNameAndNumber.ToList();
        for (var i = 0; i < listPiece.Count; i++)
        {
            var numberAndPiece = listPiece[i].Trim().Split(" ");
            if (numberAndPiece.Length != 2)
                throw new ArgumentException(
                    $"Invalid argument format at position {i}. Expected format: 'number PieceName'.");

            var piece = FindPiece(numberAndPiece[1].Trim());
            if (piece == null)
            {
                StdOut.WriteLine(
                    $"ERROR: Starship '{numberAndPiece[1].Trim()}' not found in the cookbook. Skipping this entry.");
                return false;
            }

            try
            {
                var numbVal = int.Parse(numberAndPiece[0].Trim());
                AddPiece(piece, numbVal);
            }
            catch (FormatException)
            {
                throw new FormatException(
                    $"Failed to parse '{numberAndPiece[0].Trim()}' into an integer at position {i}. Please provide a valid number.");
            }
        }

        return true;
    }
    
    private Pieces? FindPiece(string input)
    {
        if (Enum.TryParse(input, out Thruster thruster)) return new NumberThruster(0,thruster);
        if (Enum.TryParse(input, out Engine engine)) return new NumberEngine(0,engine);
        if (Enum.TryParse(input, out Wing wing)) return new NumberWing(0,wing);
        if (Enum.TryParse(input, out Hull hull)) return new NumberHull(0,hull);
        var starShip = CookBook.GetOneStarShipWithName(input);
        return starShip ?? null;
    }
    
    private void AddPiece(Pieces pieces, int value)
    {
        if (PiecesStartShip.TryGetValue(pieces.TypePiecePrecise(), out var existingPieces))
        {
            pieces.FindTypePiece();
            var updatedPiece = existingPieces.WithAddNumber(existingPieces.NumberPieces() + value);
            PiecesStartShip[pieces.TypePiecePrecise()] = updatedPiece;
        }
        else
        {
            if (pieces.FindTypePiece() == "StarShip")
            {
                var newPieces = pieces.WithAddNumber(value-1);
                PiecesStartShip[pieces.TypePiecePrecise()] = newPieces;
            }
            else
            {
                var newPieces = pieces.WithAddNumber(value);
                PiecesStartShip[pieces.TypePiecePrecise()] = newPieces;
            }
        }
    }
}