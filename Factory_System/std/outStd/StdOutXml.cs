using System.Xml;


namespace Factory_System.std.outStd;

public class StdOutXml : IStdOutInterface
{
    private string Path { get; set; }

    public void Display(string output)
    {
        // Charger le fichier XML
        var doc = new XmlDocument();
        try
        {
            doc.Load(Path);
            WriteToXmlFile(doc, Path, output);
        }
        catch (XmlException ex)
        {
            if (ex.Message.Contains("Root element is missing")) CreateNewXmlFile(Path);
        }
    }

    public void Init(string? path)
    {
        Path = path ?? throw new Exception("I don't have path");
    }


    private static void CreateNewXmlFile(string filePath)
    {
        var doc = new XmlDocument();
        var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        var rootElement = doc.CreateElement("Contents");
        doc.InsertBefore(xmlDeclaration, doc.DocumentElement);
        doc.AppendChild(rootElement);
        doc.Save(filePath);
        Console.WriteLine("Nouveau fichier XML créé avec succès.");
    }

    private static void WriteToXmlFile(XmlDocument doc, string filePath, string output)
    {
        var newElement = doc.CreateElement("Content");
        newElement.InnerText = output;
        doc.DocumentElement?.AppendChild(newElement);
        doc.Save(filePath);
    }
}