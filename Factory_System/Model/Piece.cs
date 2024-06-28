namespace Factory_System.Model;

internal class Piece
{
    public Piece(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public int Quantity { get; set; }
}