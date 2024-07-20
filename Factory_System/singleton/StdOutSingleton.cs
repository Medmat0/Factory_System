using Factory_System.std.outStd;
using Factory_System.structure.@enum;

namespace Factory_System.singleton;

public class StdOutSingleton
{
    private IStdOutInterface StdOut { get; set; } = new StdOutConsole();

    public void Init(string? path, Stdout stdout)
    {
        switch (stdout)
        {
            case Stdout.Json:
                StdOut = Singleton<StdOutJson>.Instance;
                StdOut.Init(path);
                break;
            case Stdout.Console:
                StdOut = Singleton<StdOutConsole>.Instance;
                StdOut.Init(null);
                break;
            case Stdout.Xml:
                StdOut = Singleton<StdOutXml>.Instance;
                StdOut.Init(path);
                break;
            case Stdout.Txt:
                StdOut = Singleton<StdOutTxt>.Instance;
                StdOut.Init(path);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stdout), stdout, null);
        }
    }

    public void WriteLine(string output)
    {
        StdOut.Display(output);
    }
}