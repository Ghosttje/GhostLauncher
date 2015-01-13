using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6
{
    [DataContract]
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}