using System.Collections.Generic;
using GhostLauncher.Entities.Instances;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Core.Features.Interfaces
{
    public interface IInstanceManager
    {
        List<Instance> Instances { get; set; }

        void AddInstance(Instance instance);
        void DeleteInstance(Instance instance);
        void SetupStructure(Instance instance);
        void FindInstances(InstanceLocation folder);
    }
}
