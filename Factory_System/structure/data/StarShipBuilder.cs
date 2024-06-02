using System.Reflection;
using System.Runtime.Serialization;
using Factory_System.structure.@enum;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public class StarShipBuilder
{
    private NumberWing Wings { get; set; }
    private NumberThruster Thruster { get; set; }
    private Engine Engine { get; set; }
    private Hull Hull { get; set; }

    private string Name { get; set; }

    private int Number { get; set; } = 1;

    private StartShipName StartShipName { get; set; }

    public StarShipBuilder addWings(Wing wing)
    {
        Wings = new NumberWing(wing);
        return this;
    }

    public StarShipBuilder addThrusters(Thruster thruster, int quantity)
    {
        Thruster = new NumberThruster(quantity, thruster);
        return this;
    }

    public StarShipBuilder addThrusters(Thruster thruster)
    {
        Thruster = new NumberThruster(thruster);
        return this;
    }

    public StarShipBuilder addHull(Hull hull)
    {
        Hull = hull;
        return this;
    }

    public StarShipBuilder addEngine(Engine engine)
    {
        Engine = engine;
        return this;
    }

    public StarShipBuilder name(string name)
    {
        Name = name;
        StartShipName = FindEnumValue(name);
        return this;
    }

    public StarShipBuilder addNumber(int number)
    {
        Number = number;
        return this;
    }

    public StartShip build()
    {
        return new StartShip(Name, Wings, Thruster, Engine, Hull, StartShipName, Number);
    }

    private StartShipName FindEnumValue(string value)
    {
        foreach (StartShipName enumValue in Enum.GetValues(typeof(CommandEnum)))
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null) continue;
            var attribute = fieldInfo.GetCustomAttribute<EnumMemberAttribute>();

            if (attribute != null && attribute.Value == value) return enumValue;
        }

        throw new Exception("Error not found StartShip");
    }
}