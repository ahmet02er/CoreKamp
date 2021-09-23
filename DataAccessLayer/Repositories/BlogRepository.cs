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
    public class BlogRepository : IBlogDal
    {
        public void blogAdd(Blog blog)
        {
            using var sqlContext = new MsSqlContext();
            sqlContext.Add(blog);
            sqlContext.SaveChanges();
        }

        public void blogDelete(Blog blog)
        {
            using var sqlContext = new MsSqlContext();
            sqlContext.Remove(blog);
            sqlContext.SaveChanges();
        }

        public Blog blogGetById(int id)
        {
            using var sqlContext = new MsSqlContext();
            return sqlContext.Blogs.Find(id);
        }

        public List<Blog> blogListAll()
        {
            using var sqlContext = new MsSqlContext();
            return sqlContext.Blogs.ToList();
        }

        public void blogUpdate(Blog blog)
        {
            using var sqlContext = new MsSqlContext();
            sqlContext.Update(blog);
            sqlContext.SaveChanges();
        }

        public void Delete(Blog parametre)
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Blog parametre)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog parametre)
        {
            throw new NotImplementedException();
        }
    }
}
