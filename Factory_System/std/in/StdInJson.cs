using Factory_System.std;
using Factory_System.std.@in;
using Newtonsoft.Json;

namespace Factory_System;

public class StdInJson : SdtInInterface
{
    public void execute(string? path)
    {
        if (path == null) throw new Exception();
        var existingJson = File.ReadAllText(path);
        var existingData = JsonConvert.DeserializeObject<List<MyContent>>(existingJson);
        if (existingData == null || existingData.Count == 0) return;
        foreach (var command in existingData) StdRun.Run(command.content);
    }
}