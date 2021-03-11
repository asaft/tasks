using System.Collections.Generic;
using usertasks.Contracts;

namespace usertasks.BE
{
    public abstract class DatabaseHandler<T>
    {
      

        public abstract T Add(T entity);
        public abstract T Update(T entity);

        public abstract IEnumerable<T> GET();
        public abstract IEnumerable<T> GET(int id);
        public abstract bool Delete(int id);

        
    }
}