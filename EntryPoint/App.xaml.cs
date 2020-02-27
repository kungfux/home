using System;
using System.Threading;
using System.Windows;

namespace EntryPoint
{
    public partial class App : Application
    {
        private const string _mutexName = "{0070DB76-3228-42CA-A33A-70136487DF26}";
        private static Mutex _mutex;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetDefaultLanguageDictionary();

            if (IsAppAlreadyRunning() || !InitMutex())
            {
                MessageBox.Show(
                    GetTranslatedString("MessageAppAlreadyRunning"),
                    GetTranslatedString("MessageDefaultCaption"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Current.Shutdown();
            }
        }

        private static bool IsAppAlreadyRunning() => Mutex.TryOpenExisting(_mutexName, out _);

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

        public static void SetDefaultLanguageDictionary()
        {
            var dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "ru-RU":
                    dict.Source = new Uri("Properties\\StringResources.ru-RU.xaml", UriKind.Relative);
                    break;
                case "en-US":
                default:
                    dict.Source = new Uri("Properties\\StringResources.en-US.xaml", UriKind.Relative);
                    break;
            }
            Current.Resources.MergedDictionaries.Add(dict);
        }

        public static string GetTranslatedString(string key)
        {
            return Current.TryFindResource(key)?.ToString();
        }
    }
}
