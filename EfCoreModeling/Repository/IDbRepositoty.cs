using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Repository
{
    interface IDbRepositoty<T> where T : class
    {

        IList<T> GetAll();
        T GetById<U>(U id);
        void Insert(T obj);
        void Update(T obj);
        void Delete<U>(U id);
        void Save();
    }
}
