using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pmtct.Data;
using Microsoft.AspNetCore.Identity;

namespace Pmtct
{
    public class DbInitializer
    {
		public static void Initialize(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<PmtctContext>();
				context.Database.EnsureCreated();

				var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
				var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!context.Users.Any(usr => usr.UserName == "admin@pmtct.com"))
				{
					var user = new ApplicationUser()
					{
						UserName = "admin@pmtct.com",
						Email = "admin@pmtct.com",
						EmailConfirmed = true,
					};

					var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
				}
				if (!context.Users.Any(usr => usr.UserName == "Analyst@pmtct.com"))
				{
					var user = new ApplicationUser()
					{
						UserName = "Analyst@pmtct.com",
						Email = "Analyst@pmtct.com",
						EmailConfirmed = true,
					};

					var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
				}

				if (!_roleManager.RoleExistsAsync("Admin").Result)
				{
					var role = _roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Result;
				}
				if (!_roleManager.RoleExistsAsync("Analyst").Result)
				{
					var role = _roleManager.CreateAsync(new IdentityRole { Name = "Analyst" }).Result;
				}
				var adminUser = _userManager.FindByNameAsync("admin@pmtct.com").Result;
				var adminRole = _userManager.AddToRolesAsync(adminUser, new string[] { "Admin" }).Result;

				var clerkUser = _userManager.FindByNameAsync("Analyst@pmtct.com").Result;
				var clerkRole = _userManager.AddToRolesAsync(clerkUser, new string[] { "Analyst" }).Result;
			}

		}
		
	}
}
