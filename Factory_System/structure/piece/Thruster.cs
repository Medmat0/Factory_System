using System.Runtime.Serialization;

namespace Factory_System.structure.piece;

public enum Thruster
{
    [EnumMember(Value = "Thruster_TE1")] Thruster_TE1,
    [EnumMember(Value = "Thruster_TS1")] Thruster_TS1,
    [EnumMember(Value = "Thruster_TC1")] Thruster_TC1
}