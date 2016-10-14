using GhostLauncher.Entities.Configurations;

namespace GhostLauncher.Core.Features.Interfaces
{
    public interface IConfigurationService
    {
        AppConfig Configuration { get; set; }

        void Init();
    }
}
