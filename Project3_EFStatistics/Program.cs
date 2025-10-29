using System;
using System.Windows.Forms;

namespace Project3_EFStatistics
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.Run(new Form1());
        }
    }
}
