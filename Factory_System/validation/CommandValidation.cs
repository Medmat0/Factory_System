using System.Reflection;
using System.Runtime.Serialization;
using Factory_System.structure.data;
using Factory_System.structure.@enum;

namespace Factory_System.validation;

public class CommandValidation(string command)
{
    private string Command { get; } = command;

    public CommandAndArgs CommandAndArgs { get; private set; }


    public CommandValidation SplitIntoCommandAndArgs()
    {
        var commandAll = Command.Split(new[] { ' ' }, 2);
        var commandEnum = FindEnumValue(commandAll.First().Trim());

        if (commandEnum == null)
        {
            throw new ArgumentException($"'{commandAll.First().Trim()}' is not a valid command.");
        }

        string? args = commandAll.Length > 1 && !string.IsNullOrWhiteSpace(commandAll[1]) ? commandAll[1].Trim() : null;

        CommandAndArgs = new CommandAndArgs(commandEnum.Value, args);
        return this;
    }

    private CommandEnum? FindEnumValue(string value)
    {
        foreach (CommandEnum enumValue in Enum.GetValues(typeof(CommandEnum)))
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null) continue;
            var attribute = fieldInfo.GetCustomAttribute<EnumMemberAttribute>();

            if (attribute != null && attribute.Value == value) return enumValue;
        }

        return null;
    }

    public CommandValidation VerifyByCommand()
    {
        switch (CommandAndArgs.CommandEnum)
        {
            case CommandEnum.Produce:
                var produceValidation = new ProduceValidation(CommandAndArgs.Args);
                produceValidation.Validation();
                break;
            case CommandEnum.Stocks:
                var stockValidation = new StockValidation(CommandAndArgs.Args);
                stockValidation.Validation();
                break;
            case CommandEnum.NeededStocks:
                var needStocksValidation = new NeedStocksValidation(CommandAndArgs.Args);
                needStocksValidation.Validation();
                break;
            case CommandEnum.Verify:
                var verifyValidation = new VerifyValidation(CommandAndArgs.Args);
                verifyValidation.Validation();
                break;
            case CommandEnum.Instructions:
                throw new Exception("Is not implemented");//TODO: implement
        }

        return this;
    }
}