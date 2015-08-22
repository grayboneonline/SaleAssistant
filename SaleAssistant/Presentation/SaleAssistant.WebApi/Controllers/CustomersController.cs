using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/customers")]
    public class CustomersController : BaseApiController
    {
        private readonly ICustomerManagement customerManagement;

        public CustomersController(ICustomerManagement customerManagement)
        {
            this.customerManagement = customerManagement;
        }

        [Route("", Name = "GetAllCustomer")]
        public IHttpActionResult GetAll()
        {
            return Ok(customerManagement.GetAll());
        }

        [Route("visible", Name = "GetAllVisibleCustomer")]
        public IHttpActionResult GetAllVisible()
        {
            return Ok(customerManagement.GetAll(true));
        }

        [Route("{id:int}", Name = "GetCustomerById")]
        public IHttpActionResult Get(int id)
        {
            Customer model = customerManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:int}/updatestatus/{status:int}", Name = "UpdateCustomerStatus")]
        public IHttpActionResult PutUpdateStatus(int id, Status status)
        {
            IList<ServiceError> errors = customerManagement.SetStatus(id, status);
            return HandleErrors(errors);
        }

        [Route("{id:int}/updatedeletedstatus/{isTrash:bool}", Name = "UpdateCustomerTrashStatus")]
        public IHttpActionResult Putupdatedeletedstatus(int id, bool isTrash)
        {
            IList<ServiceError> errors = customerManagement.SetDeletedStatus(id, isTrash);
            return HandleErrors(errors);
        }

        [Route("{id:int}", Name = "UpdateCustomer")]
        public IHttpActionResult PutUpdate(int id, Customer item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            IList<ServiceError> errors = customerManagement.Update(item);
            return HandleErrors(errors);
        }

        [Route("", Name = "AddCustomer")]
        public IHttpActionResult PostAdd(Customer item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            customerManagement.Insert(item);
            return Ok();
        }
    }
}