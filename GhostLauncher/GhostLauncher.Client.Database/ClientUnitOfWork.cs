using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;

namespace GhostLauncher.Client.Database
{
    public class ClientUnitOfWork : UnitOfWork
    {
        public ClientUnitOfWork(IDataContextAsync dataContext)
            : base(dataContext, new RepositoryProvider(new RepositoryFactories()))
        {
            
        }
    }
}
