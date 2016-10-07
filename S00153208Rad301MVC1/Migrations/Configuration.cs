namespace S00153208Rad301MVC1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00153208Rad301MVC1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(S00153208Rad301MVC1.Models.ApplicationDbContext context)
        {

            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context)
            );

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "ClubAdmin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "member" }
                );

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
            new ApplicationUser
            {
                UserName = "Admin",
                Email = "patrick.pa3ck@gmail.com",
                EmailConfirmed = true,
                JoinDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Joe",
                SecondName = "Doe",
                PasswordHash = ps.HashPassword("Patrick1.")
            });

            context.Users.AddOrUpdate(u => u.UserName,
            new ApplicationUser
            {
                UserName = "itsadmin",
                Email = "s00153208@mail.itsligo.ie",
                EmailConfirmed = true,
                JoinDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Some",
                SecondName = "Boooody",
                PasswordHash = ps.HashPassword("Itsadmin1.")

            });



            context.SaveChanges();

            ApplicationUser admin = manager.FindByEmail("patrick.pa3ck@gmail.com");

            if(admin != null)
            {
                //manager.AddToRoles(admin.Id, new string[] { "Admin", "member", "ClubAdmin" });
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
