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

using Audit.EntityFramework;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Pmtct.Services;

namespace Pmtct.Data

{
    public class PmtctContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService currentUserService;

        public PmtctContext(DbContextOptions<PmtctContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public DbSet<PmtctData> Pmt { get; set; }


        public DbSet<PmtctFollowUp> PmtctFollowUp { get; set; }

      

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<PmtctData>()
                .HasIndex(u => u.NambaMshiriki01)
             .IsUnique();

              builder.Entity<PmtctData>()
             .HasMany(i => i.followup).WithOne(c => c.pmtctData).OnDelete(DeleteBehavior.Cascade);



        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSave()
        {
            var currentTime = DateTimeOffset.UtcNow;
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is EntityData))
            {
                var entidad = item.Entity as EntityData;
                entidad.CreatedDate = currentTime;
                entidad.CreatedByUser = currentUserService.GetCurrentUsername();
                entidad.ModifiedDate = currentTime;
                entidad.ModifiedByUser = currentUserService.GetCurrentUsername();
            }

            foreach (var item in ChangeTracker.Entries()
                .Where(predicate: e => e.State == EntityState.Modified && e.Entity is EntityData))
            {
                var entidad = item.Entity as EntityData;
                entidad.ModifiedDate = currentTime;
                entidad.Edited=true;
                entidad.ModifiedByUser = currentUserService.GetCurrentUsername();
                item.Property(nameof(entidad.CreatedDate)).IsModified = false;
                item.Property(nameof(entidad.CreatedByUser)).IsModified = false;
            }
        }

    }
        public class ApplicationUser : IdentityUser
        {
            [PersonalData]
            public string Name { get; set; }
        }

       
        

    }
