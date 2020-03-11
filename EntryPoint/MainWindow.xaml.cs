using CefSharp;
using CefSharp.Wpf;
using System.Windows;
using System.Windows.Input;

namespace EntryPoint
{
    public partial class MainWindow : Window
    {
        private ChromiumWebBrowser _browser;

        public MainWindow()
        {
            InitializeComponent();

            InitBrowser();
        }

        public void InitBrowser()
        {
            _browser = new ChromiumWebBrowser()
            {
                Address = "http://google.com"
            };
            _browser.BrowserSettings = new BrowserSettings()
            {
                ImageLoading = CefState.Enabled,
                WindowlessFrameRate = 60,
                ApplicationCache = CefState.Enabled,
                RemoteFonts = CefState.Enabled
            };
            browserContainer.Content = _browser;
            DataContext = _browser;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift))
            {
                _browser.ShowDevTools();
                return;
            }

            if (e.Key == Key.F5)
            {
                _browser.Reload();
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            _browser.Back(); // Use command instead
        }
    }
}
