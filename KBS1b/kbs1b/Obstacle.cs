using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kbs1b
{
    public class Obstacle
    {
        private int xPos;
        private int yPos;
        private int speed;
        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }


        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        public int YPOS
        {
            get { return yPos; }
            set { yPos = value; }
        }


        public int XPOS
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public Obstacle(int speed, int x, int y, int size)
        {
            this.speed = speed;
            xPos = x;
            yPos = y;
            this.size = size;
        }
    }
}
