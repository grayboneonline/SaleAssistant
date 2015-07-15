using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SaleAssistant.Models;

namespace SaleAssistant.Controllers
{
    public class InventoryDetailsController : ApiController
    {
        private SaleAssistantContext db = new SaleAssistantContext();

        // GET: api/InventoryDetails
        public IQueryable<InventoryDetail> GetInventoryDetails()
        {
            return db.InventoryDetails;
        }

        // GET: api/InventoryDetails/5
        [ResponseType(typeof(InventoryDetail))]
        public async Task<IHttpActionResult> GetInventoryDetail(Guid id)
        {
            InventoryDetail inventoryDetail = await db.InventoryDetails.FindAsync(id);
            if (inventoryDetail == null)
            {
                return NotFound();
            }

            return Ok(inventoryDetail);
        }

        // PUT: api/InventoryDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventoryDetail(Guid id, InventoryDetail inventoryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(inventoryDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InventoryDetails
        [ResponseType(typeof(InventoryDetail))]
        public async Task<IHttpActionResult> PostInventoryDetail(InventoryDetail inventoryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryDetails.Add(inventoryDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventoryDetailExists(inventoryDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventoryDetail.Id }, inventoryDetail);
        }

        // DELETE: api/InventoryDetails/5
        [ResponseType(typeof(InventoryDetail))]
        public async Task<IHttpActionResult> DeleteInventoryDetail(Guid id)
        {
            InventoryDetail inventoryDetail = await db.InventoryDetails.FindAsync(id);
            if (inventoryDetail == null)
            {
                return NotFound();
            }

            db.InventoryDetails.Remove(inventoryDetail);
            await db.SaveChangesAsync();

            return Ok(inventoryDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryDetailExists(Guid id)
        {
            return db.InventoryDetails.Count(e => e.Id == id) > 0;
        }
    }
}