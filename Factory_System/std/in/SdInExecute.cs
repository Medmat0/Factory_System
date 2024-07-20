using Factory_System.structure.@enum;

namespace Factory_System.std;

public class SdInExecute
{
    public void Execute(Stdout stdout, string? path)
    {
        switch (stdout)
        {
            case Stdout.Console:
                var stdInConsole = new StdInConsole();
                stdInConsole.execute(null);
                break;
            case Stdout.Json:
                var stdInJson = new StdInJson();
                stdInJson.execute(path);
                break;
            case Stdout.Txt:
                var stdInTxt = new StdInTxt();
                stdInTxt.execute(path);
                break;
            case Stdout.Xml:
                var stdInXml = new StdInXml();
                stdInXml.execute(path);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stdout), stdout, null);
        }
    }
}