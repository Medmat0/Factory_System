using Factory_System.Model;
using Factory_System.Model.@enum;
using Factory_System.Model.piece;

namespace Factory_System.structure.data;

public readonly struct StarShipStruct
{
    public StarShipStruct(string name, StartShipName startShipName, List<Piece> pieces, int number)
    {
        if (pieces.Count >= 4)
        {
            throw new ArgumentException("A StarShipStruct can only have 4 pieces or less. ");
        }
        Name = name;
        StartShipName = startShipName;
        Pieces = pieces;
        Number = number;
    }

    public StarShipStruct(string name, StartShipName startShipName, List<Piece> pieces)
    {
        if (pieces.Count >= 4) {
            throw new ArgumentException("A StarShipStruct can only have 4 pieces or less. ");
        }
               
        Name = name;
        StartShipName = startShipName;
        Pieces = pieces;
        Number = 1;
    }

    public string Name { get; }
    public StartShipName StartShipName { get; }
    public List<Piece> Pieces { get; }

    public int Number { get; }

}