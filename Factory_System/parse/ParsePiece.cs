using Factory_System.structure.data;
using Factory_System.structure.piece;
using Factory_System.validation;

namespace Factory_System.parse;

public class ParsePiece
{
    public ParsePiece(string args)
    {
        Args = args;
    }

    /*
     * ADD_TEMPLATE Ari , 1 spff
     */
    private string Args { get; }


    public Dictionary<string, Pieces> PiecesStartShip { get; } = new();

    public string StartShipName { get; private set; } = "";


    public bool Parse()
    {
        var listNameAndNumber = Args.Split(",").ToList();
        if (listNameAndNumber == null || listNameAndNumber.Count < 5)
            throw new ArgumentException("Arguments are either null or empty. Please provide valid input.");

        StartShipName = listNameAndNumber.First().Trim();
        var listPiece = listNameAndNumber.Skip(1).ToList();
        for (var i = 0; i < listPiece.Count; i++)
        {
            var numberAndPiece = listPiece[i].Trim().Split(" ");
            if (numberAndPiece.Length != 2)
                throw new ArgumentException(
                    $"Invalid argument format at position {i}. Expected format: 'number PieceName'.");

            var piece = FindPiece(numberAndPiece[1].Trim());
            if (piece == null)
            {
                Console.WriteLine(
                    $"Warning: Starship '{numberAndPiece[1].Trim()}' not found in the cookbook. Skipping this entry.");
                continue;
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


    private void AddPiece(Pieces pieces, int value)
    {
        if (PiecesStartShip.TryGetValue(pieces.TypePiecePrecise(), out var existingPieces))
        {
            var updatedPiece = existingPieces.WithAddNumber(existingPieces.NumberPieces() + value);
            PiecesStartShip[pieces.TypePiecePrecise()] = updatedPiece;
        }
        else
        {
            var newPieces = pieces.WithAddNumber(value);
            PiecesStartShip[pieces.TypePiecePrecise()] = newPieces;
        }
    }


    private Pieces? FindPiece(string input)
    {
        if (Enum.TryParse(input, out Thruster thruster)) return new NumberThruster(thruster);
        if (Enum.TryParse(input, out Engine engine)) return new NumberEngine(engine);
        if (Enum.TryParse(input, out Wing wing)) return new NumberWing(wing);
        if (Enum.TryParse(input, out Hull hull)) return new NumberHull(hull);
        return null;
    }
}