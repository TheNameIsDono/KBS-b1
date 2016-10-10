using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kbs1b
{
    public class ObstacleS
    {
        private int xPos;
        private int yPos;
        private int speed;
        private int height;
        private int width;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
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

        public ObstacleS(int x, int y, int width, int height)
        {
            this.width = width;
            xPos = x;
            yPos = y;
            this.height = height;
        }
    }
}
