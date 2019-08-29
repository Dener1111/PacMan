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
        public bool Stop;

        public LevelController(Map map, Input input)
        {
            lc = this;
            Map = map;
            Input = input;

            Console.CursorVisible = false;
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(Input.Start);

            Drawer.DrawArray(Map.Obstacles);
            while (true)
            {
                Clear();

                Drawer.DrawArray(Map.Pickups);
                Drawer.DrawSingle(Map.Player);

                if (Stop)
                {
                    Input.Stop = true;
                    break;
                }
            }
        }

        //obsolete
        public bool CheckMapBool(IEnumerable<IEntity> arr, Vector2 pos)
        {
            foreach (var item in arr)
                if (item.Position == pos)
                    return true;
            return false;
        }

        public IEntity CheckMapEntity(IEnumerable<IEntity> arr, Vector2 pos)
        {
            foreach (var item in arr)
                if (item.Position == pos)
                    return item;
            return null;
        }

        public void MoveEntity(IEntity ent, Vector2 dir)
        {
            if (CheckMapEntity(Map.Obstacles, ent.Position + dir) != null)
                return;
            if(ent is Player)
            {
                IEntity e = CheckMapEntity(Map.Pickups, ent.Position);
                if (e != null)//redo this shit
                {
                    List<IEntity> tmp = new List<IEntity>( Map.Pickups);
                    tmp.Remove(e);
                    Map.Pickups = tmp;
                }
                //add to score
            }

            toClear.Add(ent.Position);
            ent.Position = ent.Position + dir;
        }

        public void Clear()
        {
            foreach (var item in toClear)
                Drawer.ClearSelf(item);
            toClear.Clear();
        }
    }
}
