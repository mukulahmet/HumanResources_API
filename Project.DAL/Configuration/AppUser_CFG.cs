using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models.Concrete;

namespace Project.DAL.Configuration
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser appUser = new AppUser
            {
                Id = 1,
                Name = "Bora",
                LastName = "Yildirim",
                BirthDate = DateTime.Now,
                TC="11111111111",
                UserName = "Bora@gmail.com",
                NormalizedUserName = "BORA@GMAIL.COM",
                Email = "Bora@gmail.com",
                NormalizedEmail = "BORA@GMAIL.COM",
                Address = "Uskudar",
                EmailConfirmed = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                ImagePath = "/images/default.jpg"
            };


            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "BoraAdmin_123");

            builder.HasData(appUser);

        }
    }
}
