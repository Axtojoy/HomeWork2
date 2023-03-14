using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Repositories.Abstact;

namespace UsersList.DAL.Repositories
{
    public abstract class Repository<T> : IRepostitory<T>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Get(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Get(Func<T, bool> where, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }

        public T Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
