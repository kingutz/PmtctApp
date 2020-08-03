using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pmtct.Data;
using Pmtct.Models;

namespace Pmtct.Controllers

{   [Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly PmtctContext _context;

		public AdminController(ILogger<HomeController> logger, PmtctContext context,
				UserManager<ApplicationUser> userManager,
				RoleManager<IdentityRole> roleManager
				)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
			_logger = logger;
		}
		//public ViewResult Index() => View(_roleManager.Roles);
		//public async Task<IActionResult> Index()
		//{
		//	var role = new List<Role>();

		//	try
		//	{
		//		var roles = await _roleManager.Roles.ToListAsync();
		//		foreach (var item in roles)
		//		{
		//			role.Add(new Role()
		//			{
		//				Id = item.Id,
		//				Name = item.Name,
		//			});
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger?.LogError(ex, ex.GetBaseException().Message);
		//	}

		//	return View(role);

		//}

		public async Task<IActionResult> RoleIndex()
		{
			var role = new List<Role>();

			try
			{
				var roles = await _roleManager.Roles.ToListAsync();
				foreach (var item in roles)
				{
					role.Add(new Role()
					{
						Id = item.Id,
						Name = item.Name,
					});
				}
			}
			catch (Exception ex)
			{
				_logger?.LogError(ex, ex.GetBaseException().Message);
			}

			return View(role);
		}
		public async Task<IActionResult> Index()
		{
			var user = new List<UserData>();

			try
			{
				var users = await _userManager.Users.ToListAsync();
				foreach (var item in users)
				{
					user.Add(new UserData()
					{
						Id = item.Id,
						Name = item.Name,
						UserName = item.UserName,
						Email = item.Email
					});
				}
			}
			catch (Exception ex)
			{
				_logger?.LogError(ex, ex.GetBaseException().Message);
			}

			return View(user);
		}

