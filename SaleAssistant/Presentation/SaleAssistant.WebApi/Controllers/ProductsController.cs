using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductManagement productManagement;

        public ProductsController(IProductManagement productManagement)
        {
            this.productManagement = productManagement;
        }

        [Route("", Name = "GetAllProduct")]
        public IHttpActionResult GetAll()
        {
            return Ok(productManagement.GetAll(relationVisible: true));
        }

        [Route("visible", Name = "GetAllVisibleProduct")]
        public IHttpActionResult GetAllVisible()
        {
            return Ok(productManagement.GetAll(true, true));
        }

        [Route("{id:guid}", Name = "GetProductById")]
        public IHttpActionResult Get(Guid id)
        {
            Product model = productManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateProductStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = productManagement.SetStatus(id, status);
            return HandleErrors(errors);
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateProductTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = productManagement.SetTrashStatus(id, isTrash);
            return HandleErrors(errors);
        }

        [Route("{id:guid}", Name = "UpdateProduct")]
        public IHttpActionResult PutUpdate(Guid id, Product item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            IList<ServiceError> errors = productManagement.Update(item);
            return HandleErrors(errors);
        }

        [Route("", Name = "AddProduct")]
        public IHttpActionResult PostAdd(Product item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            productManagement.Insert(item);
            return Ok();
        }
    }
}