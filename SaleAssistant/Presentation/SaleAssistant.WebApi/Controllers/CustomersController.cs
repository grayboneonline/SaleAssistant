using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
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

        [Route("{id:guid}", Name = "GetCustomerById")]
        public IHttpActionResult Get(Guid id)
        {
            Customer model = customerManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateCustomerStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            customerManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateCustomerTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            customerManagement.SetTrashStatus(id, isTrash);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateCustomer")]
        public IHttpActionResult PutUpdate(Guid id, Customer item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            customerManagement.Update(item);
            return Ok();
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