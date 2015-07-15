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
    public class InventoriesController : ApiController
    {
        private SaleAssistantContext db = new SaleAssistantContext();

        // GET: api/Inventories
        public IQueryable<Inventory> GetInventories()
        {
            return db.Inventories;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(Guid id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // PUT: api/Inventories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventory(Guid id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.Id)
            {
                return BadRequest();
            }

            db.Entry(inventory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventories.Add(inventory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventoryExists(inventory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> DeleteInventory(Guid id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            db.Inventories.Remove(inventory);
            await db.SaveChangesAsync();

            return Ok(inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryExists(Guid id)
        {
            return db.Inventories.Count(e => e.Id == id) > 0;
        }
    }
}