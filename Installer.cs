using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace directx_installer
{
    public static class Installer {

        static NotifyIcon notifyIcon = new NotifyIcon();

        static void NotifyIconStarted()
        {
            notifyIcon.Icon = IconExtractor.Extract("imageres.dll", 152, true);
            notifyIcon.Text = "Installation started.";
            notifyIcon.BalloonTipTitle = Properties.Resources.console_title;
            notifyIcon.BalloonTipText = "Installation started. Please wait until it is completed.";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000);

        }

        static void NotifyIconFinished()
        {
            notifyIcon.Icon = IconExtractor.Extract("imageres.dll", 232, true);
            notifyIcon.Text = "Installation finished.";
            notifyIcon.BalloonTipTitle = Properties.Resources.console_title;
            notifyIcon.BalloonTipText = "Installation completed successfully.";
            notifyIcon.ShowBalloonTip(3000);

        }

        static void Install()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory + "directx";
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

        }

        public static void Start()
        {
            NotifyIconStarted();
            Install();
            NotifyIconFinished();
        }
    }
}
