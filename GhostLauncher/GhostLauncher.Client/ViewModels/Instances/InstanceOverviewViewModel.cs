using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Common;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Instances;
using GhostLauncher.WPF.Core.BaseViewModels;
using Ninject;

namespace GhostLauncher.Client.ViewModels.Instances
{
    public class InstanceOverviewViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand DeleteInstanceCommand => GetCommand(OnDeleteInstance);

        #endregion

        #region Private Properties

        private IInstanceManager _instanceManager;

        #endregion

        #region Properties

        public ObservableCollection<Instance> InstanceCollection
        {
            get { return GetPropertyValue<ObservableCollection<Instance>>(); }
            set { SetPropertyValue(value); }
        }

        public Instance SelectedInstance
        {
            get { return GetPropertyValue<Instance>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public InstanceOverviewViewModel()
        {
            _instanceManager = Startup.Kernel.Get<IInstanceManager>();
            InstanceCollection = new ObservableCollection<Instance>();
            RefreshInstances();
        }

        #endregion

        #region Refresh

        private void RefreshInstances()
        {
            InstanceCollection.Clear();
            foreach (var instance in _instanceManager.Instances)
            {
                InstanceCollection.Add(instance);
            }
        }

        #endregion

        #region Command Events

        private void OnDeleteInstance()
        {
            var result = MessageBox.Show("Do you want to delete this instance?", "Delete instance", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;
            _instanceManager.DeleteInstance(SelectedInstance);
            InstanceCollection.Remove(SelectedInstance);
        }

        #endregion
    }
}
