using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Repository.Pattern.Annotations;

namespace GhostLauncher.Core
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(GhostLauncherEntity))]
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
