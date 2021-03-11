using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using  usertasks.Contracts;

namespace usertasks.DAL
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
          protected RepositoryContext RepositoryContext { get; set; }
 
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public EntityEntry<T> Create(T entity)
        {
             return this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
             this.RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> FindByCondition(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
               this.RepositoryContext.Set<T>().Update(entity);
        }
          public void Save()
        {
                this.RepositoryContext.SaveChanges();
        }

        public T Find(int id)
        {
             return this.RepositoryContext.Set<T>().Find(id);
        }
    }
}