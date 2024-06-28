using System.Runtime.Serialization;

namespace Factory_System.structure.@enum;

public enum CommandEnum
{
    [EnumMember(Value = "VERIFY")] Verify,
    [EnumMember(Value = "STOCKS")] Stocks,
    [EnumMember(Value = "NEEDED_STOCKS")] NeededStocks,
    [EnumMember(Value = "INSTRUCTIONS")] Instructions,
    [EnumMember(Value = "PRODUCE")] Produce
}