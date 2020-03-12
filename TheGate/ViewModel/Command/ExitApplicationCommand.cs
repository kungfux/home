using System;
using System.Windows;
using System.Windows.Input;

namespace TheGate.ViewModel.Command
{
    public class ExitApplicationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
