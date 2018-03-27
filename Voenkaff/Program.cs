using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voenkaff
{
    static class Program
    {
        public static FormHello FormHello;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var runningProccess = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            if (runningProccess.Count(p => p.ProcessName.Contains("Voenkaff")) > 1)
            {
                MessageBox.Show("Программа уже запущена, невозможно запустить ещё один экземпляр",
                    "Программа уже запущена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormHello = new FormHello();
            Application.Run(FormHello);
        }
    }
}
