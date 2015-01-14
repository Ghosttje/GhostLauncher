using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using GhostLauncher.Entities;
using Repository.Pattern.Infrastructure;

namespace GhostLauncher.Core
{
    [DataContract(Namespace = "", IsReference = true)]
    [KnownType(typeof(MinecraftVersion))]
    public abstract class GhostLauncherEntity : NotifyPropertyChanged, IObjectState
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public ObjectState ObjectState { get; set; }
    }
}
