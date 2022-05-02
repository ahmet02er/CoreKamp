using CoreKamp.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel userSignUp)
        {
            if (!userSignUp.IsAcceptTheContract)
            {
                ModelState.AddModelError("IsAcceptTheContract",
                    "Kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekmektedir.");
                return View(userSignUp);
            }
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = userSignUp.Mail,
                    UserName = userSignUp.UserName,
                    NameSurname = userSignUp.NameSurname
                };

                var result = await _userManager.CreateAsync(appUser, userSignUp.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userSignUp);
        }
    }
}
