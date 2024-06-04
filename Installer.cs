using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace directx_installer
{
    public static class Installer { 

        static string app_title = "\n     DirectX Runtime Installer for Windows\n     https://github.com/barankrky/directx_installer \n";

        static void CheckPackages()
        {
            Console.WriteLine("- Checking directx...");
            Thread.Sleep(250);
            if (Directory.Exists("directx"))
            {
                DirectoryInfo package_dir = new DirectoryInfo("directx");
                FileInfo[] setups = package_dir.GetFiles("*setup*.exe");
                FileInfo[] cab_files = package_dir.GetFiles("*.cab");
                FileInfo[] dll_files = package_dir.GetFiles("*.dll");

                List<FileInfo> directx_files = new List<FileInfo>();
                directx_files.AddRange(setups);
                directx_files.AddRange(cab_files);
                directx_files.AddRange(dll_files);

                foreach (FileInfo file in directx_files)
                {
                    Console.WriteLine("-- " + file.Name);
                }
            }
            else
            {
                Console.WriteLine("-- 'directx' not found. Please ensure that there is a 'directx' folder in the location where you run the application.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.Clear();
            Console.WriteLine(app_title);

        }

        static void Install()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory + "directx";
            Console.Write("--> Installing DirectX...");
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = @"/c .Setup.exe /silent";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = psi;
            proc.Start();
            proc.WaitForExit();

            Console.Clear();
            Console.WriteLine(app_title);
            Console.WriteLine(">>> DirectX Runtime installed successfully.");
            Console.WriteLine(">>> Closing in 3 seconds.");
            Thread.Sleep(2850);
            Environment.Exit(0);

        }

        public static void Start()
        {
            Console.Title = "DirectX Runtime Installer by barankrky";
            Console.WriteLine(app_title);
            CheckPackages();
            Install();
        }
    }
}
