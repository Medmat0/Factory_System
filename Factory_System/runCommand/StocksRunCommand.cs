using Factory_System.singleton;

namespace Factory_System.runCommand;

public class StocksRunCommand : ICommandRun
{
    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        Console.Write(Database.ToString());
    }
}