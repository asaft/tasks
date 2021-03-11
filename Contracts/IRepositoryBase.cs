using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace usertasks.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
     
        IEnumerable<T> FindAll();
        T Find(int id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        EntityEntry<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}