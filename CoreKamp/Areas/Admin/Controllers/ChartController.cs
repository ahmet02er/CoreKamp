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
            List<CategoryClass> categoryList = new List<CategoryClass>();
            categoryList.Add(new CategoryClass
            {
                categoryName="Yazılım",
                categoryCount=14   
            });
            categoryList.Add(new CategoryClass
            {
                categoryName = "Teknoloji",
                categoryCount = 10
            });
            categoryList.Add(new CategoryClass
            {
                categoryName = "Spor",
                categoryCount = 5
            });

            return Json(new { jsonList = categoryList });
        }
    }
}
