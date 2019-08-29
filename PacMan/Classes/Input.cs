using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    class Input
    {
        public Player CurrentPlayer { get; set; }
        public bool Stop { get; set; }
        public Vector2 MoveDir;

        ConsoleKeyInfo moveKey;

        public Input(Player character)
        {
            CurrentPlayer = character;
        }

        public void WaitInput(Object stateInfo) => moveKey = Console.ReadKey(true);

        public void Start(Object stateInfo)
        {
            while (true)
            {
                ThreadPool.QueueUserWorkItem(WaitInput);

                switch (moveKey.KeyChar)
                {
                    case 'w':
                        LevelController.lc.MoveEntity(CurrentPlayer, Vector.up());
                        MoveDir = Vector.up();
                        break;
                    case 's':
                        LevelController.lc.MoveEntity(CurrentPlayer, Vector.down());
                        MoveDir = Vector.down();
                        break;
                    case 'a':
                        LevelController.lc.MoveEntity(CurrentPlayer, Vector.left());
                        MoveDir = Vector.left();
                        break;
                    case 'd':
                        LevelController.lc.MoveEntity(CurrentPlayer, Vector.right());
                        MoveDir = Vector.right();
                        break;
                    default:
                        break;
                }

                Thread.Sleep(400);

                if (Stop)
                    break;
            }
        }
    }
}
