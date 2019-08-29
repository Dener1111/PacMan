using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    static class Drawer
    {
        public static void DrawArray(IEnumerable<IEntity> array)
        {
            foreach (var item in array)
                DrawSingle(item);
        }

        public static void DrawSingle(IEntity entity)
        {
            SetColors(entity.Color);

            CursorPos(entity.Position);
            Console.Write(entity.Graphycs);
        }

        public static void ClearSelf(Vector2 pos)
        {
            CursorPos(pos);
            Console.Write(" ");
        }

        static void SetColors(ConsoleColor color)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = color;
        }

        static void CursorPos(Vector2 pos) => Console.SetCursorPosition((int)pos.X, (int)pos.Y);
    }
}
