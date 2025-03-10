using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.validation;

public class ValidationStarShipCook(List<Pieces> piecesList, string starShipName)
{

    private CookBook CookBook { get; } = Singleton<CookBook>.Instance;
    public List<Pieces> PiecesList { get; } = piecesList;

    public string StarShipName { get; } = starShipName;


    public bool FindIfAnotherShipAddThisName()
    {
        var startShip = CookBook.GetOneStarShipWithName(StarShipName);
        if (startShip == null) return false;

        return true;
    }

    public bool ValidatePieceCount<T>(Func<Pieces, bool> predicate, int maxCount, bool mustBeUnique = false)
        where T : Pieces
    {
        var list = PiecesList.Where(predicate).ToList();
        if (list.Count == 0) return false;

        var sum = list.Aggregate(0, (acc, curr) => acc + curr.NumberPieces());
        if (sum > maxCount) return false;

        if (mustBeUnique)
            return list.Select(p => p.TypePiecePrecise())
                .Distinct()
                .Count() == 1;

        return true;
    }

    public bool ValidateNumberOfHull()
    {
        return ValidatePieceCount<NumberHull>(p => p is NumberHull, 1, true);
    }

    public bool ValidateNumberOfThruster()
    {
        return ValidatePieceCount<NumberThruster>(p => p is NumberThruster, 3);
    }

    public bool ValidateNumberOfWing()
    {
        return ValidatePieceCount<NumberWing>(p => p is NumberWing, 2);
    }

    public bool ValidateNumberOfEngine()
    {
        return ValidatePieceCount<NumberEngine>(p => p is NumberEngine, 2, true);
    }

    public bool ValidatePiece()
    {
        if (!ValidateNumberOfHull()) throw new Exception("Is not a possible hull");

        if (!ValidateNumberOfEngine()) throw new Exception("Is not possible engine");

        if (!ValidateNumberOfThruster()) throw new Exception("Is not possible thruster");

        if (!ValidateNumberOfWing()) throw new Exception("Is not a possible wing");

        return true;
    }
}