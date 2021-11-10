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
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string mail = "ahmet@ahmet.com";
            var messageValue = messageManager.GetInboxListByWriter(mail);
            return View(messageValue);
        }

    }
}
