using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.OAuth.Identity.Infrastucture
{
    public class UserIdentityDbContext : IdentityDbContext<UserIdentity>
    {
        public UserIdentityDbContext() : base("UserDbConnection", false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AppClient> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}