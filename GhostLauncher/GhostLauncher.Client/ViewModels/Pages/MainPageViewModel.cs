using System;
using System.Windows;
using GhostLauncher.Client.ViewModels.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public abstract class MainPageViewModel : BaseViewModel
    {
        public delegate void RaiseClose(object m, EventArgs e);
        public event RaiseClose CloseHandler;

        protected MainPageViewModel(FrameworkElement userControl) : base(userControl)
        {
        }

        protected void OnClose()
        {
            CloseHandler?.Invoke(this, new EventArgs());
        }
    }
}