		public ViewResult Create() => View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Required] string name)
		{
			if (ModelState.IsValid)
			{
				var roleexist = await _roleManager.RoleExistsAsync(name);
                if (!roleexist)
                {
				var result = await _roleManager.CreateAsync(new IdentityRole(name));
				}
				
				
			}
			return View(name);
		}
		// GET: Pmtct/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			IdentityRole role = await _roleManager.FindByIdAsync(id);


			if (role.Id == null)
			{
				return NotFound();
			}

			return View(role);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			IdentityRole role = await _roleManager.FindByIdAsync(id);
			if (role != null)
			{
				//IdentityResult result = await _roleManager.DeleteAsync(role);
				IdentityResult result = await _roleManager.DeleteAsync(role);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					AddErrorsFromResult(result);
				}
			}
			else
			{
				ModelState.AddModelError("", "No role found");
			}
			return View("Index", _roleManager.Roles);
		}
		private void AddErrorsFromResult(IdentityResult result)
		{
			foreach (IdentityError error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
		}

		[HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            List<ApplicationUser> Members = new List<ApplicationUser>();
            List<ApplicationUser> NotMembers = new List<ApplicationUser>();

            foreach (var userapp in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(userapp, role.Name)
                ? Members : NotMembers;
                list.Add(userapp);
            }
            return View(new RoleEdit
            {
                RoleName = role,
                MemberToRole = Members,
                NotMembersToRole = NotMembers
            });
        }

        [HttpPost]
		public async Task<IActionResult> Edit(UserToRole model)
		{
			IdentityResult result;
			if (ModelState.IsValid)
			{
				foreach (string userId in model.IdToAdd ?? new string[] { })
				{
					ApplicationUser user = await _userManager.FindByIdAsync(userId);
					if (user != null)
					{
						result = await _userManager.AddToRoleAsync(user, model.RoleName);
						if (!result.Succeeded)
						{
							AddErrorsFromResult(result);
						}
					}
				}

				foreach (string userId in model.IdToDelete ?? new string[] { })
				{
					ApplicationUser user = await _userManager.FindByIdAsync(userId);
					if (user != null)
					{
						result = await _userManager.RemoveFromRoleAsync(user,
						model.RoleName);
						if (!result.Succeeded)
						{
							AddErrorsFromResult(result);
						}
					}
				}
			}
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Edit(model.RoleId);
            }
        }

		[HttpGet]
		public async Task<IActionResult> EditU(string id)
		{
			ApplicationUser user = await _userManager.FindByIdAsync(id);

			ViewBag.UserId = user.Id;

			var role = new List<Role>();
			
			try
			{
				var roles = await _roleManager.Roles.ToListAsync();
				foreach (var item in roles)
				{
					role.Add(new Role()
					{
						Id = item.Id,
						Name = item.Name,
						
					});
				}
			}
			catch (Exception ex)
			{
				_logger?.LogError(ex, ex.GetBaseException().Message);
			}

			return View(role);
			
		}
		[HttpPost]
		public async Task<IActionResult> EditU(string userid,string roleid)
		{
			IdentityResult result;
			if (ModelState.IsValid)
			{			
				
					ApplicationUser user = await _userManager.FindByIdAsync(userid);
				     var role = await _roleManager.FindByIdAsync(roleid);
				   
				if (user != null)
					{
						result = await _userManager.AddToRoleAsync(user, role.Name);
						if (!result.Succeeded)
						{
							AddErrorsFromResult(result);
						}
					}
            }
            else
            {
				ApplicationUser user = await _userManager.FindByIdAsync(userid);
				var role = await _roleManager.FindByIdAsync(roleid);
				if (user != null)
				{
					result = await _userManager.RemoveFromRoleAsync(user,
					role.Name);
					if (!result.Succeeded)
					{
						AddErrorsFromResult(result);
					}
				}
			}
			
				return RedirectToAction(nameof(Index));
			
			//else
			//{
			//	return await Edit(model.RoleId);
			//}
		}
		
		public async Task<IActionResult> EditUsersInRole(string roleid)
		{
			ViewBag.roleid = roleid;
			var role = await _userManager.FindByIdAsync(roleid);
			if (role == null)
			{
				ViewBag.ErroMessage = $"Role with id{roleid} cannot be found";
				return View("Not found");
			}
			var model = new List<UserRole>();
			foreach (var user in _userManager.Users)
			{
				var userrole = new UserRole { UserId = user.Id, UserName = user.Name };

				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					userrole.IsSelected = true;
				}
				else
				{
					userrole.IsSelected = false;
				}
				model.Add(userrole);
			}
			return View(model);
		}
		
		[HttpPost]
		public async Task<IActionResult> EditUsersInRole(List<UserRole> model, string roleId)
		{
			var role = await _roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
				return View("NotFound");
			}

			for (int i = 0; i < model.Count; i++)
			{
				var user = await _userManager.FindByIdAsync(model[i].UserId);

				IdentityResult result = null;

				if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
				{
					result = await _userManager.AddToRoleAsync(user, role.Name);
				}
				else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
				{
					result = await _userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					continue;
				}

				if (result.Succeeded)
				{
					if (i < (model.Count - 1))
						continue;
					else
						return RedirectToAction("EditRole", new { Id = roleId });
				}
			}

			return RedirectToAction("EditRole", new { Id = roleId });
		}
		

		[HttpGet]
		public IActionResult ListRoles()
		{
			var roles = _roleManager.Roles;
			return View(roles);
		}
		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleModel model)
		{
			if (ModelState.IsValid)
			{
				// We just need to specify a unique role name to create a new role
				IdentityRole identityRole = new IdentityRole
				{
					Name = model.RoleName
				};

				// Saves the role in the underlying AspNetRoles table
				IdentityResult result = await _roleManager.CreateAsync(identityRole);

				if (result.Succeeded)
				{
					return RedirectToAction("index", "home");
				}

				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

	}
}
