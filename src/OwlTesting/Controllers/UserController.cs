using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Model.DB;
using OwlTesting.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OwlTesting.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public IActionResult Index()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();

			foreach (var user in userManager.Users.ToList())
			{
				model.Add(new UserListViewModel
				{
					Id = user.Id,
					Name = user.UserName,
					Email = user.Email,
					FullName = user.FirstName + " " + user.LastName,
					RoleName = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Name
				});
			}
            return View(model);
        }

		public IActionResult Students(int? group = null)
		{
			List<StudentListViewModel> model = new List<StudentListViewModel>();

			foreach (var user in userManager.Users.Where(x => x.Group.HasValue && (group != null ? x.Group.Value == group : true)).ToList())
			{
				model.Add(new StudentListViewModel
				{
					StudentId = user.StudentId,
					Name = user.UserName,
					FullName = user.FirstName + " " + user.LastName,
					Group = user.Group ?? 0,
					Password = user.PasswordForShow,
				});
			}

			ViewBag.Group = group;
			return View(model);
		}
		//[HttpPost]
		//public IActionResult StudentSearch(int? group)
		//{
		//	return RedirectToAction()
		//}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            return PartialView("_AddUser", model);
        }

        [HttpPost]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Group = model.Group,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
					PasswordForShow = model.ApplicationRoleId == "3" ? model.Password : string.Empty
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return View("_AddUser",model);
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> EditUser(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Name = user.UserName;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Email = user.Email;
                    model.Group = user.Group;
	                model.PasswordForShow = user.PasswordForShow;
	                model.OldPassword = user.PasswordForShow;
					model.StudentId = user.StudentId;
					model.StudyStartDate = user.StudyStartDate;
					model.StudyEndDate = user.StudyEndDate;

					try
                    {
                        model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            return PartialView("_EditUser", model);
        }

        [HttpPost]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Group = model.Group;
                    user.Email = model.Email;
					user.StudentId = model.StudentId;
					user.StudyEndDate = model.StudyEndDate;
					user.StudyStartDate = model.StudyStartDate;
	                user.PasswordForShow = model.ApplicationRoleId == "3" ? model.PasswordForShow : string.Empty;

                    IdentityResult result = await userManager.UpdateAsync(user);
	                if (model.OldPassword != model.PasswordForShow && model.ApplicationRoleId == "3")
	                {
						IdentityResult passwordChangeResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.PasswordForShow);
	                }
					if (result.Succeeded)
                    {
                        try
                        {
                            string existingRole = userManager.GetRolesAsync(user).Result.Single();
                            string existingRoleId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
                            if (existingRoleId != model.ApplicationRoleId)
                            {
                                IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
                                if (roleResult.Succeeded)
                                {
                                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                                    if (applicationRole != null)
                                    {
                                        IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                        if (newRoleResult.Succeeded)
                                        {
                                            return RedirectToAction("Index");
                                        }
                                    }
                                }
                            }
							else
							{
								return RedirectToAction("Index");
							}
                        }
                        catch
                        {
                            ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                            if (applicationRole != null)
                            {
                                IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                if (newRoleResult.Succeeded)
                                {
                                    return RedirectToAction("Index");
                                }
                            }
                        }
                    }
                }
            }
            return PartialView("_EditUser", model);
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.UserName;
                }
            }
            return PartialView("_DeleteUser", name);
        }

        [HttpPost]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteUser(string id, FormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}
