using Core.OAuth.Identity.Infrastucture;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace Core.OAuth.Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UserIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserIdentityDbContext context)
        {
            var manager = new UserManager<UserIdentity>(new UserStore<UserIdentity>(new UserIdentityDbContext()));

            var user = new UserIdentity
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
