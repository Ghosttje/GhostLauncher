using GhostLauncher.Core;

namespace GhostLauncher.Client.Entities
{
    public class Instance : NotifyPropertyChanged
    {
        private string _name;
        private string _icon;

        #region Setters/Getters

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
