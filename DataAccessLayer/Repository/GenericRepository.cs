using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //bunu bu şekilde kullanamazsın DI dan çözdürmen lazım
        private readonly MyDbContext context;
        public GenericRepository(MyDbContext context)
        {
            this.context=context;
        }
        public void Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}
