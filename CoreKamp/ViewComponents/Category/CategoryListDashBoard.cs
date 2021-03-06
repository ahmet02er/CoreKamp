using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents.Category
{
    public class CategoryListDashBoard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var categoryValue = categoryManager.GenericGetList();
            return View(categoryValue);
        }
    }
}
