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
    class LevelController
    {
        public static LevelController lc;
        public Map Map { get; set; }
        public Input Input { get; set; }
        public static  List<Vector2> toClear = new List<Vector2>();
        bool redrawPickup;

        int score;

        public bool Stop;

        public LevelController(Map map, Input input)
        {
            lc = this;
            Map = map;
            Input = input;
            redrawPickup = true;

            score = 0;

            Console.CursorVisible = false;
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(Input.Start);

            List<EnemyAI> ai = new List<EnemyAI>();
            for (int i = 0; i < Map.Characters.Count(); i++)
            {
                ai.Add(new EnemyAI { Enemy = (Enemy)Map.Characters.ToList()[i] });
                ThreadPool.QueueUserWorkItem(ai[i].Start);
            }

            Drawer.DrawArray(Map.Obstacles);
            while (true)
            {
                CheckStop();

                SetEnemyPoints(ai);

                lock(LevelController.lc)
                    Clear();

                Drawer.DrawScore(Map.Height, score);

                if (redrawPickup)
                {
                    redrawPickup = false;
                    if (Map.Pickups.Count() == 0)
                        Stop = true;
                    Drawer.DrawArray(Map.Pickups);
                }

                Drawer.DrawArray(Map.Characters);
                Drawer.DrawSingle(Map.Player);

                if (Stop)
                {
                    Input.Stop = true;
                    break;
                }
            }
        }
        
        public bool CheckMapBool(IEnumerable<IEntity> arr, Vector2 pos)
        {
            foreach (var item in arr)
                if (item.Position == pos)
                    return false;
            return true;
        }

        public IEntity CheckMapEntity(IEnumerable<IEntity> arr, Vector2 pos)
        {
            foreach (var item in arr)
                if (item.Position == pos)
                    return item;
            return null;
        }

        public void CheckStop()
        {
            foreach (var item in Map.Characters)
                if (item.Position == Map.Player.Position)
                    Stop = true;
        }

        public void SetEnemyPoints(List<EnemyAI> ai)
        {
            ai[0].Chase = Map.Player.Position;
            ai[1].Chase = Map.Player.Position + Map.Player.MoveDir * 2;
        }

        public bool MoveEntity(IEntity ent, Vector2 dir)
        {
            if (CheckMapEntity(Map.Obstacles, ent.Position + dir) != null)
                return false;
            if(ent is Player)
            {
                IEntity e = CheckMapEntity(Map.Pickups, ent.Position);
                if (e != null)//redo this shit
                {
                    List<IEntity> tmp = new List<IEntity>( Map.Pickups);
                    tmp.Remove(e);
                    Map.Pickups = tmp;
                    score += (e as IPickup).ScoreValue;
                }
            }
            redrawPickup = true;
            lock (LevelController.lc)
                toClear.Add(ent.Position);
            ent.Position = ent.Position + dir;
            return true;
        }

        public void Clear()
        {
            foreach (var item in toClear)
                Drawer.ClearSelf(item);
            toClear.Clear();
        }
    }
}
