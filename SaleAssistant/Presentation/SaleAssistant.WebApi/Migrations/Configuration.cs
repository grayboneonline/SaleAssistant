using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SaleAssistant.WebApi.Infrastructure;
using System.Data.Entity.Migrations;

namespace SaleAssistant.WebApi.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "administrator",
                Email = "grayboneonline@gmail.com",
                EmailConfirmed = true,
                FirstName = "Lam",
                LastName = "Vu",
            };

            manager.Create(user, "graybone@123");
        }
    }
}
