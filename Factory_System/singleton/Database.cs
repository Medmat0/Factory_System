using Factory_System.structure.data;
using Factory_System.structure.piece;

namespace Factory_System.singleton;

public class Database
{
    public List<StarShipStruct> StarShipStructs { get; } = new();

    public Dictionary<string, StructAssembly> Assemblies { get; } = new();

    public List<NumberHull> ListHulls { get; } = new();
    public List<NumberWing> ListWings { get; } = new();
    public List<NumberThruster> ListThrusters { get; } = new();
    public List<NumberEngine> ListEngines { get; } = new();


    public bool AddNewStarShip(StarShipStruct starShipStruct)
    {
        for (var i = 0; i < StarShipStructs.Count; i++)
            if (StarShipStructs[i].StartShipName == starShipStruct.StartShipName)
            {
                var number = StarShipStructs[i].Number;
                StarShipStructs.RemoveAt(i);
                StarShipStructs.Add(
                    new StarShipStruct(
                        starShipStruct.Name,
                        starShipStruct.StartShipName,
                        starShipStruct.Wing,
                        starShipStruct.Thruster,
                        starShipStruct.Engine,
                        starShipStruct.Hull,
                        number + 1
                    )
                );
                return true;
            }

        StarShipStructs.Add(starShipStruct);


        return true;
    }

    public bool AddNewStarShips(StarShipStruct starShipStruct)
    {
        for (var i = 0; i < StarShipStructs.Count; i++)
            if (StarShipStructs[i].StartShipName == starShipStruct.StartShipName)
            {
                var number = StarShipStructs[i].Number;
                StarShipStructs.RemoveAt(i);
                StarShipStructs.Add(
                    new StarShipStruct(
                        starShipStruct.Name,
                        starShipStruct.StartShipName,
                        starShipStruct.Wing,
                        starShipStruct.Thruster,
                        starShipStruct.Engine,
                        starShipStruct.Hull,
                        number + starShipStruct.Number
                    )
                );
                return true;
            }

        StarShipStructs.Add(starShipStruct);


        return true;
    }

    public bool AddNewAssembly(StructAssembly structAssembly, string name)
    {
        return Assemblies.TryAdd(name, structAssembly);
    }

    public bool AddNewAssembly(StructAssembly structAssembly)
    {
        return Assemblies.TryAdd(structAssembly.ToString(), structAssembly);
    }

    public bool RemoveAssembly(string name)
    {
        return Assemblies.Remove(name);
    }


    public bool AddNewPiece(Wing wing)
    {
        for (var i = 0; i < ListWings.Count; i++)
            if (ListWings[i].Wing.ToString() == wing.ToString())
            {
                var number = ListWings[i].Number;
                ListWings.RemoveAt(i);
                ListWings.Add(new NumberWing(number + 1, wing));
                return true;
            }

        ListWings.Add(new NumberWing(wing));
        return true;
    }

    public bool AddNewPiece(Wing wing, int number)
    {
        for (var i = 0; i < ListWings.Count; i++)
            if (ListWings[i].Wing.ToString() == wing.ToString())
            {
                var numberActually = ListWings[i].Number;
                ListWings.RemoveAt(i);
                ListWings.Add(new NumberWing(number + numberActually, wing));
                return true;
            }

        ListWings.Add(new NumberWing(number, wing));
        return true;
    }

    public int NumberPiece(Wing wing)
    {
        foreach (var t in ListWings.Where(t => t.Wing.ToString() == wing.ToString()))
            return t.Number;

        return -1;
    }

    public int NumberPiece(Engine engine)
    {
        foreach (var t in ListEngines.Where(t => t.Engine.ToString() == engine.ToString()))
            return t.Number;

        return -1;
    }

    public int NumberPiece(Thruster thruster)
    {
        foreach (var t in ListThrusters.Where(t => t.Thruster == thruster))
            return t.Number;

        return -1;
    }

