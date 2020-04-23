using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using Home.Model;

namespace Home.ViewModel
{
    public class SettingsDialogViewModel
    {
        public string URL
        {
            get { return Properties.Settings.Default.URL; }
            set { Properties.Settings.Default.URL = value; }
        }

        public bool Reload
        {
            get { return Properties.Settings.Default.ReloadOnOpen; }
            set { Properties.Settings.Default.ReloadOnOpen = value; }
        }

        public ICommand CloseDialogCommand { get; }

        public SettingsDialogViewModel()
        {
            CloseDialogCommand = new RelayCommand<object>(OnCloseDialog);
        }

        public static void OnCloseDialog(object parameter)
        {
            DialogHost.CloseDialogCommand.Execute(parameter, null);
            WebBrowser.LoadNewUrl();
        }
    }
}
