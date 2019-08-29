using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public static class Vector
    {
        public static Vector2 up() => new Vector2(0, -1);
        public static Vector2 down() => new Vector2(0, 1);
        public static Vector2 left() => new Vector2(-1, 0);
        public static Vector2 right() => new Vector2(1, 0);
    }
}
