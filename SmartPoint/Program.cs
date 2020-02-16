using SmartPoint.Properties;
using SmartPoint.View;
using SmartPoint.View.Control;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SmartPoint
{
    internal static class Program
    {
        private static readonly string _title = Settings.Default.Title;
        private const string _mutexName = "SmartPoint2020";
        private static Mutex _mutex = null;

        [STAThread]
        private static void Main()
        {
            if (IsAppAlreadyRunning() || !InitMutex())
            {
                MessageBox.Show(Resources.AppAlreadyRunning, _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var icon = Resources.point;
            var browserControl = new BrowserControl();
            var trayIcon = new TrayIcon(icon, _title);

            Application.Run(new MainView(icon, browserControl, trayIcon));
        }

        private static bool IsAppAlreadyRunning() => Mutex.TryOpenExisting(_mutexName, out _);

        private static bool InitMutex()
        {
            try
            {
                _mutex = new Mutex(true, _mutexName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
