using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GhostLauncher.Client.Annotations;

namespace GhostLauncher.Client.Models
{
    public class MinecraftInstance : INotifyPropertyChanged
    {
        private string _name;
        private Style _icon;
        private string _path;

        public MinecraftInstance(string name, Style icon, string path)
        {
            Name = name;
            Icon = icon;
            Path = path;
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
