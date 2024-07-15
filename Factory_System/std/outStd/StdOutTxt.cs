
namespace Factory_System.std.outStd;

public class StdOutTxt : IStdOutInterface
{
    private string Path { get; set; }

    public void Display(string output)
    {
        using var writer = new StreamWriter(Path, true);
        if (new FileInfo(Path).Length == 0)
            writer.Write(output);
        else
            writer.WriteLine(output);
    }

    public void Init(string? path)
    {
        Path = path ?? throw new Exception("I don't have path");
    }
}