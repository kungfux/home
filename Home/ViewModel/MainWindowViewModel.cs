using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;
using Home.Model;
using Home.View.Dialog;

namespace Home.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            SetDefaultLocationProps();

            WebBrowser = new WebBrowser();

            ShowWindowCommand = new RelayCommand<object>(OnShowWindow);
            ShowSettingsCommand = new RelayCommand(OnShowSettingsCommand);
            ExitApplicationCommand = new RelayCommand(OnExitApplication);
        }

        public ICommand ExitApplicationCommand { get; }

        public bool ShowHeader
        {
            get { return Properties.Settings.Default.ShowHeader; }
        }

        public ICommand ShowSettingsCommand { get; }

        public ICommand ShowWindowCommand { get; }
        public WebBrowser WebBrowser { get; }

        public static void OnExitApplication()
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        public static async void OnShowSettingsCommand()
        {
            var view = new SettingsViewDialog
            {
                DataContext = new SettingsDialogViewModel()
            };

            await DialogHost.Show(view);
        }

        public static void OnShowWindow(object parameter)
        {
            if (parameter is Window)
            {
                var window = parameter as Window;
                window.Show();
            }
        }

        private void SetDefaultLocationProps()
        {
            if (Properties.Settings.Default.Left == 0 || Properties.Settings.Default.Top == 0)
            {
                Properties.Settings.Default.Left = (int)SystemParameters.WorkArea.Width / 2 - Properties.Settings.Default.Width / 2;
                Properties.Settings.Default.Top = (int)SystemParameters.WorkArea.Height / 2 - Properties.Settings.Default.Height / 2;
            }
        }
    }
}
