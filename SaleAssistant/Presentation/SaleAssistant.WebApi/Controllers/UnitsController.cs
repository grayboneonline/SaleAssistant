using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/units")]
    public class UnitsController : ApiController
    {
        private readonly IUnitManagement unitManagement;

        public UnitsController(IUnitManagement unitManagement)
        {
            this.unitManagement = unitManagement;
        }

        [ResponseType(typeof(Unit))]
        [Route("~/api/unit/{id:guid}", Name = "GetUnitById")]
        public IHttpActionResult GetUnit(Guid id)
        {
            Unit unit = unitManagement.GetById(id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [Route("", Name = "GetUnits")]
        public IHttpActionResult GetUnits()
        {
            IList<Unit> units = unitManagement.GetAll();
            return Ok(units);
        }
    }
}