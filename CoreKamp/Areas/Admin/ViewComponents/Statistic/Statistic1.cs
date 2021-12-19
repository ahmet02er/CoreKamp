using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        MsSqlContext msSqlContext = new MsSqlContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogSayisi = blogManager.GenericGetList().Count();
            ViewBag.MesajSayisi = msSqlContext.Contacts.Count();
            ViewBag.YorumSayisi = msSqlContext.Comments.Count();
            return View();
        }
    }
}
