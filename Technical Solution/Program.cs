using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technical_Solution
{
    public static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Forms.MainWindow = new Main();
            Forms.L_Menu = new LoadMenu();
            Forms.Box_Menu = new BoxMenu();
            Application.Run(Forms.MainWindow);
        }
    }

    public static class Forms
    {
        public struct JSONContainer
        {
            public Garage garage;
            public List<Box> Box_Queue;
        }

        public static Main MainWindow;
        public static LoadMenu L_Menu;
        public static BoxMenu Box_Menu;
    }
}
