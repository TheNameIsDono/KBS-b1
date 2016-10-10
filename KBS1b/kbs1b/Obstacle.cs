using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace kbs1b {
    public class Obstacle {

        public Form form { get; set; }
        private double xPos;
        private double yPos;
        private double speed;
        private int size;
        public int behaviour { get; set; }
        // Behaviour 1 is stil staan
        // Behaviour 2 is verticaal bewegen
        // Behaviour 3 is horizontaal bewegen
        // Behaviour 4 is achtervolgen

        public int Size {
            get { return size; }
            set { size = value; }
        }


        public double Speed {
            get { return speed; }
            set { speed = value; }
        }


        public double YPOS {
            get { return yPos; }
            set { yPos = value; }
        }


        public double XPOS {
            get { return xPos; }
            set { xPos = value; }
        }

        public Obstacle(int speed, int x, int y, int size, int behaviour) {
            if (x < 0 || y < 0) {
                Console.WriteLine("x or y given below 0!");
                throw new IndexOutOfRangeException();
            }

            this.speed = speed;
            xPos = x;
            yPos = y;
            this.size = size;
            this.behaviour = behaviour;
        }

        public void move(ref int yMax, ref int xMax, ref bool richtingDown, ref Player player) {
            switch (behaviour) {
                case 1:; break; //movement voor stilstaand object is leeg.
                case 2: vertical_move(ref yMax, ref richtingDown); break;
                case 3: horizontal_move(ref xMax, ref richtingDown); break;
                case 4: following_move(ref player); break;
                default: Console.WriteLine("No valid behaviour type!"); break;
            }
        }

        public void vertical_move(ref int yMax, ref bool richtingDown) {
            if (YPOS <= yMax - 50 && richtingDown) {
                YPOS += Speed;
            } else {
                richtingDown = false;
            }

            if (YPOS >= 0 && !richtingDown) {
                YPOS -= Speed;

            } else {
                richtingDown = true;

            }

        }

        public void horizontal_move(ref int xMax, ref bool richtingDown) {
            if (XPOS <= xMax - 50 && richtingDown) {
                XPOS += Speed;
            } else {
                richtingDown = false;
            }

            if (XPOS >= 0 && !richtingDown) {
                XPOS -= Speed;

            } else {
                richtingDown = true;
            }
        }

        /*
         Methode om de afstand tussen twee vectoren te berekenen
         Eerste variabele is de player's X positie en de obstacle's X positie in het kwadraat
         Tweede variabele is de player's Ypositie en de obstacle's Y positie in het kwadraat
         Dit wordt bij elkaar opgeteld en de afstand wordt berekend door hiervan de wortel te nemen
             */
        public double GetDistanceBetweenTwoVectors(double playerXPos, double playerYPos) {
            double temp1 = Math.Pow((playerXPos - XPOS), 2);
            double temp2 = Math.Pow((playerYPos - YPOS), 2);
            double distance = Math.Sqrt(temp1 + temp2);

            return distance;
        }

        public void following_move(ref Player player) {
            double distance = GetDistanceBetweenTwoVectors(player.XPOS, player.YPOS);

            //Wanneer de afstand kleiner of gelijk is aan 150, start met volgen
            if (distance <= 150) {
                if (XPOS <= player.XPOS) {
                    XPOS += 1;
                } else if (XPOS >= player.XPOS) {
                    XPOS -= 1;
                }

                if (YPOS <= player.YPOS) {
                    YPOS += 1;
                }
                if (YPOS >= player.YPOS) {
                    YPOS -= 1;
                }
            }
        }
    }
}
