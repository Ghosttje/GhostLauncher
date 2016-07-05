using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private readonly DispatcherTimer _timer;

        private bool _intervalReady;

        public SplashViewModel(FrameworkElement window) : base(window)
        {
            var initThread = new Thread(InitApp);
            _timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 2)};
            _timer.Tick += Timer_Tick;
            
            _timer.Start();
            initThread.Start();
        }

        private void InitApp()
        {
            Manager.GetSingleton.StartApp();
            Application.Current.Dispatcher.Invoke(Done);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            Application.Current.Dispatcher.Invoke(Done);
        }

        private void Done()
        {
            if (_intervalReady)
            {
                ((Window)new MainViewModel().View).Show();
                ((Window)View).Close();
            }
            else
            {
                _intervalReady = true;
            }
            
        }
    }
}
