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
{    //[Authorize(Roles="admin,analyst")]
    public class AdminController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly PmtctContext _context;

		public AdminController(ILogger<HomeController> logger,PmtctContext context,
				UserManager<ApplicationUser> userManager,
				RoleManager<IdentityRole> roleManager
				)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
			_logger = logger;
		}
	    public ViewResult Index() => View(_roleManager.Roles);


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
		public async Task<IActionResult> UserIndex()
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
						UserName=item.UserName,
						Email=item.Email
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
				IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					AddErrorsFromResult(result);
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


			if(role.Id == null) 
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

		public async Task<IActionResult> Edit(string id)
		{
			IdentityRole role = await _roleManager.FindByIdAsync(id);
			List<ApplicationUser> Members = new List<ApplicationUser>();
			List<ApplicationUser> NotMembers = new List<ApplicationUser>();
			foreach (ApplicationUser user in _userManager.Users)
			{
				var list = await _userManager.IsInRoleAsync(user, role.Name)
				? Members : NotMembers;
				list.Add(user);
			}
			return View(new RoleEdit
			{
				Role = role,
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
						result = await _userManager.AddToRoleAsync(user,model.RoleName);
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
		
	}
}
