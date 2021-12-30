using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using Home.Model;

namespace Home.ViewModel
{
    public class SettingsDialogViewModel
    {
        public SettingsDialogViewModel()
        {
            CloseDialogCommand = new RelayCommand<object>(OnCloseDialog);
        }

        public ICommand CloseDialogCommand { get; }

        public bool HideOnStart
        {
            get { return Properties.Settings.Default.HideOnStart; }
            set { Properties.Settings.Default.HideOnStart = value; }
        }

        public bool Reload
        {
            get { return Properties.Settings.Default.ReloadOnOpen; }
            set { Properties.Settings.Default.ReloadOnOpen = value; }
        }

        public bool ShowHeader
        {
            get { return Properties.Settings.Default.ShowHeader; }
            set { Properties.Settings.Default.ShowHeader = value; }
        }

        public string URL
        {
            get { return Properties.Settings.Default.URL; }
            set { Properties.Settings.Default.URL = value; }
        }

        public static void OnCloseDialog(object parameter)
        {
            DialogHost.CloseDialogCommand.Execute(parameter, null);
            WebBrowser.LoadNewUrl();
        }
    }
}
