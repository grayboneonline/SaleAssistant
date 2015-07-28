using System;
using System.Web.Http;
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

        [Route("", Name = "GetAllUnit")]
        public IHttpActionResult GetAll()
        {
            return Ok(unitManagement.GetAll());
        }

        [Route("{id:guid}", Name = "GetUnitById")]
        public IHttpActionResult Get(Guid id)
        {
            Unit model = unitManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateUnitStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            unitManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateUnitTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            unitManagement.SetTrashStatus(id, isTrash);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateUnit")]
        public IHttpActionResult PutUpdate(Guid id, Unit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            unitManagement.Update(item);
            return Ok();
        }

        [Route("", Name = "AddUnit")]
        public IHttpActionResult PostAdd(Unit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            unitManagement.Insert(item);
            return Ok();
        }
    }
}