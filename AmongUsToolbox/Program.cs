using System;
using System.IO;
using System.Windows.Forms;
using AmongUsToolbox.Windows;

namespace AmongUsToolbox
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            _createDirectories();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void _createDirectories()
        {
            Directory.CreateDirectory("mods");
            Directory.CreateDirectory("downloads");
            Directory.CreateDirectory("configs");
        }
    }
}