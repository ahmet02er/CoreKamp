using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values=blogManager.GetListWithCategory();
            return View(values);
        }
    }
}
