using System;

namespace GhostLauncher.Client.Entities.Exceptions
{
    public class SettingsTypeUnkownException : Exception
    {
        public SettingsTypeUnkownException() : base("This setting type is unknown!")
        {
        }
    }
}
