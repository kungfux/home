using CefSharp;
using CefSharp.Wpf;
using System.Windows.Input;

namespace TheGate.Model
{
    public class WebBrowser
    {
        public static ChromiumWebBrowser WebBrowserInstance { get; private set; }

        public WebBrowser()
        {
            WebBrowserInstance = new ChromiumWebBrowser()
            {
                Address = Properties.Settings.Default.URL
            };

            //WebBrowserInstance.BrowserSettings = new BrowserSettings()
            //{
            //    ImageLoading = CefState.Enabled,
            //    WindowlessFrameRate = 60,
            //    ApplicationCache = CefState.Enabled,
            //    RemoteFonts = CefState.Enabled,
            //    FileAccessFromFileUrls = CefState.Enabled,
            //    UniversalAccessFromFileUrls = CefState.Enabled
            //};

            WebBrowserInstance.KeyDown += WebBrowserInstance_KeyDown;
        }

        public static void LoadNewUrl()
        {
            if (WebBrowserInstance != null)
            {
                WebBrowserInstance.Address = Properties.Settings.Default.URL;
            }
        }

        public static void ForceReload()
        {
            if (WebBrowserInstance != null && WebBrowserInstance.IsLoaded)
            {
                WebBrowserInstance.Reload();
            }
        }

        private void WebBrowserInstance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift))
            {
                WebBrowserInstance.ShowDevTools();
                return;
            }

            if (e.Key == Key.F5)
            {
                WebBrowserInstance.Reload();
            }
        }
    }
}
