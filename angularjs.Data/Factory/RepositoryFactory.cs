using angularjs.Data.GenericFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angularjs.Data.Factory
{
    public class RepositoryFactory<TEntity> where TEntity : class
    {
        private static RepositoryFactory<TEntity> repositoryFactory;

        private RepositoryFactory() { }

        public static RepositoryFactory<TEntity> getInstance()
        {
            if (repositoryFactory == null)
                repositoryFactory = new RepositoryFactory<TEntity>();
            return repositoryFactory;
        }

        public IRepository<TEntity> GetRepository()
        {
            return new Repository<TEntity>();
        }
    }
}
