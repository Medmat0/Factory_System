using Factory_System.singleton;

namespace Factory_System.runCommand;

public class StocksRunCommand : ICommandRun
{
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        StdOut.WriteLine(Database.ToString());
    }
}