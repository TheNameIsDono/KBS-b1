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
        private int x = 100;
        private int y = 100;
        private int maxX = 100; //speelveld
        private int maxY = 100; //speelveld
        private int 
       
        

        public Form1() {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e) {
           

        }
        private void collision() {
            if (x <= 0) {
                x = 0;
            }else if(x >= maxX){
                x = maxX;
            }
            if (y <= 0) {
                y = 0;
            }else if (y >= maxY) {
                y = maxY;
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            collision();
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            Pen p = new Pen(Color.Black, 20);
            dc.DrawRectangle(p, 10 + x,10 + y,20,20);
        }
        //private void Form1_ResizeEnd(object sender, EventArgs e) {
        //    boundary[1] = new Point(this.Width, 0);
        //    boundary[2] = new Point(0, this.Height);
        //    Invalidate();
        //}

    }
}
