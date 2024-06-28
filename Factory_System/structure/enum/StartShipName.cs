using System.Runtime.Serialization;

namespace Factory_System.structure.@enum;

public enum StartShipName
{
    [EnumMember(Value = "Explorer")] Explorer,
    [EnumMember(Value = "Speeder")] Speeder,
    [EnumMember(Value = "Cargo")] Cargo
}