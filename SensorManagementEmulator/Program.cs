using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorManagementEmulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// bandomasis komentaras
        /// </summary>ww
        [STAThread]
        static async Task Main()
        {

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "b1192.json");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}