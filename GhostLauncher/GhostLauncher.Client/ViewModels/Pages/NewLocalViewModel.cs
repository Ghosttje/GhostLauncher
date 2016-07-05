using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.Entities.Locations;
using GhostLauncher.Client.Events;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public class NewLocalViewModel : MainPageViewModel
    {
        private RelayCommand _command;

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

        public NewLocalViewModel()
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

        #region Commands

        public RelayCommand CreateInstanceCommand
        {
            get
            {
                _command = new RelayCommand(CreateInstance);
                return _command;
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                _command = new RelayCommand(Close);
                return _command;
            }
        }

        public RelayCommand SelectPathCommand
        {
            get
            {
                _command = new RelayCommand(SelectPath);
                return _command;
            }
        }

        public RelayCommand SelectVersionCommand
        {
            get
            {
                _command = new RelayCommand(SelectVersion);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void CreateInstance()
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

        private void SelectPath()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InstancePath = dialog.SelectedPath;
            }
        }

        private void SelectVersion()
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