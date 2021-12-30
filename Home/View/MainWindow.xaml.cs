using System.Windows;
using System.ComponentModel;
using Home.Model;

namespace Home.View
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

        private void Window_Deactivated(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var newValue = (bool)e.NewValue;

                if (newValue && Properties.Settings.Default.ReloadOnOpen)
                {
                    WebBrowser.ForceReload();
                }
            }
        }
    }
}
