using Factory_System.singleton;

namespace Factory_System.runCommand;

public class StocksRunCommand : ICommandRun
{
    private StdOutSingleton StdOut { get; } = Singleton<StdOutSingleton>.Instance;

    private Database Database { get; } = Singleton<Database>.Instance;

    public void Run()
    {
        if (Database.ToString().Equals(""))
        {
            StdOut.WriteLine("STOCK_EMPTY\n");
        }
        else
        {
            StdOut.WriteLine(Database +"\n");
        }
       
    }
}