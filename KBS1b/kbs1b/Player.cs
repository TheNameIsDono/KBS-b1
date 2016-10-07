using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kbs1b
{
    public class Player
    {


        private int xPos;
        private int yPos;
        //x en yPos vervangen voor point?

        public Color color { set; get; }

        //input stelt de 4 toetsen van de controls voor
        public Input input;

        //middels booleans wordt gekeken of een bepaalde richting is ingedrukt.
        public bool up {set; get;}
        public bool left { set; get; }
        public bool down { set; get; }
        public bool right { set; get; }

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

        public Color COLOR { get; set; }

        public Player(Input input)
        {
            xPos = 45;
            yPos = 90;
           
            this.input = input;
            up = down = left = right = false;
        }


        

        

        
    }
}
