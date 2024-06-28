using Factory_System.structure.data;

namespace Factory_System.singleton;

public class Database
{
    public List<NumberThruster> ListThruster { get; } = [];
    public List<NumberEngine> ListEngine { get; } = [];
    public List<NumberWing> ListWing { get; } = [];
    public List<NumberHull> ListHull { get; } = [];
    public List<StartShip> ListStartShip { get; } = [];


    public void AddPiece(Pieces pieces)
    {
        if (Exists(pieces))
        {
            var temps = Find(pieces)!.NumberPieces();
            RemoveTotalPieces(pieces);
            AddInBdd(pieces.WithAddNumber(temps));
        }
        else
        {
            AddInBdd(pieces);
        }
    }

    public int NumberPiece(Pieces pieces)
    {
        if (!Exists(pieces)) return -1;
        return Find(pieces)!.NumberPieces();
    }


    public void RemovePiece(Pieces pieces)
    {
        if (!Exists(pieces)) return;
        var temps = Find(pieces)!;
        if (temps.NumberPieces() < pieces.NumberPieces())
            throw new Exception("Le nombre de pièce a supprimer est trop grand");
        RemoveTotalPieces(pieces);
        if (temps.NumberPieces() > pieces.NumberPieces())
        {
            AddInBdd(temps.WithRemoveNumber(pieces.NumberPieces()));
        }
    }

    private bool Exists(Pieces pieces)
    {
        return pieces switch
        {
            NumberThruster thrusters => ListThruster.Exists(x => x.Thruster == thrusters.Thruster),
            NumberWing wings => ListWing.Exists(x => x.Wing == wings.Wing),
            NumberEngine engines => ListEngine.Exists(x => x.Engine == engines.Engine),
            NumberHull hulls => ListHull.Exists(x => x.Hull == hulls.Hull),
            StartShip ships => ListStartShip.Exists(x => x.Name == ships.Name),
            _ => false
        };
    }

    private Pieces? Find(Pieces pieces)
    {
        return pieces switch
        {
            NumberThruster thrusters => ListThruster.Find(x => x.Thruster == thrusters.Thruster),
            NumberWing wings => ListWing.Find(x => x.Wing == wings.Wing),
            NumberEngine engines => ListEngine.Find(x => x.Engine == engines.Engine),
            NumberHull hulls => ListHull.Find(x => x.Hull == hulls.Hull),
            StartShip ships => ListStartShip.Find(x => x.Name == ships.Name),
            _ => throw new Exception("not exist")
        };
    }

    private void RemoveTotalPieces(Pieces pieces)
    {
        switch (pieces)
        {
            case NumberThruster thrusters:
                var thruster = ListThruster.Find(x => x.Thruster == thrusters.Thruster)!;
                ListThruster.Remove(thruster);
                break;
            case NumberWing wings:
                var wing = ListWing.Find(x => x.Wing == wings.Wing)!;
                ListWing.Remove(wing);
                break;
            case NumberEngine engines:
                var engine = ListEngine.Find(x => x.Engine == engines.Engine)!;
                ListEngine.Remove(engine);
                break;
            case NumberHull hulls:
                var hull = ListHull.Find(x => x.Hull == hulls.Hull)!;
                ListHull.Remove(hull);
                break;
            case StartShip ships:
                var ship = ListStartShip.Find(x => x.Name == ships.Name)!;
                ListStartShip.Remove(ship);
                break;
        }
    }


    private void AddInBdd(Pieces pieces)
    {
        switch (pieces)
        {
            case NumberThruster thrusters:
                ListThruster.Add(thrusters);
                break;
            case NumberWing wings:
                ListWing.Add(wings);
                break;
            case NumberEngine engines:
                ListEngine.Add(engines);
                break;
            case NumberHull hulls:
                ListHull.Add(hulls);
                break;
            case StartShip ship:
                ListStartShip.Add(ship);
                break;
        }
    }

    public override string ToString()
    {
        var content =
            ListStartShip.Aggregate("", (current, startship) => current + Line(startship.Number, startship.Name));
        content = ListWing.Aggregate(content, (current, wing) => current + Line(wing.Number, wing.Wing.ToString()));
        content = ListHull.Aggregate(content, (current, hull) => current + Line(hull.Number, hull.Hull.ToString()));
        content = ListEngine.Aggregate(content,
            (current, engine) => current + Line(engine.Number, engine.Engine.ToString()));
        return ListThruster.Aggregate(content,
            (current, thruster) => current + Line(thruster.Number, thruster.Thruster.ToString()));
    }


    private string Line(int number, string name)
    {
        return $"{number} {name}\n";
    }
}