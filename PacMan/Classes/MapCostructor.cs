using PacMan.Enums;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    class MapCostructor
    {
        public static void Generate(Map map, string fileName)
        {
            string[] mapText = LoadFromFile(fileName);

            if (mapText == null)
                return;
            
            List<Wall> walls = new List<Wall>();
            List<Pickup> pickups = new List<Pickup>();
            List<Enemy> enemies = new List<Enemy>();
            Player player = null;

            for (int i = 0; i < mapText.Length; i++)
            {
                for (int j = 0; j < mapText[i].Length; j++)
                {
                    switch (mapText[i][j])
                    {
                        case '#':
                            walls.Add(new Wall(new Vector2(j, i)));
                            break;
                        case '.':
                            pickups.Add(new Pickup(new Vector2(j, i)));
                            break;
                        case '@':
                            player = new Player(new Vector2(j, i));
                            break;
                        case 'M':
                            Console.WriteLine((Enum.GetName(typeof(EnumColors), enemies.Count)).ToString());
                            ConsoleColor cc = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), (Enum.GetName(typeof(EnumColors), enemies.Count)).ToString());
                            enemies.Add( new Enemy(new Vector2(j, i), cc));
                            break;
                        default:
                            break;
                    }
                }
            }

            map.Width = mapText[0].Length;
            map.Height = mapText.Length;
            map.Obstacles = walls;
            map.Pickups = pickups;
            map.Characters = enemies;
            map.Player = player ?? new Player(new Vector2(0, 0));
        }

        public static string[] LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
                return File.ReadAllLines(fileName).ToArray();
            return null;
        }
    }
}
