using Newtonsoft.Json;

namespace Factory_System.std.outStd;

public class StdOutJson : IStdOutInterface
{
    private string Path { get; set; }

    public void Display(string output)
    {
        if (output.Trim() == "") return;
        var newData = new List<MyContent>
        {
            new() { content = output }
        };
        WriteFile(newData);
    }

    public void Init(string? path)
    {
        Path = path ?? throw new Exception("I don't have path");
    }

    private void WriteFile(List<MyContent> output)
    {
        try
        {
            var existingJson = File.ReadAllText(Path);
            var existingData = JsonConvert.DeserializeObject<List<MyContent>>(existingJson);
            if (existingData == null)
                existingData = output;
            else
                existingData?.AddRange(output);


            var updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText(Path, updatedJson);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Une erreur est survenue : {e.Message}");
        }
    }
}