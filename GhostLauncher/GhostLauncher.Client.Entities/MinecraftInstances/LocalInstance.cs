namespace GhostLauncher.Client.Entities.MinecraftInstances
{
    public class LocalInstance : Instance
    {
        private string _path;

        #region Setters/Getters

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
