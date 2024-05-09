using System.Collections;

namespace Factory_System;

public class CommandProcess {
    private string Command { get;  }
    public string[] Args { get; }
    public CommandProcess(string command)
    {
        var commandAll = command.Split(" ");
        this.Command = commandAll[0];

        List<string> argsList = commandAll.ToList();
        argsList.RemoveAt(0);
        Args = argsList.ToArray();
    }

    public Boolean VerifyValidityOfCommand()
    {
        return Command switch
        {
            "STOCKS" => true,
            "NEEDED_STOCKS" => true,
            "INSTRUCTIONS" => true,
            "VERIFY" => true,
            "PRODUCE" => true,
            _ => false
        };
    }
    
    
    
    
}