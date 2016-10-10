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
        public HoofdMenu()
        {
            InitializeComponent();
        }

        public bool getSpelGestart() { return SpelGestart; }
        public bool getExitGeklikt() { return ExitGeklikt; }

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

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitGeklikt = true;
            this.Close();
        }
    }
}
