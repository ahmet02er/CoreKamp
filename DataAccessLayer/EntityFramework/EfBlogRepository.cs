using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public void blogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void blogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog blogGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> blogListAll()
        {
            throw new NotImplementedException();
        }

        public void blogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
