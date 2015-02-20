namespace GhostLauncher.Client.Entities.Locations
{
    public class InstanceFolder : InstanceLocation
    {
        private string _name;
        public bool IsDefault { get; set; }
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
