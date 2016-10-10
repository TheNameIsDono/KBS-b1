using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kbs1b
{
    class Level
    {
        private Player player;
        private List<Obstacle> obstacles;

        internal Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<Obstacle> Obstacles
        {
            get { return obstacles; }
        }

        public void addObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }

        public Level(Player player)
        {
            this.player = player;
            this.obstacles = new List<Obstacle>();
        }

    }
}
