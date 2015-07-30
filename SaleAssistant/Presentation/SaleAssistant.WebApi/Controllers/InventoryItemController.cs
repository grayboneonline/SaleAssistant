using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventoryitems")]
    public class InventoryItemController : ApiController
    {
        private readonly IInventoryItemManagement inventoryItemManagement;

        public InventoryItemController(IInventoryItemManagement inventoryItemManagement)
        {
            this.inventoryItemManagement = inventoryItemManagement;
        }

        [Route("", Name = "GetAllInventoryItem")]
        public IHttpActionResult GetAll()
        {
            return Ok(inventoryItemManagement.GetAll());
        }

        [Route("{id:guid}", Name = "GetInventoryItemById")]
        public IHttpActionResult Get(Guid id)
        {
            InventoryItem model = inventoryItemManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}", Name = "UpdateInventoryItem")]
        public IHttpActionResult PutUpdate(Guid id, InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            inventoryItemManagement.Update(item);
            return Ok();
        }

        [Route("", Name = "AddInventoryItem")]
        public IHttpActionResult PostAdd(InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            inventoryItemManagement.Insert(item);
            return Ok();
        }
    }
}