using Example.Persistence.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Example.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
    }
}
