using Microsoft.AspNet.Identity;

namespace Core.OAuth.Identity.Infrastucture
{
    public class UserIdentityManager : UserManager<UserIdentity>
    {
        public UserIdentityManager(IUserStore<UserIdentity> store) : base(store)
        {
            UserValidator = new UserValidator<UserIdentity>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true,
            };
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
        }
    }
}