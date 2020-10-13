using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDemo.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(object keys);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        int SaveChanges();
        T Query<T>(string query);
        IEnumerable<T> QueryList<T>(string query);
    }
}
