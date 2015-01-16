using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Repository.Pattern.Infrastructure;

namespace GhostLauncher.Core
{
    public abstract class GhostLauncherEntity : NotifyPropertyChanged, IObjectState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [IgnoreDataMember]
        public ObjectState ObjectState { get; set; }
    }
}
