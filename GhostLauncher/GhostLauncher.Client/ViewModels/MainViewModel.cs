using System;
using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities;
using GhostLauncher.Client.Entities.Configurations;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.ViewModels
{
    public class MainViewModel
    {
        private ObservableCollection<ClientInstance> _instanceCollection = new ObservableCollection<ClientInstance>();
        private RelayCommand _command;
        private readonly Window _window;
        
        public MainViewModel(Window window)
        {
            _window = window;


            //var temp = new InstanceConfiguration {Name = "Instance 1", Icon = "InstanceLogo"};

            MasterManager.GetSingleton.StartApp();
            //MasterManager.GetSingleton.InstanceManager.CreateInstance(temp);
            
            //MasterManager.GetSingleton.InstanceManager.

            //var resourceDictionary = new ResourceDictionary
            //{
            //    Source = new Uri("pack://application:,,,/ResourceDictionaries/ResourceDictionary.xaml")
            //};

            //_instanceCollection.Add(new ClientInstance("Instance 1", (Style)resourceDictionary["InstanceLogo"], ""));
            //_instanceCollection.Add(new ClientInstance("Instance 2", (Style)resourceDictionary["InstanceLogo"], ""));
            //_instanceCollection.Add(new ClientInstance("Instance 3", (Style)resourceDictionary["InstanceLogo"], "qsdf"));
            //_instanceCollection.Add(new ClientInstance("Instance 4", (Style)resourceDictionary["InstanceLogo"], "qsdfqsdf"));
            //_instanceCollection.Add(new ClientInstance("Instance 5", (Style)resourceDictionary["InstanceLogo"], "qsdf"));
        }

        #region Setters / Getters

        public ObservableCollection<ClientInstance> InstanceCollection
        {
            get
            {
                return _instanceCollection;
            }
            set
            {
                _instanceCollection = value;
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
            var addInstanceWindow = new AddInstanceWindow { Owner = _window };
            addInstanceWindow.Show();
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