using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EfCoreModeling.Repository
{
    class GenericRepository<T> where T : class
    {

        private AppContext context;
        private DbSet<T> table;
        public GenericRepository()
        {
            this.context = new AppContext();
            table = context.Set<T>();
        }
        public GenericRepository(AppContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }
        public IList<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById<U>(U id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete<U>(U id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch ( DbUpdateConcurrencyException )
            {
                Console.WriteLine("Error Update Concurrency !!!");
                Thread.Sleep(1000);
            }
        }



    }
}
