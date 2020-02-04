using CefSharp;
using CefSharp.WinForms;

namespace SmartPoint.View.Control
{
    internal class BrowserControl
    {
        public ChromiumWebBrowser ChromeBrowser { internal get; set; }


        public BrowserControl()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);
            ChromeBrowser = new ChromiumWebBrowser("google.com");
        }

        public void Shutdown() => Cef.Shutdown();
    }
}
