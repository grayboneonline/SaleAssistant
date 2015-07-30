using System;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventories")]
    public class InventoriesController : ApiController
    {
        private readonly IInventoryManagement inventoryManagement;

        public InventoriesController(IInventoryManagement inventoryManagement)
        {
            this.inventoryManagement = inventoryManagement;
        }

        [Route("", Name = "GetAllInventory")]
        public IHttpActionResult GetAll()
        {
            return Ok(inventoryManagement.GetAll());
        }

        [Route("{id:guid}", Name = "GetInventoryById")]
        public IHttpActionResult Get(Guid id)
        {
            Inventory model = inventoryManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("{id:guid}/updatestatus/{status:int}", Name = "UpdateInventoryStatus")]
        public IHttpActionResult PutUpdateStatus(Guid id, Status status)
        {
            inventoryManagement.SetStatus(id, status);
            return Ok();
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateInventoryTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            inventoryManagement.SetTrashStatus(id, isTrash);
            return Ok();
        }

        [Route("{id:guid}", Name = "UpdateInventory")]
        public IHttpActionResult PutUpdate(Guid id, Inventory item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            inventoryManagement.Update(item);
            return Ok();
        }

        [Route("", Name = "AddInventory")]
        public IHttpActionResult PostAdd(Inventory item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            inventoryManagement.Insert(item);
            return Ok();
        }
    }
}