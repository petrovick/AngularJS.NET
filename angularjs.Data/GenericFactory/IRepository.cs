using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace angularjs.Data.GenericFactory
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsQueryAble(params string[] includes);
        IEnumerable<TEntity> GetAll(params string[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params string[] includes);
        TEntity Single(params object[] key);
        void Update(TEntity entity);
        void Save(TEntity entity);
        void Delete(Func<TEntity, bool> predicate);
        void Delete(TEntity entity);
        void DeleteAll(IEnumerable<TEntity> entity);
        void Dispose();
        DbContext GetContext();
        void SetContext(DbContext context);
        void SaveChanges();
        void Attach(TEntity entity);
    }
}
