using System.Windows;
using GhostLauncher.Core;

namespace GhostLauncher.Client.Entities
{
    public class ClientInstance : NotifyPropertyChanged
    {
        private string _name;
        private Style _icon;
        private string _path;

        public ClientInstance(string name, Style icon, string path)
        {
            Name = name;
            Icon = icon;
            Path = path;
        }

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

        public Style Icon
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

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
