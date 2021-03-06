﻿using System.Windows;
using GhostLauncher.Client.ViewModels;
using GhostLauncher.Client.ViewModels.Windows;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            DataContext = new AboutViewModel(this);
        }
    }
}
