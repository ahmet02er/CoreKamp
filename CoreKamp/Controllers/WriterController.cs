using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreKamp.Models;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{

    public class WriterController : Controller
    {
        
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        WriterValidator validationRules = new WriterValidator();
        MsSqlContext msSqlContext = new MsSqlContext();
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.mail = usermail;
            var writerName = msSqlContext.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.name = writerName;
            return View();
        }
        public IActionResult TodoList()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult WriterTest()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {

            var usermail = User.Identity.Name;
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GenericGetById(writerId);
            return View(writerValue);
        }
 
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            ValidationResult validation = validationRules.Validate(writer);
            if (validation.IsValid)
            {
                writerManager.GenericUpdate(writer);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                foreach (var item in validation.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if (addProfileImage.WriterImage!=null)
            {
                var fileExtension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + fileExtension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterPasswordConfirm = addProfileImage.WriterPasswordConfirm;
            writer.WriterStatus = true;
            writer.WriterAbout = addProfileImage.WriterAbout;
            writerManager.GenericAdd(writer);
            return RedirectToAction("Index", "DashBoard");
        }
    }
}
