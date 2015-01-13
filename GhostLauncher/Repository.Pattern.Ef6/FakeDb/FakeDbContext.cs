using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6.FakeDb
{
    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class, IObjectState;
    }

    public abstract class FakeDbContext : IFakeDbContext
    {
        #region Private Fields  
        private readonly Dictionary<Type, object> _fakeDbSets;
        #endregion Private Fields

        protected FakeDbContext()
        {
            _fakeDbSets = new Dictionary<Type, object>();
        }

        public int SaveChanges() { return default(int); }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            // no implentation needed, unit tests which uses FakeDbContext since there is no actual database for unit tests, 
            // there is no actual DbContext to sync with, please look at the Integration Tests for test that will run against an actual database.
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) { return new Task<int>(() => default(int)); }

        public Task<int> SaveChangesAsync() { return new Task<int>(() => default(int)); }

        public void Dispose() { }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class, IObjectState
        {
            var propertyInfos = GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (PropertyInfo property in propertyInfos)
            {
                if (property.PropertyType == typeof(FakeDbSet<TEntity>))
                    return property.GetValue(this, null) as FakeDbSet<TEntity>;
            }

            var baseType = typeof(TEntity).BaseType;

            while( typeof(object) != baseType )
            {
                foreach(var property in propertyInfos)
                {
                    if(property.PropertyType == typeof(FakeDbSet<>).MakeGenericType(baseType))
                    {
                        var baseTypeDbSet = property.GetValue(this, null);

                        // you will need to convert FakeDbSet<TBaseType> to FakeDbSet<TEntity>
                        var entityDbSet = Convert.ChangeType(baseTypeDbSet, typeof(FakeDbSet<>).MakeGenericType(baseType)) as FakeDbSet<TEntity>;
                        return entityDbSet;
                    }
                }
                baseType = baseType.BaseType;
            }

            throw new Exception("Type collection not found");
        }

        public void SyncObjectsStatePostCommit() { }
    }
}