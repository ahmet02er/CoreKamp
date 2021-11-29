using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        
        NewMessageManager newMessageManager = new NewMessageManager(new EfNewMessageRepository());
        public IActionResult InBox()
        {
            int id = 1;
            var messageValue = newMessageManager.GetInboxListByWriter(id);
            return View(messageValue);
        }

        public IActionResult MessageDetails(int id)
        {
            var messageValue = newMessageManager.GenericGetById(id);
            return View(messageValue);
        }

    }
}
