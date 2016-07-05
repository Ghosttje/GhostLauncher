using System;
using GhostLauncher.Core;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public abstract class MainPageViewModel : NotifyPropertyChanged
    {
        public delegate void RaiseClose(object m, EventArgs e);
        public event RaiseClose CloseHandler;

        protected void Close()
        {
            CloseHandler?.Invoke(this, new EventArgs());
        }
    }
}
