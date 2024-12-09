using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Seed
{
	internal class SeedAppUser : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.HasData(
				new AppUser
				{
					Id = 2,
					Name = "Mahmut",
					LastName = "Taylan",
					BirthDate = DateTime.Now,
					TC = "11111111111",
					UserName = "Mahmut@bilgeadam.com",
					NormalizedUserName = "MAHMUT@BİLGEADAM.COM",
					Email = "Mahmut@bilgeadam.com",
					NormalizedEmail = "MAHMUT@BİLGEADAM.COM",
					Address = "Antalya",
					CompanyID = 1,
					DepartmentID = 1,
					JobID = 1,
					EmailConfirmed = false,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					ActivityStatus = Models.Enums.ActivityStatus.Avaliable,
					Salary = 75000
				},
				   new AppUser
				   {
					   Id = 3,
					   Name = "Eylem",
					   LastName = "Eryılmaz",
					   BirthDate = DateTime.Now,
					   TC = "11111111111",
					   UserName = "Eylem@bilgeadam.com",
					   NormalizedUserName = "EYLEM@BİLGEADAM.COM",
					   Email = "Eylem@bilgeadam.com",
					   NormalizedEmail = "EYLEM@BİLGEADAM.COM",
					   Address = "Kadikoy",
					   CompanyID = 1,
					   DepartmentID = 1,
					   JobID = 2,
					   Salary = 10000,
					   EmailConfirmed = false,
					   ConcurrencyStamp = Guid.NewGuid().ToString(),
					   SecurityStamp = Guid.NewGuid().ToString(),
					   ActivityStatus = Models.Enums.ActivityStatus.Avaliable
				   },
				   new AppUser
				   {
					   Id = 4,
					   Name = "Ahmet",
					   LastName = "Yılmaz",
					   BirthDate = DateTime.Now,
					   TC = "22222222222",
					   UserName = "Ahmet@bilgeadam.com",
					   NormalizedUserName = "AHMET@BILGEADAM.COM",
					   Email = "Ahmet@bilgeadam.com",
					   NormalizedEmail = "AHMET@BILGEADAM.COM",
					   Address = "Ankara",
					   CompanyID = 1,
					   DepartmentID = 1,
					   JobID = 2,
					   Salary = 10000,
					   EmailConfirmed = false,
					   ConcurrencyStamp = Guid.NewGuid().ToString(),
					   SecurityStamp = Guid.NewGuid().ToString(),
					   ActivityStatus = Models.Enums.ActivityStatus.Avaliable
				   },
					 new AppUser
					 {
						 Id = 5,
						 Name = "Mukul",
						 LastName = "Bekfilavioglu",
						 BirthDate = DateTime.Now,
						 TC = "33333333333",
						 UserName = "Mukul@bilgeadam.com",
						 NormalizedUserName = "MUKUL@BILGEADAM.COM",
						 Email = "Mukul@bilgeadam.com",
						 NormalizedEmail = "MUKUL@BILGEADAM.COM",
						 Address = "Edirne",
						 CompanyID = 1,
						 DepartmentID = 1,
						 JobID = 2,
						 EmailConfirmed = false,
						 ConcurrencyStamp = Guid.NewGuid().ToString(),
						 SecurityStamp = Guid.NewGuid().ToString(),
						 ActivityStatus = Models.Enums.ActivityStatus.Avaliable
					 }
				);
		}
	}
}
