using Factory_System.structure.@enum;

namespace Factory_System.structure.data;

public class StartShip : Pieces
{
    public StartShip(List<Pieces> listPieces, string name, int number)
    {
        ListPieces = listPieces;
        Name = name;
        Number = number;
    }

    
    public StartShip(List<Pieces> listPieces, string name)
    {
        ListPieces = listPieces;
        Name = name;
        Number = 1;
    }
    
    public List<Pieces> ListPieces { get; set; }
    
    public TypePiece TypePiece { get; } = TypePiece.StarShip;

    public string Name { get; }

    public int Number { get; }

    public override int NumberPieces()
    {
        return Number;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new StartShip(ListPieces, Name, Number+ number);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new StartShip(ListPieces, Name, Number * number);
    }

    public override Pieces WithRemoveNumber(int number)
    {
        return new StartShip(ListPieces, Name, Number - number);
    }


    public override string TypePiecePrecise()
    {
        return Name;
    }

    public override string View()
    {
        return Number + " " + TypePiecePrecise();
    }

    public override string FindTypePiece()
    {
        return TypePiece.ToString();
    }
}