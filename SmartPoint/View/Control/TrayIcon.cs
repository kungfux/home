using SmartPoint.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartPoint.View.Control
{
    internal class TrayIcon
    {
        public EventHandler ShowClicked;
        public EventHandler ExitClicked;

        private readonly NotifyIcon _notifyIcon;
        private readonly string _exitDisplayName = Resources.Exit;

        public TrayIcon(Icon icon, string hint)
        {
            var contextMenu = GetContextMenu();

            _notifyIcon = new NotifyIcon
            {
                Visible = true,
                Icon = icon,
                Text = hint,
                ContextMenuStrip = contextMenu
            };

            _notifyIcon.MouseClick += NotifyIconObject_MouseClick;
        }

        public void Hide() => _notifyIcon.Visible = false;

        private void NotifyIconObject_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ShowClicked?.Invoke(this, null);
        }

        private ContextMenuStrip GetContextMenu()
        {
            var contextMenu = new ContextMenuStrip();

            contextMenu.Items.AddRange(
                new ToolStripItem[] {
                    new ToolStripMenuItem(_exitDisplayName, null, (sender, e) => ExitClicked?.Invoke(this, null))
                });

            return contextMenu;
        }
    }
}
