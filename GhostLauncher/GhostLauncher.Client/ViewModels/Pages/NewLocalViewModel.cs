using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.Entities.Locations;
using GhostLauncher.Client.Events;
using GhostLauncher.Client.Views;
using GhostLauncher.Client.Views.Pages;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public class NewLocalViewModel : MainPageViewModel
    {
        #region Commands

        public RelayCommand CreateInstanceCommand => GetCommand(OnCreateInstance);

        public RelayCommand CloseCommand => GetCommand(OnClose);

        public RelayCommand SelectPathCommand => GetCommand(OnSelectPath);

        public RelayCommand SelectVersionCommand => GetCommand(OnSelectVersion);

        #endregion

        #region Properties

        public string Name
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public string InstancePath
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public ObservableCollection<InstanceFolder> InstanceFolders
        {
            get { return GetPropertyValue<ObservableCollection<InstanceFolder>>(); }
            set { SetPropertyValue(value); }
        }

        public InstanceFolder SelectedFolder
        {
            get { return GetPropertyValue<InstanceFolder>(); }
            set { SetPropertyValue(value); }
        }

        public MinecraftVersion SelectedVersion
        {
            get { return GetPropertyValue<MinecraftVersion>(); }
            set { SetPropertyValue(value); }
        }

        public bool IsFolderLocation
        {
            get { return GetPropertyValue<bool>(); }
            set { SetPropertyValue(value); }
        }

        public bool IsPathLocation
        {
            get { return GetPropertyValue<bool>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        public delegate void RaiseCreated(NewLocalViewModel m, CreateInstanceArgs e);
        public event RaiseCreated CreatedHandler;

        #region Constructors

        public NewLocalViewModel() : base(new NewLocalPage())
        {
            InstanceFolders = new ObservableCollection<InstanceFolder>();
            IsFolderLocation = true;

            Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            foreach (var instanceFolder in Manager.GetSingleton.GetConfig().InstanceLocations.Where(instanceFolder => instanceFolder.GetType() == typeof(InstanceFolder)))
            {
                InstanceFolders.Add((InstanceFolder)instanceFolder);
            }
        }

        #endregion

        #region Command Events

        private void OnCreateInstance()
        {
            if (CreatedHandler == null)
                return;

            InstanceLocation location;
            if (IsFolderLocation)
            {
                location = SelectedFolder;
            }
            else
            {
                location = new InstancePath { Path = InstancePath };
            }
                
            var instance = new LocalInstance() { Name = Name, Version = SelectedVersion, InstanceLocation = location };
            var args = new CreateInstanceArgs() { Instance = instance };
            CreatedHandler(this, args);
        }

        private void OnSelectPath()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InstancePath = dialog.SelectedPath;
            }
        }

        private void OnSelectVersion()
        {
            var versionSelector = new VersionSelectorWindow();
            versionSelector.ShowDialog();

            if (versionSelector.DialogResult.HasValue && versionSelector.DialogResult.Value)
            {
                var versionSelectorViewModel = (VersionSelectorViewModel)versionSelector.DataContext;
                SelectedVersion = versionSelectorViewModel.SelectedVersion;
            }
        }

        #endregion
    }
}