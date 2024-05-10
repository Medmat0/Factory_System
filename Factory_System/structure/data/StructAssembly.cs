using System.Reflection;
using Factory_System.structure.piece;

namespace Factory_System.structure.data;

public struct StructAssembly
{
    public Engine? Engine { get; set; }
    public Wing? Wing { get; set; }
    public Hull? Hull { get; set; }
    public Thruster? Thruster { get; set; }

    public StructAssembly()
    {
    }

    private List<object> GetNonNullParts()
    {
        var nonNullParts = new List<object>();

        var properties = typeof(StructAssembly).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var value = property.GetValue(this);
            if (value != null) nonNullParts.Add(value);
        }

        return nonNullParts;
    }

    public override string ToString()
    {
        var nonNullParts = GetNonNullParts();
        var content = "[";

        for (var i = 0; i < nonNullParts.Count; i++)
        {
            content += nonNullParts[i].ToString();
            if (i < nonNullParts.Count - 1) content += ", ";
        }

        content += "]";
        return content;
    }
}