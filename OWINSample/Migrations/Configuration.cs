namespace OWINSample.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OWINSample.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OWINSample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OWINSample.Models.ApplicationDbContext";
        }

        protected override void Seed(OWINSample.Models.ApplicationDbContext context)
        {
            const string DEFAULT_USER_MAIL = "defaultmail@gmail.com";
            const string DEFAULT_ROLE = "admin";
            const string DEFAULT_PASSWORD = "password";
            
            // 1st way.
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u =>
            //        new ApplicationUser {
            //            Email=DEFAULT_USER_MAIL,
            //            PasswordHash = hasher.HashPassword(DEFAULT_PASSWORD)
            //        }
            //    );

            //2nd. way
            if (context.Users.Any(u => u.UserName == DEFAULT_USER_MAIL))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = DEFAULT_USER_MAIL };
                
                userManager.Create(user, DEFAULT_PASSWORD);
                roleManager.Create(new IdentityRole { Name = DEFAULT_ROLE });
                userManager.AddToRole(user.Id, DEFAULT_ROLE);
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
