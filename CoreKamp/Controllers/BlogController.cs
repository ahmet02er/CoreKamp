using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
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
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogValidator validationRules = new BlogValidator();
        public IActionResult Index()
        {
            var blogValue = blogManager.GetListWithCategory();
            return View(blogValue);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var blogValue = blogManager.GetBlogById(id);
            return View(blogValue);
        }

        public IActionResult BlogListByWriter()
        {
            var writerValue = blogManager.GetListCategoryByWriter(1);
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
            ValidationResult validationResult = validationRules.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
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
    }
}
