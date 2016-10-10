using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kbs1b
{
    public partial class HoofdMenu : Form
    {
        private bool SpelGestart = false;
        private bool ExitGeklikt = false;
        public int GekozenControls;
        public HoofdMenu(int C)
        {
            InitializeComponent();
            GekozenControls = C;
        }

        public bool getSpelGestart() { return SpelGestart; }
        public bool getExitGeklikt() { return ExitGeklikt; }
        public int getGekozenControls() { return GekozenControls; }

        private void HoofdMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpelGestart = true;
            this.Close();
        }

        private void ControllsButton_Click(object sender, EventArgs e)
        {
            if(GekozenControls == 0)
            {
                GekozenControls = 1;
                MessageBox.Show(String.Format("Je controls zijn nu de pijltjestoetsen"));

            }
            else if(GekozenControls == 1)
            {
                GekozenControls = 0;
                MessageBox.Show(String.Format("Je controls zijn nu W A S D"));
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitGeklikt = true;
            this.Close();
        }
    }
}
