using Factory_System.structure.@enum;

namespace Factory_System.structure.data;

public class NumberAssembly : Pieces
{
    

    public String Name { get; }
    
    public TypePiece TypePiece { get; } = TypePiece.Assembly;
    
    
    public NumberAssembly( string name)
    {
        Name = name;
    }

    public override int NumberPieces()
    {
        return 1;
    }

    public override Pieces WithAddNumber(int number)
    {
        return new NumberAssembly(Name);
    }

    public override Pieces WithMultiplyNumber(int number)
    {
        return new NumberAssembly(Name);
    }

    public override Pieces WithRemoveNumber(int number)
    {
        return new NumberAssembly(Name);
    }

    public override string TypePiecePrecise()
    {
        return Name;
    }

    public override string View()
    {
        return 1 + " " + TypePiecePrecise();
    }
    
    public override string FindTypePiece()
    {
        return TypePiece.ToString();
    }
}