using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Windows.Input;

namespace Home.Model
{
    public class WebBrowser
    {
        public WebBrowser()
        {
            if (WebBrowserInstance == null)
            {
                var settings = new CefSettings();
                settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Home\Cache");
                Cef.Initialize(settings);
            }

            WebBrowserInstance = new ChromiumWebBrowser()
            {
                Address = Properties.Settings.Default.URL,
            };

            WebBrowserInstance.BrowserSettings = new BrowserSettings()
            {
            };

            WebBrowserInstance.KeyDown += WebBrowserInstance_KeyDown;
        }

        public static ChromiumWebBrowser WebBrowserInstance { get; private set; }

        public static void ForceReload()
        {
            if (WebBrowserInstance != null && WebBrowserInstance.IsLoaded)
            {
                WebBrowserInstance.Reload();
            }
        }

        public static void LoadNewUrl()
        {
            if (WebBrowserInstance != null)
            {
                WebBrowserInstance.Address = Properties.Settings.Default.URL;
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
