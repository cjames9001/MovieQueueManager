using System;
using System.Windows.Forms;

namespace MovieQueueManagerGUI
{
    static class MovieQueue
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //original here
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            form1.Text = "Queue Manager";
            Application.Run(form1);
        }
    }
}
