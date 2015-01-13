using GhostLauncher.Entities;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;

namespace GhostLauncher.Client.Database
{
    public class ClientUnitOfWork : UnitOfWork
    {
        public ClientUnitOfWork(IDataContextAsync dataContext)
            : base(dataContext, new RepositoryProvider(new RepositoryFactories()))
        {
            
        }

        public IRepositoryAsync<MinecraftVersion> MinecraftRepository
        {
            get { return RepositoryAsync<MinecraftVersion>(); }
        }
    }
}
