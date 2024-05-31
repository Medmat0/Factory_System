﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_System.Model
{
    internal class Vaisseau
    {
        public string Name { get; set; }
        public List<Piece> Pieces { get; set; }

        public Vaisseau(string name, List<Piece> pieces)
        {
            Name = name;
            Pieces = pieces;
        }
    }
}