    public int NumberPiece(Hull hull)
    {
        foreach (var t in ListHulls.Where(t => t.Hull == hull))
            return t.Number;

        return -1;
    }


    public bool AddNewPiece(Engine engine, int number)
    {
        for (var i = 0; i < ListEngines.Count; i++)
            if (ListEngines[i].Engine == engine)
            {
                var numberActually = ListEngines[i].Number;
                ListEngines.RemoveAt(i);
                ListEngines.Add(new NumberEngine(number + numberActually, engine));
                return true;
            }

        ListEngines.Add(new NumberEngine(number, engine));
        return true;
    }


    public bool AddNewPiece(Thruster thruster, int number)
    {
        for (var i = 0; i < ListThrusters.Count; i++)
            if (ListThrusters[i].Thruster == thruster)
            {
                var numberActually = ListThrusters[i].Number;
                ListThrusters.RemoveAt(i);
                ListThrusters.Add(new NumberThruster(number + numberActually, thruster));
                return true;
            }

        ListThrusters.Add(new NumberThruster(number, thruster));
        return true;
    }


    public bool AddNewPiece(Hull hull, int number)
    {
        for (var i = 0; i < ListHulls.Count; i++)
            if (ListHulls[i].Hull == hull)
            {
                var numberActually = ListHulls[i].Number;
                ListHulls.RemoveAt(i);
                ListHulls.Add(new NumberHull(number + numberActually, hull));
                return true;
            }

        ListHulls.Add(new NumberHull(number, hull));
        return true;
    }

    public bool DeletePieces(Hull hull, int number)
    {
        for (var i = 0; i < ListHulls.Count; i++)
            if (ListHulls[i].Hull == hull)
            {
                var numberActually = ListHulls[i].Number;
                ListHulls.RemoveAt(i);
                if (numberActually > number) ListHulls.Add(new NumberHull(numberActually - number, hull));
                return true;
            }

        return true;
    }

    public bool DeletePieces(Wing wing, int number)
    {
        for (var i = 0; i < ListWings.Count; i++)
            if (ListWings[i].Wing == wing)
            {
                var numberActually = ListWings[i].Number;
                ListWings.RemoveAt(i);
                if (numberActually > number) ListWings.Add(new NumberWing(numberActually - number, wing));

                return true;
            }

        return true;
    }

    public bool DeletePieces(Engine engine, int number)
    {
        for (var i = 0; i < ListEngines.Count; i++)
            if (ListEngines[i].Engine == engine)
            {
                var numberActually = ListEngines[i].Number;
                ListEngines.RemoveAt(i);
                if (numberActually > number) ListEngines.Add(new NumberEngine(numberActually - number, engine));
                return true;
            }

        return true;
    }

    public bool DeletePieces(Thruster thruster, int number)
    {
        for (var i = 0; i < ListThrusters.Count; i++)
            if (ListThrusters[i].Thruster == thruster)
            {
                var numberActually = ListThrusters[i].Number;
                ListThrusters.RemoveAt(i);
                if (numberActually > number) ListThrusters.Add(new NumberThruster(numberActually - number, thruster));
                return true;
            }

        return true;
    }


    public override string ToString()
    {
        var content =
            StarShipStructs.Aggregate("", (current, startship) => current + Line(startship.Number, startship.Name));
        content = ListWings.Aggregate(content, (current, wing) => current + Line(wing.Number, wing.Wing.ToString()));
        content = ListHulls.Aggregate(content, (current, hull) => current + Line(hull.Number, hull.Hull.ToString()));
        content = ListEngines.Aggregate(content,
            (current, engine) => current + Line(engine.Number, engine.Engine.ToString()));
        foreach (var assembly in Assemblies) content += Line(1, assembly.Key);
        return ListThrusters.Aggregate(content,
            (current, thruster) => current + Line(thruster.Number, thruster.Thruster.ToString()));
    }

    private string Line(int number, string name)
    {
        return $"{number} {name}\n";
    }
}