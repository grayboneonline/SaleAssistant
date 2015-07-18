using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using SaleAssistant.WebApi.Infrastructure;

namespace SaleAssistant.WebApi.Models
{
    public class ModelFactory
    {
        private readonly UrlHelper urlHelper;
        private readonly ApplicationUserManager appUserManager;

        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            urlHelper = new UrlHelper(request);
            this.appUserManager = appUserManager;
        }

        public UserReturnModel Create(ApplicationUser appUser)
        {
            return new UserReturnModel
            {
                Url = urlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Roles = appUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = appUserManager.GetClaimsAsync(appUser.Id).Result
            };
        }
    }
    
    public class UserReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
    }
}