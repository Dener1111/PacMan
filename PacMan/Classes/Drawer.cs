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

        public static void DrawScore(int pos, int val)
        {
            CursorPos(new Vector2(0, pos));
            SetColors();
            Console.Write(val);
        }

        public static void DrawGameOver(int posX = 0, int posY = 0, string str = "GAME OVER")
        {
            CursorPos(new Vector2(posX, posY));
            SetColors();
            Console.Write(str);
        }

        static void SetColors(ConsoleColor color = ConsoleColor.White)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = color;
        }

        static void CursorPos(Vector2 pos) => Console.SetCursorPosition((int)pos.X, (int)pos.Y);
    }
}
