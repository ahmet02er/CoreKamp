using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            string api = "659c1dd7e1a3af35a72028df2d6dd1b1";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Sakarya&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.sicaklik = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
