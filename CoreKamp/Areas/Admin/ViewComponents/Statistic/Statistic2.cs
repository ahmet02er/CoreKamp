using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        MsSqlContext msSqlContext = new MsSqlContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.SonBlog = msSqlContext.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.YorumSayisi = msSqlContext.Comments.Count();
            return View();
        }
    }
}
