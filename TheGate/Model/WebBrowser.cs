using CefSharp;
using CefSharp.Wpf;
using System.Windows.Input;

namespace TheGate.Model
{
    public class WebBrowser
    {
        public ChromiumWebBrowser WebBrowserInstance { get; }

        public WebBrowser()
        {
            WebBrowserInstance = new ChromiumWebBrowser()
            {
                Address = "http://google.com"
            };

            WebBrowserInstance.BrowserSettings = new BrowserSettings()
            {
                ImageLoading = CefState.Enabled,
                WindowlessFrameRate = 60,
                ApplicationCache = CefState.Enabled,
                RemoteFonts = CefState.Enabled
            };

            WebBrowserInstance.KeyDown += WebBrowserInstance_KeyDown;
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
