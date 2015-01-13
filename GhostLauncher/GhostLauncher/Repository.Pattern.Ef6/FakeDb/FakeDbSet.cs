using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Ef6.FakeDb.DbAsync;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6.FakeDb
{
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IEnumerable<TEntity>, IQueryable, IDbAsyncEnumerable<TEntity>
        where TEntity : class, IObjectState
    {
        #region Private Fields
        private readonly ObservableCollection<TEntity> _items;
        private readonly IQueryable _query;
        #endregion Private Fields

        public FakeDbSet()
        {
            _items = new ObservableCollection<TEntity>();
            _query = _items.AsQueryable();
        }

        public override TEntity Add(TEntity entity)
        {
            _items.Add(entity);
            return entity;
        }

        public override TEntity Remove(TEntity entity)
        {
            _items.Remove(entity);
            return entity;
        }

        public override TEntity Attach(TEntity entity)
        {
            switch (entity.ObjectState)
            {
                case ObjectState.Modified:
                    _items.Remove(entity);
                    _items.Add(entity);
                    break;
                
                case ObjectState.Deleted:
                    _items.Remove(entity);
                    break;
                
                case ObjectState.Unchanged:
                case ObjectState.Added:
                    _items.Add(entity);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return entity;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return _items; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_items.GetEnumerator());
        }
    }
}