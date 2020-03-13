using System.Windows;
using System.Windows.Input;
using TheGate.Model;

namespace TheGate.ViewModel
{
    public class MainWindowViewModel
    {
        public WebBrowser WebBrowser { get; }
        
        public ICommand ShowWindowCommand { get; }
        public ICommand ExitApplicationCommand { get; }

        public MainWindowViewModel()
        {
            WebBrowser = new WebBrowser();

            ShowWindowCommand = new RelayCommand<object>(OnShowWindow);
            ExitApplicationCommand = new RelayCommand(OnExitApplication);
        }

        public static void OnShowWindow(object parameter)
        {
            if (parameter is Window)
            {
                var window = parameter as Window;
                window.Show();
            }
        }

        public static void OnExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
