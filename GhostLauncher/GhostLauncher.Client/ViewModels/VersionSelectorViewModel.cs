using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class VersionSelectorViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand SelectCommand => GetCommand(OnSelect);

        public RelayCommand CloseCommand => GetCommand(OnClose);

        #endregion

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

        #region Command Events

        private void OnSelect()
        {
            GetWindow().DialogResult = true;
            GetWindow().Close();
        }

        private void OnClose()
        {
            GetWindow().DialogResult = false;
            GetWindow().Close();
        }

        #endregion
    }
}
