using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kbs1b
{
    //hier kunnen alle instellingen van het spel komen.
    //thought in progress.
    class Settings
    {
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Settings()
        {
            speed = 1;
        }


    }
}
