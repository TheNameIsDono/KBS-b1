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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HoofdMenu hMenu = new HoofdMenu();
            Application.Run(hMenu); 
            if(hMenu.getSpelGestart())
            {
                Application.Run(new Form1());
            }
            if (hMenu.getExitGeklikt()) { x = 1; }
            while(x < 1)
            {
                HoofdMenu hoMenu = new HoofdMenu();
                Application.Run(hoMenu);
                if (hoMenu.getSpelGestart())
                {
                    Application.Run(new Form1());
                }
                if(hoMenu.getExitGeklikt()) { x = 1; }
            }
    }
        }
}
