using BusinessLayer.Concrete;
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
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var messageValue = newMessageManager.GetInboxListByWriter(id);
            return View(messageValue);
        }

    }
}
