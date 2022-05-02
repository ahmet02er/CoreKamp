using CoreKamp.Models;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignInViewModel userSignIn)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignIn.userName, userSignIn.userPassword, false, true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    MsSqlContext context = new MsSqlContext();
        //    var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //    if(dataValue!=null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "Admin");
        //        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "DashBoard");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

    }
}


