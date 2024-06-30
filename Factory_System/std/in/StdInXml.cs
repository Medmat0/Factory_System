using System.Xml;
using Factory_System.std.@in;

namespace Factory_System;

public class StdInXml : SdtInInterface
{
    public void execute(string? path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) throw new Exception($"Le fichier '{path}' n'existe pas.");

        var commands = ReadCommandsFromXml(path);
        foreach (var command in commands) StdRun.Run(command);
    }

    private List<string> ReadCommandsFromXml(string path)
    {
        var commands = new List<string>();
        var doc = new XmlDocument();
        doc.Load(path);

        var elements = doc.DocumentElement?.ChildNodes;
        if (elements != null)
            foreach (XmlNode element in elements)
                if (element.NodeType == XmlNodeType.Element)
                    commands.Add(element.InnerText);

        return commands;
    }
}