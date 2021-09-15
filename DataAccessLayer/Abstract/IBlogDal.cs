using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal
    {
        List<Blog> blogListAll();
        Blog blogGetById(int id);
        void blogAdd(Blog blog);
        void blogDelete(Blog blog);
        void blogUpdate(Blog blog);
    }
}
