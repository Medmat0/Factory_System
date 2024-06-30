using Factory_System.std.@in;

namespace Factory_System;

public class StdInTxt : SdtInInterface
{
    public void execute(string? path)
    {
        if (path == null) throw new Exception();
        var lines = File.ReadAllLines(path).ToList();
        foreach (var line in lines) StdRun.Run(line);
    }
}