using Factory_System.Model.@enum;
using Factory_System.Model.piece;
using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class ProduceRunCommand : ICommandRun
{
    public ProduceRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShipStructs = temp.StarShipStructs;
    }

    private Dictionary<StartShipName, StarShipStruct> StarShipStructs { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        bool numberOfPieces = NumberPiece();

        if (!numberOfPieces)
        {
            throw new InvalidOperationException("Error in Conception: the number of pieces is invalid or could not be determined.");
        }

        BuildStarShip();
    }

    private bool NumberPiece()
    {

        StartShipName startShipName = StarShipStructs.First().Value.StartShipName;
        foreach (var (_, starShipStruct) in StarShipStructs)
        {
            if (starShipStruct.Number >= Database) return false;
            if (starShipStruct.Number >= Database.NumberPiece(starShipStruct.Hull)) return false;
            if (starShipStruct.Number >= Database.NumberPiece(starShipStruct.Thruster)) return false;
            if (starShipStruct.Number >= Database.NumberPiece(starShipStruct.Wing)) return false;
        }

        return true;
    }

    private void BuildStarShip()
    {
        foreach (var (_, starShipStruct) in StarShipStructs)
        {
            Database.DeletePieces(starShipStruct.Engine, starShipStruct.Number);
            Database.DeletePieces(starShipStruct.Wing, starShipStruct.Number);
            Database.DeletePieces(starShipStruct.Thruster, starShipStruct.Number);
            Database.DeletePieces(starShipStruct.Hull, starShipStruct.Number);
            Database.AddNewStarShips(starShipStruct);
        }
    }
}