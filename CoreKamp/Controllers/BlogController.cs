﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
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
    }
}
