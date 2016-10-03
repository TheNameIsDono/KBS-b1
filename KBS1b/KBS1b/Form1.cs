using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace KBS1b {
    public partial class Form1 : Form {
        private Image img;
        private PointF point;
        private int x = 20;
        private int y = 20;
        private int maxX = 500; //speelveld
        private int maxY = 500; //speelveld




        public Form1() {
            InitializeComponent();
            this.img = Image.FromFile(@"E:\GitHub\KBS-b1\KBS1b\KBS1b\kappa.png"); ;
            this.point = new PointF(x, y);

        }

        private void Form1_Load(object sender, EventArgs e) {


        }
        public void collision() {
            if (x <= 0) {
                x = 0;
            } else if (x >= maxX) {
                x = maxX;
            }
            if (y <= 0) {
                y = 0;
            } else if (y >= maxY) {
                y = maxY;
            }



        }

        protected override void OnPaint(PaintEventArgs e) {
            collision();
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            Pen p = new Pen(Color.Black, 20);
            //dc.DrawRectangle(p, 10 + x,10 + y,20,20);
            dc.DrawImage(img, point);
        }
        //private void Form1_ResizeEnd(object sender, EventArgs e) {
        //    boundary[1] = new Point(this.Width, 0);
        //    boundary[2] = new Point(0, this.Height);
        //    Invalidate();
        //}

    }
}
