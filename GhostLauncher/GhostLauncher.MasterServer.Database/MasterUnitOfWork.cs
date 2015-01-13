using GhostLauncher.Entities;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;

namespace GhostLauncher.MasterServer.Database
{
    public class MasterUnitOfWork : UnitOfWork
    {
        public MasterUnitOfWork(IDataContextAsync dataContext)
            : base(dataContext, new RepositoryProvider(new RepositoryFactories()))
        {
            
        }

        public IRepositoryAsync<MinecraftVersion> MinecraftRepository
        {
            get { return RepositoryAsync<MinecraftVersion>(); }
        }
    }
}
