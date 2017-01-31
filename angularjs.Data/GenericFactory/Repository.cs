using angularjs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace angularjs.Data.GenericFactory
{
    public class Repository<TEntity> : IDisposable,
           IRepository<TEntity> where TEntity : class
    {
        #region Private Fields

        private DbContext ctx;
        private IDbSet<TEntity> _dbSet;

        #endregion

        #region Properties

        protected DbContext Context
        {
            get { return ctx; }
            set { ctx = value; }
        }

        protected IDbSet<TEntity> ObjectSet
        {
            get { return _dbSet; }
            set { _dbSet = value; }
        }

        #endregion

        #region Constructors

        public Repository()
        {
            ctx = new RestauranteContext();
        }

        public Repository(DbContext context)
        {
            ctx = context;
            _dbSet = ctx.Set<TEntity>();
        }

        #endregion

        #region ReadMethods

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> GetAllAsQueryAble(params string[] includes)
        {
            var query = ctx.Set<TEntity>().AsQueryable<TEntity>();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public IEnumerable<TEntity> GetAll(params string[] includes)
        {
            var query = ctx.Set<TEntity>().AsQueryable<TEntity>();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return ctx.Set<TEntity>().Where(where);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params string[] includes)
        {
            var query = ctx.Set<TEntity>().Where(where);

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public TEntity Single(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        #endregion

        #region UpdateMethods

        public void Update(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region SaveMethods

        public void Save(TEntity entity)
        {
            ctx.Set<TEntity>().Add(entity);
        }

        #endregion

        #region DeleteMethods

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ctx.Set<TEntity>().Remove(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> entity)
        {
            ctx.Set<TEntity>().RemoveRange(entity);
        }

        #endregion

        public void Attach(TEntity entity)
        {
            ctx.Set<TEntity>().Attach(entity);
        }

        #region DisposeMethods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        #endregion

        #region DbContext

        public DbContext GetContext()
        {
            return this.ctx;
        }

        public void SetContext(DbContext context)
        {
            this.ctx = context;
        }

        public void SaveChanges()
        {
            ctx.SaveChanges();
        }

        #endregion
    }
}
