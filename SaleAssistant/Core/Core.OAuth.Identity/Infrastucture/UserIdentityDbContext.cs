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

        public static UserIdentityDbContext Create()
        {
            return new UserIdentityDbContext();
        }
    }
}