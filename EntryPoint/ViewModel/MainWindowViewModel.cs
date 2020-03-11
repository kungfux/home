using EntryPoint.Model;

namespace EntryPoint.ViewModel
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
