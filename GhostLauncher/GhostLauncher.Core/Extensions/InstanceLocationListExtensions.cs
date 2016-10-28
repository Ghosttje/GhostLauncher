using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Core.Extensions
{
    public static class InstanceLocationListExtensions
    {
        public static void SetDefaultFolder(this List<InstanceLocation> instanceLocations, InstancesFolder newDefaultFolder)
        {
            var currentDefault = instanceLocations.OfType<InstancesFolder>().Single(x => x.IsDefault);
            currentDefault.IsDefault = false;
            var newDefault = (InstancesFolder)instanceLocations.Find(x => x == newDefaultFolder);
            newDefault.IsDefault = true;
        }

        public static void SetDefaultFolder(this ObservableCollection<InstanceLocation> instanceLocations, InstancesFolder newDefaultFolder)
        {
            instanceLocations.ToList().SetDefaultFolder(newDefaultFolder);
        }
    }
}
