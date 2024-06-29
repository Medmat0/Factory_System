using Factory_System.std;
using Factory_System.structure.@enum;

namespace Factory_System.parse;

public class ParseArgumentConsole
{
    private string[] command { get; set; }


    public ParseArgumentConsole(string[] command)
    {
        this.command = command;
    }

    public void buildSdout()
    {
        Console.WriteLine("hello");
        var end = "Error";
        if (ExistArgument("--end"))
        {
            end = FindArgumentAfter("--end");
        }
        var start = "Error";
        if (ExistArgument("--start"))
        {
            start = FindArgumentAfter("--start");
        }
        

        if (end != "Error" && !ExistPath(end))
        {
            return;
        }
        
        if (start != "Error" && !ExistPath(start))
        {
            return;
        }
        var sdoutEnd = findType(end);
        var sdoutStart = findType(start);
        if (sdoutStart == Stdout.Console)
        {
            start = null;
        }
        if (sdoutEnd == Stdout.Console)
        {
            end = null;
        }
        var stdIn = new SdInExecute();
        stdIn.Execute(sdoutStart,start );
    }

    private bool ExistArgument(string argument)
    {
        for (int i = 0; i < command.Count(); i++)
        {
            if (command[i] == "--end")
            {
                return command.Count() != i-1;
            }
        }

        return false;
    }

    private string FindArgumentAfter(string argument)
    {
        for (int i = 0; i < command.Count(); i++)
        {
            if (command[i] == "--end")
            {
                return command[i+1];
            }
        }

        return "Error";
    }

    private bool ExistPath(string filePath)
    {
        return File.Exists(filePath);
    }

    private Stdout findType(string filePath)
    {
        if (filePath == "Error")
        {
            return Stdout.Console;
        }
        string fileExtension = Path.GetExtension(filePath);
        switch (fileExtension.ToLower())
        {
            case ".json":
                return  Stdout.Json;
            case ".xml":
                return Stdout.Xml;
            case ".txt":
                return Stdout.Txt;
            default:
                throw new Exception("not found");
        }
        
    }
    
}