using CoreKamp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValue = new List<CommentUser>
            {
                new CommentUser
                {
                    Id=1,
                    UserName="Ahmet"
                },
                new CommentUser
                {
                    Id=2,
                    UserName="ÖZER"
                },
                new CommentUser
                {
                    Id=3,
                    UserName="AspNet"
                }
            };
            return View(commentValue);
        }
    }
}
