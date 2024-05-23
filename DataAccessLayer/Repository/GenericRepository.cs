using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var db = new Context();            
            db.Remove(t);
            db.SaveChanges();
        }

        public List<T> GetList()
        {
            using var db = new Context();
            return db.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            using var db = new Context();
            return db.Set<T>().Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            using var db = new Context();
            return db.Set<T>().Where(filter).ToList();
        }

        public void Insert(T t)
        {
            using var db = new Context();
            db.Add(t);
            db.SaveChanges();
        }

        public void Update(T t)
        {
            using var db = new Context();
            db.Update(t);
            db.SaveChanges();
        }
    }
}
