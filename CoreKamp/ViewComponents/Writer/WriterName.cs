using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents.Writer
{
    public class WriterName : ViewComponent
    {
        MsSqlContext msSqlContext = new MsSqlContext();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var writerName = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.name = writerName;
            return View();
        }
    }
}
