using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/productpricings")]
    public class ProductPricingsController : ApiController
    {
        private readonly IProductPricingManagement productPricingManagement;

        public ProductPricingsController(IProductPricingManagement productPricingManagement)
        {
            this.productPricingManagement = productPricingManagement;
        }

        [Route("", Name = "GetAllProductPricing")]
        public IHttpActionResult GetAll()
        {
            return Ok(productPricingManagement.GetAll());
        }

        [Route("{id:int}", Name = "GetProductPricingById")]
        public IHttpActionResult Get(int id)
        {
            ProductPricing model = productPricingManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:int}", Name = "UpdateProductPricing")]
        public IHttpActionResult PutUpdate(int id, ProductPricing item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            productPricingManagement.Update(item);
            return Ok();
        }

        [Route("", Name = "AddProductPricing")]
        public IHttpActionResult PostAdd(ProductPricing item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            productPricingManagement.Insert(item);
            return Ok();
        }
    }
}