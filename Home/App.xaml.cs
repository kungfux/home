using System;
using System.Threading;
using System.Windows;

namespace Home
{
    public partial class App : Application
    {
        private const string _mutexName = "{0070DB76-3228-42CA-A33A-70136487DF26}";
        private static Mutex _mutex;

        public static string GetTranslatedText(string key)
        {
            return Current.TryFindResource(key)?.ToString();
        }

        public static void SetDefaultLanguageDictionary()
        {
            var dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                default:
                case "en-US":
                    dict.Source = new Uri("Properties\\StringResources.en-US.xaml", UriKind.Relative);
                    break;

                case "ru-RU":
                    dict.Source = new Uri("Properties\\StringResources.ru-RU.xaml", UriKind.Relative);
                    break;
            }
            Current.Resources.MergedDictionaries.Add(dict);
        }

        private static bool InitMutex()
        {
            try
            {
                _mutex = new Mutex(true, _mutexName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsAppAlreadyRunning() => Mutex.TryOpenExisting(_mutexName, out _);

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetDefaultLanguageDictionary();

            if (IsAppAlreadyRunning() || !InitMutex())
            {
                MessageBox.Show(
                    GetTranslatedText("MessageAppAlreadyRunning"),
                    GetTranslatedText("MessageDefaultCaption"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Current.Shutdown();
            }

            var mainWindow = new View.MainWindow();
            if (!Home.Properties.Settings.Default.HideOnStart)
            {
                mainWindow.Show();
            }
        }
    }
}
