using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class Player : IEntity, ICharacter
    {
        public char Graphycs {get; set; }
        public ConsoleColor Color { get; set; }
        public Vector2 Position { get; set; }

        public Player(Vector2 pos)
        {
            Graphycs = '@';
            Color = ConsoleColor.Yellow;
            Position = pos;
        }
    }
}
