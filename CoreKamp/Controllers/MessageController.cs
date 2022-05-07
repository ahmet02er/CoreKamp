using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    public class MessageController : Controller
    {
        
        NewMessageManager newMessageManager = new NewMessageManager(new EfNewMessageRepository());
        MsSqlContext msSqlContext = new MsSqlContext();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var messageValue = newMessageManager.GetInboxListByWriter(writerId);
            return View(messageValue);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var messageValue = newMessageManager.GetSendboxListByWriter(writerId);
            return View(messageValue);
        }

        public IActionResult MessageDetails(int id)
        {
            var messageValue = newMessageManager.GenericGetById(id);
            return View(messageValue);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(NewMessage newMessage)
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            newMessage.MessageSenderId = writerId;
            newMessage.MessageReceiverId = 2;
            newMessage.MessageStatus = true;
            newMessage.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            newMessageManager.GenericAdd(newMessage);
            return RedirectToAction("InBox");
        }
    }
}
