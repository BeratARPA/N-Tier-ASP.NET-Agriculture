using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Add(T t)
        {
            using var context = new Context();
            context.Entry(t).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            using var context = new Context();
            context.Entry(t).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
