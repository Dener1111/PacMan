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
        int timeStepSpeedMS;

        ConsoleKeyInfo moveKey;

        public Input(Player character)
        {
            CurrentPlayer = character;
            timeStepSpeedMS = 400;
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
                        if(LevelController.lc.MoveEntity(CurrentPlayer, Vector.up()))//change move direction if there wall or something
                            CurrentPlayer.MoveDir = Vector.up();
                        else
                            moveKey = new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false);
                        break;
                    case 's':
                        if(LevelController.lc.MoveEntity(CurrentPlayer, Vector.down()))
                            CurrentPlayer.MoveDir = Vector.down();
                        else
                            moveKey = new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false);
                        break;
                    case 'a':
                        if (LevelController.lc.MoveEntity(CurrentPlayer, Vector.left()))
                            CurrentPlayer.MoveDir = Vector.left();
                        else
                            moveKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
                        break;
                    case 'd':
                        if(LevelController.lc.MoveEntity(CurrentPlayer, Vector.right()))
                            CurrentPlayer.MoveDir = Vector.right();
                        else
                            moveKey = new ConsoleKeyInfo('s', ConsoleKey.S, false, false, false);
                        break;
                    default:
                        break;
                }

                Thread.Sleep(timeStepSpeedMS);

                if (Stop)
                    break;
            }
        }
    }
}
