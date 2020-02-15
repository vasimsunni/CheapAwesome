using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CheapAwesome.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recta.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Entities
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(a =>
            {
                a.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(u => u.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            //Add roles to identity role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "User"
            });

            //Instance a password hasher to encrypt password
            var hasher = new PasswordHasher<ApplicationUser>();
            //Add one admin
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1",
                UserName = "vasim",
                NormalizedUserName = "vasim",
                FirstName = "Vasim",
                LastName = "Vasim",
                Email = "sunni.vasim@gmail.com",
                PhoneNumber = "+971568252376",
                City = "Dubai",
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "vasim123"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            });

            //Add role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });

        }
    }
}
