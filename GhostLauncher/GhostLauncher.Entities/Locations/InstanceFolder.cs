namespace GhostLauncher.Entities.Locations
{
    public class InstancesFolder : InstanceLocation
    {
        public string Name
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public bool IsDefault { get; set; }
    }
}
