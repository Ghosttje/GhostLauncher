using System;
using System.Collections.Generic;
using GhostLauncher.Client.Entities.Exceptions;
using GhostLauncher.Client.ViewModels.Settings;
using GhostLauncher.Client.ViewModels.Settings.Interfaces;

namespace GhostLauncher.Client.Factories
{
    public class SettingsFactory
    {
        public static ISettingsViewModel Create(string settingsType)
        {
            if (settingsType == Properties.Resources.Settings_Menu_Main)
            {
                return new MainSettingsViewModel();
            }
            throw new SettingsTypeUnkownException();
        }

        public static Type GetType(string settingsType)
        {
            if (settingsType == Properties.Resources.Settings_Menu_Main)
            {
                return typeof(MainSettingsViewModel);
            }
            throw new SettingsTypeUnkownException();
        }

        public static List<string> GetSettings()
        {
            return new List<string>
            {
                Properties.Resources.Settings_Menu_Main
            };
        }
    }
}
