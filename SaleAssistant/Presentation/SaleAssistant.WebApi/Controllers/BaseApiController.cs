using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IHttpActionResult HandleErrors(IList<ServiceError> errors)
        {
            if (!errors.Any())
                return Ok();

            switch (errors[0].StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound();

                default:
                    return InternalServerError();
            }
        }
    }
}
