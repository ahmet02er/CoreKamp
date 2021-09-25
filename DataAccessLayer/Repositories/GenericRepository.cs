using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        MsSqlContext msSqlContext = new MsSqlContext();
        public void Delete(T parametre)
        {
            msSqlContext.Remove(parametre);
            msSqlContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return msSqlContext.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return msSqlContext.Set<T>().ToList();
        }

        public void Insert(T parametre)
        {
            msSqlContext.Add(parametre);
            msSqlContext.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return msSqlContext.Set<T>().Where(filter).ToList();
        }

        public void Update(T parametre)
        {
            msSqlContext.Update(parametre);
            msSqlContext.SaveChanges();
        }
    }
}
