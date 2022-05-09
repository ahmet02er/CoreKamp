using CoreKamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName = "Teknoloji",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "Yazılım",
                categoryCount = 5
            });
            list.Add(new CategoryClass
            {
                categoryName = "Spor",
                categoryCount = 2
            });
            return Json(new { jsonlist = list });
        }
    }
}
