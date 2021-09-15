using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        MsSqlContext sqlContext = new MsSqlContext();
        public void Delete(T parametre)
        {
            sqlContext.Remove(parametre);
            sqlContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return sqlContext.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return sqlContext.Set<T>().ToList();
        }

        public void Insert(T parametre)
        {
            sqlContext.Add(parametre);
            sqlContext.SaveChanges();
        }

        public void Update(T parametre)
        {
            sqlContext.Update(parametre);
            sqlContext.SaveChanges();
        }
    }
}
