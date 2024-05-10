using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

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
        var numberOfPieces = NumberPiece();
        if (!numberOfPieces) throw new Exception("Error in Conception");
        BuildStarShip();
    }

    private bool NumberPiece()
    {
        foreach (var (_, starShipStruct) in StarShipStructs)
        {
            if (starShipStruct.Number >= Database.NumberPiece(starShipStruct.Engine)) return false;
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