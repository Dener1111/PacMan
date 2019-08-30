using PacMan.Classes;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            MapCostructor.Generate(map, "a.txt");
            Input input = new Input(map.Player);

            LevelController lc = new LevelController(map, input);

            lc.Start();
            Drawer.DrawGameOver(lc.Map.Width / 2, lc.Map.Height / 2);
            Console.Read();
        }
    }
}
