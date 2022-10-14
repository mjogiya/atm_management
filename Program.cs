using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ATM
{
    static class Program
    {
        public static int id = 0;
        public static string db = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mayur\Desktop\c#\ATM\ATM.mdf;Integrated Security=True";
        public static string acno = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
