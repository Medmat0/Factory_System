using Factory_System.Model;
using Factory_System.Model.@enum;
using Factory_System.parse;
using Factory_System.singleton;
using Factory_System.structure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System.runCommand
{
    public class InstructionsRunCommand : ICommandRun
    {
        private Dictionary<StartShipName, StarShipStruct> StarShipStructs { get; }

        private CookBook AvailableVaisseaux { get; } = Singleton<CookBook>.Instance;

        public InstructionsRunCommand(string args)
        {
            var temp = new ParseStarShip(args);
            temp.Parse();
            StarShipStructs = temp.StarShipStructs;
        }

        public void Run()
        {
            InstructionsCommand(StarShipStructs);
        }

        public bool InstructionsCommand(Dictionary<StartShipName, StarShipStruct> vaisseauxQuantites)
        {
            foreach (var kvp in vaisseauxQuantites)
            {
                var vaisseauName = kvp.Key;
                var quantity = kvp.Value;

                bool found = false;
                foreach (StarShipStruct vaisseau in AvailableVaisseaux.ListStarShipStructs)
                {
                    if (vaisseau.Name == vaisseauName.ToString())
                    {
                        found = true;

                        Console.WriteLine($"PRODUCING {quantity} {vaisseau.Name}");

                        // Liste pour stocker les assemblages temporaires
                        List<string> assemblies = new List<string>();

                        foreach (Piece piece in vaisseau.Pieces)
                        {
                            assemblies.Add(piece.Name.ToString());
                        }

                        string previousAssembly = null;
                        for (int i = 0; i < assemblies.Count; i++)
                        {
                            string currentPiece = assemblies[i];
                            string currentAssembly = previousAssembly != null ? $"{previousAssembly} {currentPiece}" : currentPiece;
                            string assemblyName = $"TMP{i + 1}";
                            Console.WriteLine($"ASSEMBLE {assemblyName} {currentAssembly}");
                            previousAssembly = assemblyName;
                        }

                        Console.WriteLine($"FINISHED {vaisseau.Name}");

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"ERROR: Vaisseau '{vaisseauName}' n'est pas reconnu");
                    return false;
                }
            }

            return true;
        }
    }
}
