using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        MsSqlContext sqlContext = new MsSqlContext();
        public void categoryAdd(Category category)
        {
            sqlContext.Add(category);
            sqlContext.SaveChanges();
        }

        public void categoryDelete(Category category)
        {
            sqlContext.Remove(category);
            sqlContext.SaveChanges();
        }

        public Category categoryGetById(int id)
        {
            return sqlContext.Categories.Find(id);
        }

        public List<Category> categoryListAll()
        {
           return sqlContext.Categories.ToList();
        }

        public void categoryUpdate(Category category)
        {
            sqlContext.Update(category);
            sqlContext.SaveChanges();
        }

        public void Delete(Category parametre)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Category parametre)
        {
            throw new NotImplementedException();
        }

        public void Update(Category parametre)
        {
            throw new NotImplementedException();
        }
    }
}
