using System;
using System.Web.Http;
using System.Web.Http.Description;
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

        //// GET: api/Products
        //public IQueryable<Product> GetProducts()
        //{
        //    return db.Products;
        //}

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        [Route("product/{id:guid}", Name = "GetProductById")]
        public IHttpActionResult GetProduct(Guid id)
        {
            Product product = productManagement.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //// PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutProduct(Guid id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Products
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProductExists(product.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        //}

        //// DELETE: api/Products/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> DeleteProduct(Guid id)
        //{
        //    Product product = await db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    await db.SaveChangesAsync();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(Guid id)
        //{
        //    return db.Products.Count(e => e.Id == id) > 0;
        //}
    }
}