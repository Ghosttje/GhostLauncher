using System.Windows;

namespace GhostLauncher.WPF.Core.BaseViewModels
{
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        #region Properties

        public Window View { get; set; }

        #endregion

        #region Constructors

        protected BaseWindowViewModel(Window userControl)
        {
            View = userControl;
            View.DataContext = this;
        }

        #endregion

        #region Getters / Setters

        public Window GetWindow()
        {
            return View;
        }

        #endregion
    }
}