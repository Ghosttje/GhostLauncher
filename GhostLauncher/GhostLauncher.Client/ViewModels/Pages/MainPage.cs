using System;
using GhostLauncher.Core;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public abstract class MainPage : NotifyPropertyChanged
    {
        public delegate void RaiseClose(Object m, EventArgs e);
        public event RaiseClose CloseHandler;

        protected void Close()
        {
            if (CloseHandler != null)
                CloseHandler(this, new EventArgs());
        }
    }
}
