using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pmtct.Data;
using Pmtct.Models;

namespace Pmtct.Controllers
{
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
		public IActionResult Index()
        {
            return View();
        }
    }
}
