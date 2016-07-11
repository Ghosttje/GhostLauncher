using System;
using System.Windows.Controls;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Managers;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.Events;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.ViewModels.Pages;
using GhostLauncher.Client.Views;
using GhostLauncher.Client.Views.Pages;

namespace GhostLauncher.Client.ViewModels
{
    public class NewInstanceViewModel : BaseViewModel
    {
        public Page CurrentPage
        {
            get { return GetPropertyValue<Page>(); }
            set { SetPropertyValue(value); }
        }

        public NewInstanceViewModel() : base(new NewInstanceWindow())
        {
            SetSelectTypePage();
        }

        private void SetSelectTypePage()
        {
            CurrentPage = new SelectTypePage();
            var viewmodel = (SelectTypeViewModel)CurrentPage.DataContext;
            viewmodel.SelectedTypeHandler += SelectType;
        }

        #region Events

        private void SelectType(SelectTypeViewModel m, SelectedTypeArgs e)
        {
            if (e.InstanceType == InstanceType.Remote)
            {

            }
            else
            {
                CurrentPage = new NewLocalPage();
                var viewmodel = (NewLocalViewModel)CurrentPage.DataContext;
                viewmodel.CloseHandler += Close;
                viewmodel.CreatedHandler += CreateNewInstance;
            }
        }

        private void CreateNewInstance(object m, CreateInstanceArgs e)
        {
            Manager.GetSingleton.InstanceManager.AddInstance(e.Instance);
            InstanceManager.SetupStructure(e.Instance);
            JarHelper.GetFile(e.Instance);

            GetWindow().DialogResult = true;
            GetWindow().Close();
        }

        private void Close(object m, EventArgs e)
        {
            GetWindow().DialogResult = false;
            GetWindow().Close();
        }

        #endregion
    }
}
