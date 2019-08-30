using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IEnumerable<IEntity> Obstacles { get; set; }
        public IEnumerable<IEntity> Pickups { get; set; }
        public IEnumerable<IEntity> Characters { get; set; }
        public Player Player { get; set; }
    }
}
