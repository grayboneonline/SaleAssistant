using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SaleAssistant.WebApi.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [RoutePrefix("api/accounts")]
    [Authorize]
    public class AccountsController : BaseAccApiController
    {
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(AppUserManager.Users.ToList().Select(u => ModelFactory.Create(u)));
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            var user = await AppUserManager.FindByIdAsync(id);

            if (user != null)
            {
                return Ok(ModelFactory.Create(user));
            }

            return NotFound();
        }

        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(ModelFactory.Create(user));
            }

            return NotFound();
        }

        //[Route("create")]
        //[AllowAnonymous]
        //public async Task<IHttpActionResult> CreateUser(AccountBindingModels.CreateUserBindingModel createUserModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new UserIdentity
        //    {
        //        UserName = createUserModel.Username,
        //        Email = createUserModel.Email,
        //        FirstName = createUserModel.FirstName,
        //        LastName = createUserModel.LastName,
        //    };

        //    IdentityResult addUserResult = await AppUserManager.CreateAsync(user, createUserModel.Password);

        //    if (!addUserResult.Succeeded)
        //    {
        //        return GetErrorResult(addUserResult);
        //    }

        //    Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

        //    return Created(locationHeader, ModelFactory.Create(user));
        //}

        [Route("changepassword")]
        public async Task<IHttpActionResult> ChangePassword(AccountBindingModels.ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        //[Route("user/{id:guid}")]
        //public async Task<IHttpActionResult> DeleteUser(string id)
        //{

        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)

        //    var appUser = await AppUserManager.FindByIdAsync(id);

        //    if (appUser != null)
        //    {
        //        IdentityResult result = await AppUserManager.DeleteAsync(appUser);

        //        if (!result.Succeeded)
        //        {
        //            return GetErrorResult(result);
        //        }

        //        return Ok();

        //    }

        //    return NotFound();
        //}
    }
}
