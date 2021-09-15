using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        List<Category> categoryListAll();
        Category categoryGetById(int id);
        void categoryAdd(Category category);
        void categoryDelete(Category category);
        void categoryUpdate(Category category);


    }
}
