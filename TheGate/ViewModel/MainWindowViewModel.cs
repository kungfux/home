using TheGate.Model;

namespace TheGate.ViewModel
{
    public class MainWindowViewModel
    {
        public WebBrowser WebBrowser { get; }

        public MainWindowViewModel()
        {
            WebBrowser = new WebBrowser();
        }
    }
}
