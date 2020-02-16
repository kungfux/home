using CefSharp;
using CefSharp.WinForms;
using SmartPoint.Properties;

namespace SmartPoint.View.Control
{
    internal class BrowserControl
    {
        public ChromiumWebBrowser ChromeBrowser { internal get; set; }


        public BrowserControl()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);
            ChromeBrowser = new ChromiumWebBrowser(Settings.Default.Url);
        }

        public void Shutdown() => Cef.Shutdown();
    }
}
