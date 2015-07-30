using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/vendors")]
    public class VendorsController : ApiController
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

        [Route("{id:guid}", Name = "GetVendorById")]
        public IHttpActionResult Get(Guid id)
        {
            Vendor model = vendorManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateVendorStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            vendorManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateVendorTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            vendorManagement.SetTrashStatus(id, isTrash);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateVendor")]
        public IHttpActionResult PutUpdate(Guid id, Vendor item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            vendorManagement.Update(item);
            return Ok();
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