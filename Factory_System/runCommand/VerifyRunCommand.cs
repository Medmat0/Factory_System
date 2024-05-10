using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.runCommand;

public class VerifyRunCommand : ICommandRun
{
    public VerifyRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShipStructs = temp.StarShipStructs;
    }

    private Database Database { get; } = Singleton<Database>.Instance;

    private Dictionary<StartShipName, StarShipStruct> StarShipStructs { get; }

    public void Run()
    {
        var result = NumberPiece();
        Console.Write(result ? "AVAILABLE\n" : "UNAVAILABLE\n");
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
}