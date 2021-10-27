using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void GenericAdd(Category parametre)
        {
            _categoryDal.Insert(parametre);
        }

        public void GenericDelete(Category parametre)
        {
            _categoryDal.Delete(parametre);
        }

        public Category GenericGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GenericGetList()
        {
            return _categoryDal.GetListAll();
        }

        public void GenericUpdate(Category parametre)
        {
            _categoryDal.Update(parametre);
        }

    }
}
