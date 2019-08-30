using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class EnemyAI
    {
        public Enemy Enemy { get; set; }
        public Vector2 Chase { get; set; }

        int timeStepSpeedMS = 400;

        public void Start(Object stateInfo)
        {
            Chase = Vector2.Zero;
            Vector2 predictedPass = Vector2.Zero;
            while (true)
            {
                float distance = 999;

                if (Enemy.MoveDir != Vector.down() && LevelController.lc.CheckMapBool(LevelController.lc.Map.Obstacles, Enemy.Position + Vector.up()))
                {
                    float tmpD = Vector2.Distance(Enemy.Position + Vector.up(), Chase);
                    if (tmpD < distance)
                    {
                        distance = tmpD;
                        predictedPass = Vector.up();
                    }
                }
                if (Enemy.MoveDir != Vector.left() && LevelController.lc.CheckMapBool(LevelController.lc.Map.Obstacles, Enemy.Position + Vector.right()))
                {
                    float tmpD = Vector2.Distance(Enemy.Position + Vector.right(), Chase);
                    if (tmpD < distance)
                    {
                        distance = tmpD;
                        predictedPass = Vector.right();
                    }
                }
                if (Enemy.MoveDir != Vector.up() && LevelController.lc.CheckMapBool(LevelController.lc.Map.Obstacles, Enemy.Position + Vector.down()))
                {
                    float tmpD = Vector2.Distance(Enemy.Position + Vector.down(), Chase);
                    if (tmpD < distance)
                    {
                        distance = tmpD;
                        predictedPass = Vector.down();
                    }
                }
                if (Enemy.MoveDir != Vector.right() && LevelController.lc.CheckMapBool(LevelController.lc.Map.Obstacles, Enemy.Position + Vector.left()))
                {
                    float tmpD = Vector2.Distance(Enemy.Position + Vector.left(), Chase);
                    if (tmpD < distance)
                    {
                        distance = tmpD;
                        predictedPass = Vector.left();
                    }
                }

                Enemy.MoveDir = predictedPass;
                LevelController.lc.MoveEntity(Enemy, predictedPass);

                Thread.Sleep(timeStepSpeedMS);
            }
        }
    }
}
