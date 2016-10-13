using System;
using GhostLauncher.Client.ViewModels.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public abstract class MainPageWindowViewModel : BaseViewModel
    {
        public delegate void RaiseClose(object m, EventArgs e);
        public event RaiseClose CloseHandler;

        protected void OnClose()
        {
            CloseHandler?.Invoke(this, new EventArgs());
        }
    }
}
