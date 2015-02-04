﻿using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.MinecraftInstances;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views.Windows;
using GhostLauncher.Client.Wizards;

namespace GhostLauncher.Client.ViewModels
{
    public class MainViewModel
    {
        private RelayCommand _command;
        private readonly Window _window;
        private readonly ObservableCollection<Instance> _instanceCollection;
        
        public MainViewModel(Window window)
        {
            _window = window;
            _instanceCollection = new ObservableCollection<Instance>();

            MasterManager.GetSingleton.StartApp();
            RefreshInstances();
        }

        private void RefreshInstances()
        {
            InstanceCollection.Clear();
            foreach (var instance in MasterManager.GetSingleton.InstanceManager.Instances)
            {
                InstanceCollection.Add(instance);
            } 
        }

        #region Setters / Getters

        public ObservableCollection<Instance> InstanceCollection
        {
            get
            {
                return _instanceCollection;
            }
        }

        #endregion

        #region Commands

        public RelayCommand AddInstanceCommand
        {
            get
            {
                _command = new RelayCommand(NewInstance);
                return _command;
            }
        }

        public RelayCommand SettingsCommand
        {
            get
            {
                _command = new RelayCommand(Settings);
                return _command;
            }
        }

        public RelayCommand AboutCommand
        {
            get
            {
                _command = new RelayCommand(About);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void NewInstance()
        {
            var wizard = new NewInstanceWizard();
            if (wizard.Start(_window))
            {
                RefreshInstances();
            }
        }

        private void Settings()
        {
            var settingsWindow = new SettingsWindow() { Owner = _window };
            settingsWindow.Show();
        }

        private void About()
        {
            var aboutWindow = new AboutWindow() { Owner = _window };
            aboutWindow.Show();
        }

        #endregion
    }
}