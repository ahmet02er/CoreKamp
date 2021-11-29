using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            ViewBag.ToplamBlogSayisi = blogManager.GenericGetList().Count();
            ViewBag.YazarBlogSayisi = blogManager.GetListWithByWriter(1).Count();
            ViewBag.ToplamKategoriSayisi = categoryManager.GenericGetList().Count();
            return View();
        }
    }
}
