using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
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
        MsSqlContext msSqlContext = new MsSqlContext();
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.ToplamBlogSayisi = blogManager.GenericGetList().Count();
            ViewBag.YazarBlogSayisi = blogManager.GetListWithByWriter(writerId).Count();
            ViewBag.ToplamKategoriSayisi = categoryManager.GenericGetList().Count();
            return View();
        }
    }
}
