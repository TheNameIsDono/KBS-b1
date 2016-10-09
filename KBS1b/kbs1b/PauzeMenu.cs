using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kbs1b {
    public partial class PauzeMenu : Form {

        private bool levelExit;
        private bool levelPause = false;
        

        public PauzeMenu() {
            InitializeComponent();
        }

        public bool getLevelExit() { return this.levelExit; }
        public bool getLevelPause() { return this.levelPause; }
        public void setLevelPause(bool x) { this.levelPause = x; }
        public void setLevelExit(bool x) { this.levelExit = x; }

        private void PauzeMenu_Load(object sender, EventArgs e) {

        }

        private void BtnQuit_Click(object sender, EventArgs e) {


            this.levelExit = true;
            this.Close();
        }

        private void BtnResume_Click(object sender, EventArgs e) {
            this.levelPause = false;
            this.Close();
           
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            //code van coen
        }
    }
}
