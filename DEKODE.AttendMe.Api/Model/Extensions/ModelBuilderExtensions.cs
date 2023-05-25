using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using DEKODE.AttendMe.Common;

namespace DEKODE.AttendMe.Api.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // If you prefer to keep your OnModelCreating method clean, you can refactor these operations into an extension method on the ModelBuilder type:
            // then you can call the Seed method in OnModelCreating
            // https://www.learnentityframeworkcore.com/migrations/seeding

            // Seeding Owned Entities
            // https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/august/data-points-deep-dive-into-ef-core-hasdata-seeding#seeding-owned-entities

            //// Account seed.
            //modelBuilder.Entity<Account>().HasData(
            //        new Account
            //        {
            //            Id = 1,
            //            Guid = Guid.NewGuid(),
            //            Name = "Australian Cricket Board",
            //            ContactName = "Shane Warne",
            //            ContactPhone = "0421587458",
            //            ContactEmail = "swarne@acb.com.au",
            //            ABN = "546-879-854",
            //            IsActive = true,
            //            //SubscriptionId = 1,
            //            AuditUser = "sys_admin",
            //            EffectiveStartDate = DateTime.Today,
            //            EffectiveEndDate = new DateTime(2023, 08, 18),
            //            IsDeleted = false,
            //        }
            //);
            //modelBuilder.Entity<Account>()
            //    .OwnsOne(m => m.Address)
            //    .HasData(new
            //    {
            //        Country = "Australia",
            //        PostCode = "3000",
            //        State = "VIC",
            //        StreetName = "Station Street",
            //        StreetNo = "14",
            //        Suburb = "Melbourne",
            //        AccountId = 1
            //    });

            //modelBuilder.Entity<AccountUser>().HasData(
            //        new AccountUser
            //        {
            //            Id = 1,
            //            Guid = Guid.NewGuid(),
            //            FirstName = "Cricket VIC",
            //            LastName = "Brad Hodge",
            //            UserName = "bhodge",
            //            Password = "password",
            //            AccountId = 1,
            //            EffectiveStartDate = DateTime.Today,
            //            EffectiveEndDate = new DateTime(2021, 05, 30),
            //            AuditUser = "sys_admin",
            //            IsDeleted = false
            //        }
            //    );

            modelBuilder.Entity<SbscrptnType>().HasData(
                    new SbscrptnType
                    {
                        Id = 1,
                        //Guid = Guid.NewGuid(),
                        Description = "Annual",
                        Amount = 1200,
                        DevicesAllowed = 2,
                        EffectiveStartDate = DateTime.Today,
                        EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                        AuditUser = "sys_admin",
                        IsDeleted = false
                    }
                );

            //// Subscription seed.
            //modelBuilder.Entity<AccSbscrptn>().HasData(
            //        new AccSbscrptn
            //        {
            //            Id = 1,
            //            Guid = Guid.NewGuid(),
            //            StartDate = DateTime.Today,
            //            EndDate = DateTime.Today.AddYears(1),
            //            IsActive = true,
            //            AccountId = 1,
            //            SbscrptnTypeId = 1,
            //            EffectiveStartDate = DateTime.Today,
            //            EffectiveEndDate = new DateTime(2021, 05, 30),
            //            AuditUser = "sys_admin",
            //            IsDeleted = false
            //        }
            //    );

            modelBuilder.Entity<Organisation>().HasData(
                    new Organisation
                    {
                        Id = 1,
                        //Guid = Guid.NewGuid(),
                        Name = "Cricket NSW",
                        ContactName = "Adam Gilchrist",
                        ContactPhone = "0421119636",
                        ContactEmail = "gmaxwell@cricnsw.com.au",
                        //AccountId = 1,
                        //AccSbscrptnId = 1,
                        EffectiveStartDate = DateTime.Today,
                        EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                        AuditUser = "sys_admin",
                        IsDeleted = false
                    }
                );
            modelBuilder.Entity<Organisation>()
                .OwnsOne(m => m.Address)
                .HasData(new
                {
                    Country = "Australia",
                    PostCode = "3030",
                    State = "VIC",
                    StreetName = "Main Street",
                    StreetNo = "1",
                    Suburb = "Melbourne",
                    OrganisationId = 1
                });

            modelBuilder.Entity<OrganisationUser>().HasData(
                   new OrganisationUser
                   {
                       Id = 1,
                       FirstName = "David",
                       LastName = "Warner",
                       Email = "dwarner@cricnsw.com.au",
                       Password = "$2a$11$0yNqYtIew9pkuD/qpufX0.48klW6qfBZ3oWIsPdnrqjItvPziWyq.",
                       OrganisationId = 1,
                       //Guid = Guid.NewGuid(),
                       AuditUser = "sysadmin",
                       EffectiveStartDate = DateTime.Today,
                       EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                       IsDeleted = false
                   }
               );

            //modelBuilder.Entity<Employee>().HasData(
            //       new Employee
            //       {
            //           Id = 1,
            //           Guid = Guid.NewGuid(),
            //           FirstName = "Lucy",
            //           LastName = "Cox",
            //           Pin = 5874,
            //           OrganisationId = 1,
            //           AuditUser = "sys_admin",
            //           EffectiveStartDate = DateTime.Today,
            //           EffectiveEndDate = new DateTime(2021, 05, 30),
            //           IsDeleted = false
            //       }
            //   );
        }
    }
}