using System.Net.Http;
using System.Web.Http;
using Core.OAuth.Identity.Infrastucture;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SaleAssistant.WebApi.Models;

namespace SaleAssistant.WebApi.Controllers
{
    public class BaseAccApiController : ApiController
    {
        private ModelFactory modelFactory;
        private readonly UserIdentityManager appUserManager = null;

        protected UserIdentityManager AppUserManager
        {
            get
            {
                return appUserManager ?? Request.GetOwinContext().GetUserManager<UserIdentityManager>();
            }
        }

        protected ModelFactory ModelFactory
        {
            get { return modelFactory ?? (modelFactory = new ModelFactory(Request, AppUserManager)); }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
