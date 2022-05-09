using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        [Area("Admin")]
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
