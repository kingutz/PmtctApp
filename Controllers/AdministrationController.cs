using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Models.PmtctModelView;

namespace Pmtct.Controllers
{
    public class AdministrationController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly PmtctContext _context;

		public AdministrationController(ILogger<HomeController> logger, PmtctContext context,
				UserManager<ApplicationUser> userManager,
				RoleManager<IdentityRole> roleManager
				)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
			_logger = logger;
		}


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



	}
}
