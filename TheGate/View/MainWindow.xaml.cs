using System.Windows;
using System.ComponentModel;
using TheGate.Model;

namespace TheGate.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is bool)
            {
                if ((bool)e.NewValue && Properties.Settings.Default.ReloadOnOpen)
                {
                    WebBrowser.ForceReload();
                }
            }
        }
    }
}
