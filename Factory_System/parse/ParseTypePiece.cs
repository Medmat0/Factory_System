using Factory_System.singleton;
using Factory_System.structure.piece;

namespace Factory_System.parse;

public class ParseTypePiece
{
    
    private  CookBook Cookbook { get; } = Singleton<CookBook>.Instance;
    public ParseTypePiece()
    {
    }
    
    public bool FindTypeOfPiece(string name)
    {
        if (Enum.TryParse(name, out Hull _)) return true;
        return Enum.TryParse(name, out Thruster _) || Enum.TryParse(name, out Engine _) ||
               Enum.TryParse(name, out Wing _);
    }

    public bool IsAStartShip(string input)
    {
        return Cookbook.GetOneStarShipWithName(input) != null;
    }


    public bool IsAHull(string name)
    {
        return Enum.TryParse(name, out Hull _);
    }

    public bool IsAWing(string name)
    {
        return Enum.TryParse(name, out Wing _);
    }

    public bool IsAEngine(string name)
    {
        return Enum.TryParse(name, out Engine _);
    }

    public bool IsAThruster(string name)
    {
        return Enum.TryParse(name, out Thruster _);
    }
}