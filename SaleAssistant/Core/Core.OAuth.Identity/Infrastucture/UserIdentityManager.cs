using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Core.OAuth.Identity.Infrastucture
{
    public class UserIdentityManager : UserManager<UserIdentity>
    {
        public UserIdentityManager(IUserStore<UserIdentity> store) : base(store)
        {
        }

        public static UserIdentityManager Create(IdentityFactoryOptions<UserIdentityManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<UserIdentityDbContext>();
            var appUserManager = new UserIdentityManager(new UserStore<UserIdentity>(appDbContext));
            appUserManager.UserValidator = new UserValidator<UserIdentity>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true,
            };
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return appUserManager;
        }
    }
}