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
        [Route("{id:guid}", Name = "GetUnitById")]
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

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateItemStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            unitManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:int}", Name = "UpdateItemTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, int isTrash)
        {
            unitManagement.SetTrashStatus(id, isTrash > 0);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateItem")]
        public IHttpActionResult PutUpdateUnit(Guid id, Unit unit)
        {
            //unitManagement.SetStatus(id, status);
            return Ok();
        }
    }
}