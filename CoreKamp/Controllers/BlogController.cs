using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogValidator validationRules = new BlogValidator();
        MsSqlContext msSqlContext = new MsSqlContext();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var blogValue = blogManager.GetListWithCategory();
            return View(blogValue);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var blogValue = blogManager.GetBlogById(id);
            return View(blogValue);
        }

        public IActionResult BlogListByWriter()
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = blogManager.GetListCategoryByWriter(writerId);
            return View(writerValue);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValue = (from x in categoryManager.GenericGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.category = categoryValue;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();

            ValidationResult validationResult = validationRules.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                blogManager.GenericAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blogManager.GenericGetById(id);
            blogManager.GenericDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blogValue = blogManager.GenericGetById(id);

            List<SelectListItem> categoryValue = (from x in categoryManager.GenericGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.category = categoryValue;

            return View(blogValue);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = msSqlContext.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = msSqlContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();

            blog.WriterId = writerId;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.GenericUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
