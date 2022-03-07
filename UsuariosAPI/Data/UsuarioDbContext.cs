using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    public class UsuarioDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt, IConfiguration configuration = null) : base(opt)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<CustomIdentityUser> haser = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = haser.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>()
                .HasData(new IdentityRole<int> {Id = 99999, Name = "admin", NormalizedName = "ADMIN"});
                
            builder.Entity<IdentityRole<int>>()
                .HasData(new IdentityRole<int> {Id = 99997, Name = "regular", NormalizedName = "REGULAR"});

            builder.Entity<IdentityUserRole<int>>()
                .HasData(new IdentityUserRole<int> {RoleId = 99999, UserId = 99999});

        }
    }
}