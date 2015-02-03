namespace GhostLauncher.Client.Entities
{
    public class ClientInstance : Instance
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
