using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    class Wall : IEntity, IObstacle
    {
        public char Graphycs { get; set; }
        public ConsoleColor Color { get; set; }
        public Vector2 Position { get; set; }

        public Wall(Vector2 pos)
        {
            Graphycs = '#';
            Color = ConsoleColor.White;
            Position = pos;
        }
    }
}
