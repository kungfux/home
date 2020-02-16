using SmartPoint.Properties;
using SmartPoint.View.Control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartPoint.View
{
    internal class MainView : Form
    {
        private readonly BrowserControl _browserControl;
        private readonly TrayIcon _trayIcon;

        public MainView(Icon icon, BrowserControl browserControl, TrayIcon trayIcon)
        {
            _trayIcon = trayIcon;
            _browserControl = browserControl;

            Text = Settings.Default.Title;
            Icon = icon;

            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Width = Screen.PrimaryScreen.Bounds.Width / 4;
            Height = Screen.PrimaryScreen.Bounds.Height / 4;
            ShowInTaskbar = false;
            TopMost = true;

            Controls.Add(_browserControl.ChromeBrowser);
            _browserControl.ChromeBrowser.Dock = DockStyle.Fill;

            Shown += MainView_Shown;
            FormClosing += MainForm_FormClosing;
            Deactivate += MainForm_Deactivate;

            _trayIcon.ShowClicked += NotifyIcon_ShowClicked;
            _trayIcon.ExitClicked += NotifyIcon_ExitClicked;
        }

        private void MainView_Shown(object sender, EventArgs e) => Hide();

        private void MainForm_Deactivate(object sender, EventArgs e) => Hide();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            e.Cancel = true;
            Hide();
        }

        private void NotifyIcon_ShowClicked(object sender, EventArgs e)
        {
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height;

            if (Visible)
            {
                Hide();
            }
            else
            {
                Deactivate -= MainForm_Deactivate;
                Show();
                Visible = true;
                Deactivate += MainForm_Deactivate;
            }
        }

        private void NotifyIcon_ExitClicked(object sender, EventArgs e)
        {
            _trayIcon.Hide();
            _browserControl.Shutdown();
            Application.Exit();
        }
    }
}
