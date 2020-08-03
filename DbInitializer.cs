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
				

				if (!_roleManager.RoleExistsAsync("admin").Result)
				{
					var role = _roleManager.CreateAsync(new IdentityRole { Name = "admin" }).Result;
				}
				
				var adminUser = _userManager.FindByNameAsync("admin@pmtct.com").Result;
				var adminRole = _userManager.AddToRolesAsync(adminUser, new string[] { "admin" }).Result;


                if (!context.Users.Any(usr => usr.UserName == "data@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data@pmtct.gov",
                        Email = "data@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("analyst").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "analyst" }).Result;
                }

                var dataUser = _userManager.FindByNameAsync("data@pmtct.gov").Result;
                var dataRole = _userManager.AddToRolesAsync(dataUser, new string[] { "analyst" }).Result;


                if (!context.Users.Any(usr => usr.UserName == "data1@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data1@pmtct.gov",
                        Email = "data1@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }


                var data1User = _userManager.FindByNameAsync("data1@pmtct.gov").Result;
                var data1Role = _userManager.AddToRolesAsync(data1User, new string[] { "dataentry" }).Result;


                if (!context.Users.Any(usr => usr.UserName == "data2@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data2@pmtct.gov",
                        Email = "data2@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data2User = _userManager.FindByNameAsync("data2@pmtct.gov").Result;
                var data2Role = _userManager.AddToRolesAsync(data2User, new string[] { "dataentry" }).Result;



                if (!context.Users.Any(usr => usr.UserName == "data3@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data3@pmtct.gov",
                        Email = "data3@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data3User = _userManager.FindByNameAsync("data3@pmtct.gov").Result;
                var data3Role = _userManager.AddToRolesAsync(data3User, new string[] { "dataentry" }).Result;



                if (!context.Users.Any(usr => usr.UserName == "data4@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data4@pmtct.gov",
                        Email = "data4@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data4User = _userManager.FindByNameAsync("data4@pmtct.gov").Result;
                var data4Role = _userManager.AddToRolesAsync(data4User, new string[] { "dataentry" }).Result;


                if (!context.Users.Any(usr => usr.UserName == "data5@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data5@pmtct.gov",
                        Email = "data5@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data5User = _userManager.FindByNameAsync("data5@pmtct.gov").Result;
                var data5Role = _userManager.AddToRolesAsync(data5User, new string[] { "dataentry" }).Result;



                if (!context.Users.Any(usr => usr.UserName == "data6@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data6@pmtct.gov",
                        Email = "data6@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data6User = _userManager.FindByNameAsync("data6@pmtct.gov").Result;
                var data6Role = _userManager.AddToRolesAsync(data6User, new string[] { "dataentry" }).Result;

                if (!context.Users.Any(usr => usr.UserName == "data7@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data7@pmtct.gov",
                        Email = "data7@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data7User = _userManager.FindByNameAsync("data7@pmtct.gov").Result;
                var data7Role = _userManager.AddToRolesAsync(data7User, new string[] { "dataentry" }).Result;

                if (!context.Users.Any(usr => usr.UserName == "data8@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data8@pmtct.gov",
                        Email = "data8@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data8User = _userManager.FindByNameAsync("data8@pmtct.gov").Result;
                var data8Role = _userManager.AddToRolesAsync(data8User, new string[] { "dataentry" }).Result;

                if (!context.Users.Any(usr => usr.UserName == "data9@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data9@pmtct.gov",
                        Email = "data9@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data9User = _userManager.FindByNameAsync("data9@pmtct.gov").Result;
                var data9Role = _userManager.AddToRolesAsync(data9User, new string[] { "dataentry" }).Result;


                if (!context.Users.Any(usr => usr.UserName == "data10@pmtct.gov"))
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "data10@pmtct.gov",
                        Email = "data10@pmtct.gov",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "pmtct2020").Result;
                }


                if (!_roleManager.RoleExistsAsync("dataentry").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "dataentry" }).Result;
                }

                var data10User = _userManager.FindByNameAsync("data10@pmtct.gov").Result;
                var data10Role = _userManager.AddToRolesAsync(data10User, new string[] { "dataentry" }).Result;








            }

        }
		
	}
}
