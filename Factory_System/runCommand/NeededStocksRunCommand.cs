using Factory_System.Model.@enum;
using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;

namespace Factory_System.runCommand;

public class NeededStocksRunCommand : ICommandRun
{
    public NeededStocksRunCommand(string args)
    {
        var temp = new ParseStarShip(args);
        temp.Parse();
        StarShipStructs = temp.StarShipStructs;
    }

    private Dictionary<StartShipName, StarShipStruct> StarShipStructs { get; }
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        //AddInDatabase();
        //ViewInConsole();
    }
    /*
    private void AddInDatabase()
    {
        foreach (var starShipStruct in StarShipStructs)
        {
            Database.AddNewPiece(starShipStruct.Value.Thruster, starShipStruct.Value.Number);
            Database.AddNewPiece(starShipStruct.Value.Engine, starShipStruct.Value.Number);
            Database.AddNewPiece(starShipStruct.Value.Wing, starShipStruct.Value.Number);
            Database.AddNewPiece(starShipStruct.Value.Hull, starShipStruct.Value.Number);
        }
    }


    private void ViewInConsole()
    {
        var content = "";

        foreach (var starShipStruct in StarShipStructs)
        {
            content += $"{starShipStruct.Value.Number} {starShipStruct.Key} :\n";
            content += $"{starShipStruct.Value.Number} {starShipStruct.Value.Wing}\n";
            content += $"{starShipStruct.Value.Number} {starShipStruct.Value.Thruster}\n";
            content += $"{starShipStruct.Value.Number} {starShipStruct.Value.Hull}\n";
            content += $"{starShipStruct.Value.Number} {starShipStruct.Value.Engine}\n";
        }

        content += "Total :\n";
        foreach (var starShipStruct in StarShipStructs)
        {
            var numberPiecesWing = Database.NumberPiece(starShipStruct.Value.Wing);
            var numberPiecesThruster = Database.NumberPiece(starShipStruct.Value.Thruster);
            var numberPiecesEngine = Database.NumberPiece(starShipStruct.Value.Engine);
            var numberPiecesHull = Database.NumberPiece(starShipStruct.Value.Hull);
            content += $"{numberPiecesWing} {starShipStruct.Value.Wing}\n";
            content += $"{numberPiecesThruster} {starShipStruct.Value.Thruster}\n";
            content += $"{numberPiecesHull} {starShipStruct.Value.Hull}\n";
            content += $"{numberPiecesEngine} {starShipStruct.Value.Engine}\n";
        }

        Console.Write(content);
    }*/
}