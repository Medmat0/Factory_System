using Factory_System.Model.@enum;

namespace Factory_System.structure.data;

public readonly struct CommandAndArgs(CommandEnum commandEnum, string? args)
{
    public CommandEnum CommandEnum { get; } = commandEnum;
    public string? Args { get; } = args;
}