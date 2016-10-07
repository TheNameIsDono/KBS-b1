using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kbs1b
{
    
    public class Input
    {

        
        public int Up { get; set; }
        public int Left { get; set; }
        public int Down { get; set; }
        public int Right { get; set; }

        

        public Input(char up, char left, char down, char right)
        {

            this.Up = Convert.ToInt32(up);
            this.Left = Convert.ToInt32(left); 
            this.Down = Convert.ToInt32(down);
            this.Right = Convert.ToInt32(right);
            Console.WriteLine(Up + "\n" + Left + "\n" + Down + "\n" + Right);

        }
    }

}

