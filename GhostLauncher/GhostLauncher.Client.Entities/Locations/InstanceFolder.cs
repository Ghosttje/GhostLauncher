namespace GhostLauncher.Client.Entities.Locations
{
    public class InstanceFolder : InstanceLocation
    {
        public string Name
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public bool IsDefault { get; set; }
    }
}
