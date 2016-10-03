using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace kbs1b
{
    public partial class Form1 : Form
    {
        static int count = 0;
        bool explode = false;
        bool richtingDown = true;
        Image explosion = Properties.Resources.explosion;
        Input input = new Input('W', 'A', 'S', 'D');
        Settings settings = new Settings();
        Player player1;
        private List<Player> players = new List<Player>();
        private List<Obstacle> obstacles = new List<Obstacle>();
        public Obstacle obstacle1, obstacle2,obstacle3, obstacle4, obstacle5, obstacle6;
        int xMax, yMax;
        public Form1()
        {
            InitializeComponent();
            obstacle1 = new Obstacle(5, 100, 100, 50);
            obstacle2 = new Obstacle(2, 200, 100, 50);
            obstacle3 = new Obstacle(5, 300, 100, 50);
            obstacle4 = new Obstacle(2, 400, 100, 50);
            obstacle5 = new Obstacle(5, 500, 100, 50);
            obstacle6 = new Obstacle(2, 600, 100, 50);
            obstacles.Add(obstacle1); obstacles.Add(obstacle2);
            obstacles.Add(obstacle3); obstacles.Add(obstacle4);
            obstacles.Add(obstacle5); obstacles.Add(obstacle6);
            player1 = new Player(input);
            player1.COLOR = Color.Green;
            players.Add(player1);
            xMax = pbCanvas.Size.Width - 35;
            yMax = pbCanvas.Size.Height - 35;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Keyvalue: " + e.KeyValue.ToString());
            foreach (Player player in players)
            {
                //Console.WriteLine("player key: " + player.input.Up);

                if (e.KeyValue == player.input.Up)
                {
                    player.up = true;
                    return;
                }

                if (e.KeyValue == player.input.Down)
                {
                    player.down = true;
                    return;

                }

                if (e.KeyValue == player.input.Left)
                {
                    player.left = true;
                    return;

                }

                if (e.KeyValue == player.input.Right)
                {
                    player.right = true;
                    return;

                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Player player in players)
            {
                if (e.KeyValue == player.input.Up)
                {
                    player.up = false;

                }

                if (e.KeyValue == player.input.Down)
                {
                    player.down = false;

                }

                if (e.KeyValue == player.input.Left)
                {
                    player.left = false;

                }

                if (e.KeyValue == player.input.Right)
                {
                    player.right = false;

                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Player player in players)
            {
                if (player.up)
                {

                    if (player.YPOS - settings.Speed >= settings.Speed)
                    {
                        player.YPOS -= settings.Speed;

                    }
                    else
                    {
                        player.YPOS = 0;
                    }

                }
                if (player.left)
                {

                    if (player.XPOS - settings.Speed >= settings.Speed)
                    {

                        player.XPOS -= settings.Speed;

                    }
                    else
                    {
                        player.XPOS = 0;
                    }
                }
                if (player.right)
                {

                    if (player.XPOS + settings.Speed <= xMax)
                    {

                        player.XPOS += settings.Speed;

                    }
                    else
                    {
                        player.XPOS = xMax;
                    }
                }
                if (player.down)
                {

                    if (player.YPOS + settings.Speed <= yMax)
                    {
                        player.YPOS += settings.Speed;

                    }
                    else
                    {
                        player.YPOS = yMax;
                    }

                }
                pbCanvas.Invalidate();
                
            }




            if (obstacles.Any())
            {
                for (int i = obstacles.Count - 1; i >= 0; i--)
                {
                    //obstacles op en neer laten bewegen, 
                    //switchen zodra de maximale hoogte door een blok is bereikt
                    if (obstacles[i].YPOS <= pbCanvas.Size.Height - 50 && richtingDown) 
                    {
                        obstacles[i].YPOS += obstacles[i].Speed;
                    }
                    else {
                        richtingDown = false;
                    }

                    if (obstacles[i].YPOS >= 0 && !richtingDown)
                    {
                        obstacles[i].YPOS -= obstacles[i].Speed;

                    }
                    else {
                        richtingDown = true;

                    }
                   
                   //check for collision
                    if ((player1.XPOS + 35) >= obstacles[i].XPOS && (player1.XPOS) <= (obstacles[i].XPOS + obstacles[i].Size + 10) &&
                        (player1.YPOS + 35) >= obstacles[i].YPOS && (player1.YPOS) <= obstacles[i].YPOS + obstacles[i].Size + 10
                        ||
                        ((obstacles[i].XPOS + obstacles[i].Size + 10) >= player1.XPOS && (obstacles[i].XPOS) <= (player1.XPOS + 35)
                        && (obstacles[i].YPOS + obstacles[i].Size + 10) >= player1.YPOS && (obstacles[i].YPOS) <= player1.YPOS + 35))
                    {
                        explode = true;
                        obstacles.Remove(obstacles[i]);
                        pbCanvas.Invalidate();
                        timer1.Interval = 1000;
                        count++;
                        return;
                        


                    }
                    else
                    {
                        explode = false;
                        timer1.Interval = 1;

                    }

                    
                }


            }
            else
            {

                explode = false;
                timer1.Interval = 1;
            }
            //check if finish is reached. if yes: stop the game.
            if (player1.XPOS >= 530 && player1.XPOS <= 600 && player1.YPOS >= 280 && player1.YPOS <=350) {
                timer1.Stop();
                player1.XPOS = 555;
                player1.YPOS = 325;
                if (count == 1)
                {
                    MessageBox.Show(String.Format("WELL DONE, {0} Life lost", count));

                }
                else
                {
                    MessageBox.Show(String.Format("WELL DONE, {0} Lives lost", count));
                }
            }



        }
        public void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            {
                //teken het start en finish punt op het speelveld
                e.Graphics.DrawImage(pbCanvas.start, 0, 0);
                e.Graphics.DrawImage(pbCanvas.finish, 550, 300);

                //teken de speler op het veld
                foreach (Player player in players)
                {

                    Image img = Properties.Resources.kappa;
                    PointF point = new PointF(player.XPOS, player.YPOS);
                    //Rectangle rect = new Rectangle(player.XPOS, player.YPOS, 25, 25);
                    //Color color = Color.FromArgb(255, 255, 0, 0);
                    //Pen pen = new Pen(player.COLOR, 10);
                    e.Graphics.DrawImage(img, point);



                }

                //teken de obstacles op het veld.
                foreach (Obstacle ob in obstacles)
                {
                    Rectangle rect1 = new Rectangle(ob.XPOS, ob.YPOS, ob.Size, ob.Size);
                    Color color = Color.FromArgb(255, 255, 0, 0);
                    Pen pen1 = new Pen(color, 10);
                    e.Graphics.DrawRectangle(pen1, rect1);
                }

                //als een obstacle is geraakt, toon dan explosie.
                if (explode)
                {

                    e.Graphics.DrawImage(explosion, player1.XPOS-32, player1.YPOS-32);
                    explode = false;




                }

            }
        }


        
    }
}

