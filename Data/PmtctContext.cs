using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pmtct.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pmtct.Data
{
    public class PmtctContext : IdentityDbContext<ApplicationUser>
   
    {
        public PmtctContext (DbContextOptions<PmtctContext> options)
            : base(options)
        {
        }

        public DbSet<PmtctData> Pmt { get; set; }

        public DbSet<Pmtct.Models.PmtctCareCascade> PmtctCareCascade { get; set; }
        public DbSet<Pmtct.Models.PmtctFollowUp> PmtctFollowUp { get; set; }

        

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            
        //    builder.Entity<PmtctCareCascade>()
        //   .HasKey(c => new { c.ID, c.NambaMshiriki01 });
        //    builder.Entity<PmtctFollowUp>()
        //   .HasKey(c => new { c.ID, c.NambaMshiriki01 });

        //    base.OnModelCreating(builder);
        //}
    }


    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }
}
