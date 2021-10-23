using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }


        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog>GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }
        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);
        }

        public void GenericAdd(Blog parametre)
        {
            _blogDal.Insert(parametre);
        }

        public void GenericDelete(Blog parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericUpdate(Blog parametre)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GenericGetList()
        {
             return _blogDal.GetListAll();
        }

        public Blog GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
    }
}
