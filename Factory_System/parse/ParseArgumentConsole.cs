using Factory_System.singleton;
using Factory_System.std;
using Factory_System.structure.@enum;

namespace Factory_System.parse;

public class ParseArgumentConsole
{
    public ParseArgumentConsole(string[] command)
    {
        this.command = command;
    }

    private string[] command { get; }

    public void BuildSdout()
    {
        var end = "Error";
        if (ExistArgument("--end")) end = FindArgumentAfter("--end");
        var start = "Error";
        if (ExistArgument("--start")) start = FindArgumentAfter("--start");

        if (end != "Error" && !ExistPath(end)) return;

        if (start != "Error" && !ExistPath(start)) return;
        var sdoutEnd = FindType(end);
        var sdoutStart = FindType(start);
        if (sdoutStart == Stdout.Console) start = null;
        if (sdoutEnd == Stdout.Console) end = null;
        var stdIn = new SdInExecute();
        var stdOut = Singleton<StdOutSingleton>.Instance;
        stdOut.Init(end, sdoutEnd);
        stdIn.Execute(sdoutStart, start);
    }

    private bool ExistArgument(string argument)
    {
        for (var i = 0; i < command.Count(); i++)
            if (command[i] == argument)
                return command.Count() != i - 1;

        return false;
    }

    private string FindArgumentAfter(string argument)
    {
        for (var i = 0; i < command.Count(); i++)
            if (command[i].Trim() == argument)
                return command[i + 1];

        return "Error";
    }

    private static bool ExistPath(string filePath)
    {
        return File.Exists(filePath);
    }

    private static Stdout FindType(string filePath)
    {
        if (filePath == "Error") return Stdout.Console;
        var fileExtension = Path.GetExtension(filePath);
        switch (fileExtension.ToLower())
        {
            case ".json":
                return Stdout.Json;
            case ".xml":
                return Stdout.Xml;
            case ".txt":
                return Stdout.Txt;
            default:
                throw new Exception("not found");
        }
    }
}