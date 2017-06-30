using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DispStudio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Loader loader = new Loader();
            loader.Run();
        }
    }
}
