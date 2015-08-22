using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/vendors")]
    public class VendorsController : BaseApiController
    {
        private readonly IVendorManagement vendorManagement;

        public VendorsController(IVendorManagement vendorManagement)
        {
            this.vendorManagement = vendorManagement;
        }

        [Route("", Name = "GetAllVendor")]
        public IHttpActionResult GetAll()
        {
            return Ok(vendorManagement.GetAll());
        }

        [Route("visible", Name = "GetAllVisibleVendor")]
        public IHttpActionResult GetAllVisible()
        {
            return Ok(vendorManagement.GetAll(true));
        }

        [Route("{id:int}", Name = "GetVendorById")]
        public IHttpActionResult Get(int id)
        {
            Vendor model = vendorManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:int}/updatestatus/{status:int}", Name = "UpdateVendorStatus")]
        public IHttpActionResult PutUpdateStatus(int id, Status status)
        {
            IList<ServiceError> errors = vendorManagement.SetStatus(id, status);
            return HandleErrors(errors);
        }

        [Route("{id:int}/updatedeletedstatus/{isTrash:bool}", Name = "UpdateVendorTrashStatus")]
        public IHttpActionResult Putupdatedeletedstatus(int id, bool isTrash)
        {
            IList<ServiceError> errors = vendorManagement.SetDeletedStatus(id, isTrash);
            return HandleErrors(errors);
        }

        [Route("{id:int}", Name = "UpdateVendor")]
        public IHttpActionResult PutUpdate(int id, Vendor item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            IList<ServiceError> errors = vendorManagement.Update(item);
            return HandleErrors(errors);
        }

        [Route("", Name = "AddVendor")]
        public IHttpActionResult PostAdd(Vendor item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            vendorManagement.Insert(item);
            return Ok();
        }
    }
}