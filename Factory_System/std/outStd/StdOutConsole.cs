

namespace Factory_System.std.outStd;

public class StdOutConsole : IStdOutInterface
{
    public void Display(string output)
    {
        Console.WriteLine(output);
    }

    public void Init(string? path)
    {
        if (path != null) throw new Exception("Not found");
    }
}