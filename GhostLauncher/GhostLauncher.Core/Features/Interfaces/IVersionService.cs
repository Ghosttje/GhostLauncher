using System.Collections.Generic;
using GhostLauncher.Entities;

namespace GhostLauncher.Core.Features.Interfaces
{
    public interface IVersionService
    {
        List<MinecraftVersion> MinecraftVersions { get; set; }

        void Init();
        void LoadVersions();
    }
}
