using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/units")]
    public class UnitsController : BaseApiController
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

        [Route("visible", Name = "GetAllVisibleUnit")]
        public IHttpActionResult GetAllVisible()
        {
            return Ok(unitManagement.GetAll(true));
        }

        [Route("{id:int}", Name = "GetUnitById")]
        public IHttpActionResult Get(int id)
        {
            Unit model = unitManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:int}/updatestatus/{status:int}", Name = "UpdateUnitStatus")]
        public IHttpActionResult PutUpdateStatus(int id, Status status)
        {
            IList<ServiceError> errors = unitManagement.SetStatus(id, status);
            return HandleErrors(errors);
        }

        [Route("{id:int}/updatedeletedstatus/{isTrash:bool}", Name = "UpdateUnitTrashStatus")]
        public IHttpActionResult Putupdatedeletedstatus(int id, bool isTrash)
        {
            IList<ServiceError> errors = unitManagement.SetDeletedStatus(id, isTrash);
            return HandleErrors(errors);
        }

        [Route("{id:int}", Name = "UpdateUnit")]
        public IHttpActionResult PutUpdate(int id, Unit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            IList<ServiceError> errors = unitManagement.Update(item);
            return HandleErrors(errors);
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