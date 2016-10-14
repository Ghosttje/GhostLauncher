using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Common;
using GhostLauncher.Client.Views;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities;
using GhostLauncher.WPF.Core.BaseViewModels;
using Ninject;
using VersionSelectorWindow = GhostLauncher.Client.Views.Instances.VersionSelectorWindow;

namespace GhostLauncher.Client.ViewModels.Instances
{
    public class VersionSelectorWindowViewModel : BaseWindowViewModel
    {
        #region Commands

        public RelayCommand SelectCommand => GetCommand(OnSelect);

        public RelayCommand CloseCommand => GetCommand(OnClose);

        #endregion

        #region Private Properties

        private readonly IVersionService _versionService;

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

        public VersionSelectorWindowViewModel() : base(new VersionSelectorWindow())
        {
            _versionService = Startup.Kernel.Get<IVersionService>();
            VersionCollection = new ObservableCollection<MinecraftVersion>();
            ParseVersions();
        }

        #endregion

        private void ParseVersions()
        {
            VersionCollection.Clear();
            SelectedVersion = null;

            _versionService.Init();

            foreach (var result in _versionService.MinecraftVersions)
            {
                VersionCollection.Add(result);
            }
        }

        #region Command Events

        private void OnSelect()
        {
            //GetWindow().DialogResult = true;
            //GetWindow().Close();
        }

        private void OnClose()
        {
            //GetWindow().DialogResult = false;
            //GetWindow().Close();
        }

        #endregion
    }
}
