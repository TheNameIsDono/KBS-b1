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
        Image bush = Properties.Resources.Bush;
        Image bushver = Properties.Resources.Bushvertical;
        Image bushverext = Properties.Resources.Bushverext;
        Image bushext = Properties.Resources.Bushext;
        Input input = new Input('W', 'A', 'S', 'D', 'P');
        Settings settings = new Settings();
        Player player1;
        private List<Player> players = new List<Player>();
        private List<Obstacle> obstacles = new List<Obstacle>();
        private List<ObstacleS> obstaclesS = new List<ObstacleS>();
        public ObstacleS obstacle7, obstacle8;
        public Obstacle obstacle1, obstacle2, obstacle3, obstacle4, obstacle5, obstacle6;
        int xMax, yMax;
        PauzeMenu p = new PauzeMenu();
       


        private void pbCanvas_Click(object sender, EventArgs e) {

        }

        public Form1()
        {
            InitializeComponent();
            
            obstacle1 = new Obstacle(4, 100, 150, 50, 1);
            obstacle2 = new Obstacle(2, 200, 70, 50, 2);
            obstacle3 = new Obstacle(4, 300, 150, 50, 1);
            obstacle4 = new Obstacle(2, 400, 100, 50, 3);
            obstacle5 = new Obstacle(4, 500, 200, 50, 2);
            obstacle6 = new Obstacle(2, 600, 100, 50, 1);
            obstacles.Add(obstacle1); obstacles.Add(obstacle2);
            obstacles.Add(obstacle3); obstacles.Add(obstacle4);
            obstacles.Add(obstacle5); obstacles.Add(obstacle6);

            obstacle7 = new ObstacleS(162, 90, 25, 125);
            obstacle8 = new ObstacleS(360, 160, 25, 125);
            obstaclesS.Add(obstacle7); obstaclesS.Add(obstacle8);

            player1 = new Player(input);
           // player1.COLOR = Color.Green;
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
                if (e.KeyValue == player.input.ESC) {
                    player.esc = true;
                    p.setLevelPause(true);
                    if (p.getLevelPause() == true) {
                       p.ShowDialog();
                        player.esc = false;
                    }

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
                if (e.KeyValue == player.input.ESC) {
                    player.esc = false;
                    
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p.getLevelExit()) {

                this.Close();
            }
            //while (p.getLevelPause() == true) { Thread.Sleep(0); }
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
                if (player.esc) {

                }
                
                pbCanvas.Invalidate();
                
                
            }
           
            if (obstaclesS.Any())
            {
                for (int i = obstaclesS.Count - 1; i >= 0; i--)
                {
                    //Check for collision with non-moving obstaclesS.
                    if ((player1.XPOS + 35) >= obstaclesS[i].XPOS && (player1.XPOS) <= (obstaclesS[i].XPOS + obstaclesS[i].Width + 1) &&
                    (player1.YPOS + 35) >= obstaclesS[i].YPOS && (player1.YPOS) <= obstaclesS[i].YPOS + obstaclesS[i].Height + 1
                    ||
                    ((obstaclesS[i].XPOS + obstaclesS[i].Width + 1) >= player1.XPOS && (obstaclesS[i].XPOS) <= (player1.XPOS + 35)
                    && (obstaclesS[i].YPOS + obstaclesS[i].Height + 1) >= player1.YPOS && (obstaclesS[i].YPOS) <= player1.YPOS + 35))
                    {
                        pbCanvas.Invalidate();
                        timer1.Interval = 350;
                        player1.XPOS = 45;
                        player1.YPOS = 90;
                        return;
                    }
                }
            }
            

            if (obstacles.Any())
            {
                for (int i = obstacles.Count - 1; i >= 0; i--)
                {
                    //Call to move() method on each obstacle in the obstacle[] List
                    //Also give a reference to the required variables
                    obstacles[i].move(ref yMax, ref xMax, ref richtingDown, ref player1);
                   
                   //check for collision with moving obstacles                                
                    if ((player1.XPOS + 35) >= obstacles[i].XPOS && (player1.XPOS) <= (obstacles[i].XPOS + obstacles[i].Size + 10) &&
                        (player1.YPOS + 35) >= obstacles[i].YPOS && (player1.YPOS) <= obstacles[i].YPOS + obstacles[i].Size + 10
                        ||
                        ((obstacles[i].XPOS + obstacles[i].Size + 10) >= player1.XPOS && (obstacles[i].XPOS) <= (player1.XPOS + 35)
                        && (obstacles[i].YPOS + obstacles[i].Size + 10) >= player1.YPOS && (obstacles[i].YPOS) <= player1.YPOS + 35))
                    {
                        explode = true;
                        obstacles.Remove(obstacles[i]);
                        pbCanvas.Invalidate();
                        timer1.Interval = 350;
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
            if (player1.XPOS >= 530 && player1.XPOS <= 600 && player1.YPOS >= 240 && player1.YPOS <=310) {
                timer1.Stop();
                player1.XPOS = 555;
                player1.YPOS = 325;
                if (count == 1)
                {
                    //MessageBox.Show(String.Format("WELL DONE, {0} Life lost", count));
                    timer1.Interval = 100;
                    this.Close();
                    

                }
                else
                {
                    //MessageBox.Show(String.Format("WELL DONE, {0} Lives lost", count));
                    timer1.Interval = 100;
                    this.Close();
                }
            }
            
            

        }
        public void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            {
                //teken het start en finish punt op het speelveld
                e.Graphics.DrawImage(pbCanvas.start, 40, 40);
                e.Graphics.DrawImage(pbCanvas.finish, 570, 270);
                e.Graphics.DrawImage(bushext, 0, 0);
                e.Graphics.DrawImage(bushext, 0, 340);
                e.Graphics.DrawImage(bushverext, 630, 0);
                e.Graphics.DrawImage(bushverext, 0, 0);

                //e.Graphics.DrawImage(bushver, 160, 70);
                //e.Graphics.DrawImage(bushver, 360, 180);

                //teken de speler op het veld
                foreach (Player player in players)
                {

                    Image img = Properties.Resources.kappa;
                    PointF point = new PointF(player.XPOS, player.YPOS);
                    //Rectangle rect = new Rectangle(player.XPOS, player.YPOS, 25, 25);
                    //Color color = Color.FromArgb(255, 255, 0, 0);
                    //Pen pen = new Pen(player.COLOR, 10);
                    e.Graphics.DrawImage(img, point);

                    if (player1.XPOS < 30 || player1.XPOS > 600) {
                        player1.XPOS = 45;
                        player1.YPOS = 90;
                    }

                    if (player1.YPOS < 35 || player1.YPOS > 310) {
                        player1.XPOS = 45;
                        player1.YPOS = 90;
                    }

                    //if (player1.XPOS > 130 && player1.XPOS < 175 && player1.YPOS > 65 && player1.YPOS < 190) {
                    //    player1.XPOS = 45;
                    //    player1.YPOS = 90;
                    //}


                }

                //teken de obstacles op het veld.
                foreach (Obstacle ob in obstacles)
                {
                    Image spikes = Properties.Resources.Spike;
                    PointF point2 = new PointF((float)ob.XPOS - 12, (float)ob.YPOS - 12);
                    //Rectangle rect1 = new Rectangle(ob.XPOS, ob.YPOS, ob.Size, ob.Size);
                    //Color color = Color.FromArgb(255, 255, 0, 0);
                    //Pen pen1 = new Pen(color, 10);
                    //e.Graphics.DrawRectangle(pen1, rect1);
                    e.Graphics.DrawImage(spikes, point2);
                }

                //tekent de obstaclesS op het veld
                foreach (ObstacleS obs in obstaclesS)
                {
                    Image wall = Properties.Resources.Bushvertical;
                    PointF point3 = new PointF((float)obs.XPOS - 2, (float)obs.YPOS - 5);
                    //Rectangle rect2 = new Rectangle(obs.XPOS, obs.YPOS, obs.Width, obs.Height);
                    //Color color = Color.FromArgb(255, 255, 0, 0);
                    //Pen pen1 = new Pen(color, 10);
                    //e.Graphics.DrawRectangle(pen1, rect2);
                    e.Graphics.DrawImage(wall, point3);
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

