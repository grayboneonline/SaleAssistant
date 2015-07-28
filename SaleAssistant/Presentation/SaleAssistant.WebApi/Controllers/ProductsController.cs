using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductManagement productManagement;

        public ProductsController(IProductManagement productManagement)
        {
            this.productManagement = productManagement;
        }

        [Route("", Name = "GetAllProduct")]
        public IHttpActionResult GetAll()
        {
            return Ok(productManagement.GetAll());
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
            productManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateProductTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            productManagement.SetTrashStatus(id, isTrash);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateProduct")]
        public IHttpActionResult PutUpdate(Guid id, Product item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            productManagement.Update(item);
            return Ok();
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