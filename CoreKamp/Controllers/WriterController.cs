using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreKamp.Models;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        WriterValidator validationRules = new WriterValidator();
        AppUserValidator validationRulesUser = new AppUserValidator();
        MsSqlContext msSqlContext = new MsSqlContext();

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        public async Task <IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.email = values.Email;
            userUpdateViewModel.namesurname = values.NameSurname;
            userUpdateViewModel.imageurl = values.ImageUrl;
            userUpdateViewModel.username = values.UserName;
            return View(userUpdateViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email=userUpdateModel.email;
            values.NameSurname=userUpdateModel.namesurname;
            values.ImageUrl= userUpdateModel.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdateModel.password);
            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "DashBoard");
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
