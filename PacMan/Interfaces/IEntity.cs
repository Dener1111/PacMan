using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PacMan.Interfaces
{
    public interface IEntity
    {
        char Graphycs { get; set; }
        ConsoleColor Color { get; set; }
        Vector2 Position { get; set; }
    }
}
