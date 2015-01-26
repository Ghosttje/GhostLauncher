using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;

namespace GhostLauncher.MasterServer.Database
{
    public class MasterUnitOfWork : UnitOfWork
    {
        public MasterUnitOfWork(IDataContextAsync dataContext)
            : base(dataContext, new RepositoryProvider(new RepositoryFactories()))
        {
            
        }
    }
}
