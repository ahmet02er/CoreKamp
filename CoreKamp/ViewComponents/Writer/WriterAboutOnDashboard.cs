using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        MsSqlContext msSqlContext = new MsSqlContext();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetWriterById(writerId);
            return View(writerValue);
        }

    }
}
