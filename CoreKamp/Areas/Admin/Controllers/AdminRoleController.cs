using CoreKamp.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = roleModel.name,
                    NormalizedName = roleModel.name.ToUpper()
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(roleModel);
        }


        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateModel roleUpdateModel = new RoleUpdateModel
            {
                Id = values.Id,
                Name = values.Name,
            };
            return View(roleUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateModel roleUpdateModel)
        {
            var values = _roleManager.Roles.Where(x => x.Id == roleUpdateModel.Id).FirstOrDefault();
            values.Name = roleUpdateModel.Name;
            values.NormalizedName = roleUpdateModel.Name.ToUpper();
            var result = await _roleManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(roleUpdateModel);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole (int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user) ;
            List<RoleAssignModel> models = new List<RoleAssignModel>();
            foreach (var item in roles)
            {
                RoleAssignModel roleModel = new RoleAssignModel();
                roleModel.RoleId = item.Id;
                roleModel.Name = item.Name;
                roleModel.Exists = userRoles.Contains(item.Name);
                models.Add(roleModel);
            }
            return View(models);
            
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel>models)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in models)
            {
                if(item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);

                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
