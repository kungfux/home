﻿using EntryPoint.ViewModel;
using System.Windows;

namespace EntryPoint.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }
    }
}
