using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class VersionSelectorViewModel : BaseViewModel
    {
        private RelayCommand _command;

        #region Properties

        public ObservableCollection<MinecraftVersion> VersionCollection { get; private set; }

        public MinecraftVersion SelectedVersion
        {
            get { return GetPropertyValue<MinecraftVersion>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public VersionSelectorViewModel() : base(new VersionSelectorWindow())
        {
            VersionCollection = new ObservableCollection<MinecraftVersion>();
            ParseVersions();
        }

        #endregion

        private void ParseVersions()
        {
            VersionCollection.Clear();
            SelectedVersion = null;

            Manager.GetSingleton.VersionManager.Init();

            foreach (var result in Manager.GetSingleton.VersionManager.MinecraftVersions)
            {
                VersionCollection.Add(result);
            }
        }

        #region Commands

        public RelayCommand SelectCommand => GetCommand(Select);

        public RelayCommand CloseCommand
        {
            get
            {
                _command = new RelayCommand(Close);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void Select()
        {
            GetWindow().DialogResult = true;
            GetWindow().Close();
        }

        private void Close()
        {
            GetWindow().DialogResult = false;
            GetWindow().Close();
        }

        #endregion
    }
}
