using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.runCommand;

public class CommandRunBuilder(CommandAndArgs commandAndArgs)
{
    private CommandAndArgs CommandAndArgs { get; } = commandAndArgs;

    public void Run()
    {
        if (CommandAndArgs.Args == null &&
            CommandAndArgs.CommandEnum != CommandEnum.Stocks)
            throw new InvalidOperationException("CommandAndArgs is not initialized.");

        switch (CommandAndArgs.CommandEnum)
        {
            case CommandEnum.Verify:
                var verify = new VerifyRunCommand(CommandAndArgs.Args!);
                verify.Run();
                break;
            case CommandEnum.Stocks:
                var stocks = new StocksRunCommand();
                stocks.Run();
                break;
            case CommandEnum.NeededStocks:
                var need = new NeededStocksRunCommand(CommandAndArgs.Args!);
                need.Run();
                break;
            case CommandEnum.Instructions:
                break;
            case CommandEnum.Produce:
                var produce = new ProduceRunCommand(CommandAndArgs.Args!);
                produce.Run();
                break;
            case CommandEnum.AddTemplate:
                var template = new AddTemplateRunCommand(CommandAndArgs.Args!);
                template.Run();
                break;
            case CommandEnum.Receive:
                var receive = new ReceiveCommand(CommandAndArgs.Args!);
                receive.Run();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(CommandAndArgs.CommandEnum), CommandAndArgs.CommandEnum,
                    "Unknown command.");
        }
    }
}