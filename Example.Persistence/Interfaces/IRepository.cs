using System.Collections.Generic;

namespace Example.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
    }
}
