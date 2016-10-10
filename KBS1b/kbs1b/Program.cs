using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kbs1b
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int x = 0;
            int gekozenControls = 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while(x < 1)
            {
                HoofdMenu loopMenu = new HoofdMenu(gekozenControls);
                Application.Run(loopMenu);
                if (loopMenu.getSpelGestart())
                {
                    gekozenControls = loopMenu.getGekozenControls();
                    Application.Run(new Form1(gekozenControls));
                    
                }
                if(loopMenu.getExitGeklikt()) { x = 1; }
            }
    }
        }
}
