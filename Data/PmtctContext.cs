using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pmtct.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Pmtct.Data
{
    public class PmtctContext : IdentityDbContext<ApplicationUser>
   
    {
        public PmtctContext (DbContextOptions<PmtctContext> options)
            : base(options)
        {
        }

        public DbSet<PmtctData> Pmt { get; set; }

       
        public DbSet<PmtctFollowUp> PmtctFollowUp { get; set; }
        //public DbSet<ExtendedLog> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {        

            base.OnModelCreating(builder);

            //LogModelBuilderHelper.Build(builder.Entity<ExtendedLog>());

            //// real relation database can map table:
            //builder.Entity<ExtendedLog>().ToTable("Log");
            //builder.Entity<ExtendedLog>().Property(r => r.Id).ValueGeneratedOnAdd();

            //builder.Entity<ExtendedLog>().HasIndex(r => r.TimeStamp).HasName("IX_Log_TimeStamp");
            //builder.Entity<ExtendedLog>().HasIndex(r => r.EventId).HasName("IX_Log_EventId");
            //builder.Entity<ExtendedLog>().HasIndex(r => r.Level).HasName("IX_Log_Level");

            //builder.Entity<ExtendedLog>().Property(u => u.Name).HasMaxLength(255);
            //builder.Entity<ExtendedLog>().Property(u => u.Browser).HasMaxLength(255);
            //builder.Entity<ExtendedLog>().Property(u => u.User).HasMaxLength(255);
            //builder.Entity<ExtendedLog>().Property(u => u.Host).HasMaxLength(255);
            //builder.Entity<ExtendedLog>().Property(u => u.Path).HasMaxLength(255);
        }
    }


    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }


    //public class ExtendedLog : Log
    //{
    //    public ExtendedLog(IHttpContextAccessor accessor)
    //    {
    //        string browser = accessor.HttpContext.Request.Headers["User-Agent"];
    //        if (!string.IsNullOrEmpty(browser) && (browser.Length > 255))
    //        {
    //            browser = browser.Substring(0, 255);
    //        }

    //        this.Browser = browser;
    //        this.Host = accessor.HttpContext.Connection?.RemoteIpAddress?.ToString();
    //        this.User = accessor.HttpContext.User?.Identity?.Name;
    //        this.Path = accessor.HttpContext.Request.Path;
    //    }

    //    protected ExtendedLog()
    //    {
    //    }

    //    public string Browser { get; set; }
    //    public string Host { get; set; }
    //    public string Path { get; set; }
    //    public string User { get; set; }
    //}
}
