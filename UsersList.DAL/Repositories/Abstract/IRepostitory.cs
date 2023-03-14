﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersList.DAL.Repositories.Abstact
{
    public interface IRepostitory<T>
    {
        public T Get(int id);
        public ICollection<T> Get(Func<T, bool> where);
        public int GetCount(Func<T, bool> where);
        public ICollection<T> Get(Func<T, bool> where, int skip, int take);
        public T Save(T item);
    }
}