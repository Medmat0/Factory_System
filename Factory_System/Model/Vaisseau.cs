namespace Factory_System.Model;

internal class Vaisseau
{
    public Vaisseau(string name, List<Piece> pieces)
    {
        Name = name;
        Pieces = pieces;
    }

    public string Name { get; set; }
    public List<Piece> Pieces { get; set; }
}