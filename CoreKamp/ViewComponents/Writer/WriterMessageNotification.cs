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
    public class WriterMessageNotification : ViewComponent
    {
        NewMessageManager newMessageManager = new NewMessageManager(new EfNewMessageRepository());
        MsSqlContext msSqlContext = new MsSqlContext();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var messageValue = newMessageManager.GetInboxListByWriter(writerId);
            return View(messageValue);
        }

    }
}
