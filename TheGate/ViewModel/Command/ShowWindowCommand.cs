using System;
using System.Windows;
using System.Windows.Input;

namespace TheGate.ViewModel.Command
{
    public class ShowWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            if (parameter is Window)
            {
                var window = parameter as Window;
                window.Show();
            }
        }
    }
}
