using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class Pickup : IEntity,  IPickup
    {
        public int ScoreValue { get; set; }
        public char Graphycs { get; set; }
        public ConsoleColor Color { get; set; }
        public Vector2 Position { get; set; }

        public Pickup(Vector2 pos)
        {
            ScoreValue = 1;
            Graphycs = '.';
            Color = ConsoleColor.Yellow;
            Position = pos;
        }
    }
}
