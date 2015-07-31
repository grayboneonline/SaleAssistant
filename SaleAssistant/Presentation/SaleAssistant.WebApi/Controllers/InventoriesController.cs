using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventories")]
    public class InventoriesController : BaseApiController
    {
        private readonly IInventoryManagement inventoryManagement;

        public InventoriesController(IInventoryManagement inventoryManagement)
        {
            this.inventoryManagement = inventoryManagement;
        }

        [Route("", Name = "GetAllInventories")]
        public IHttpActionResult GetAll()
        {
            return Ok(inventoryManagement.GetAll());
        }

        [Route("visible", Name = "GetAllVisibleInventories")]
        public IHttpActionResult GetAllVisible()
        {
            return Ok(inventoryManagement.GetAll(true));
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
            IList<ServiceError> errors = inventoryManagement.SetStatus(id, status);
            return HandleErrors(errors);
        }

        [Route("{id:guid}/updatetrashstatus/{isTrash:bool}", Name = "UpdateInventoryTrashStatus")]
        public IHttpActionResult PutUpdateTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = inventoryManagement.SetTrashStatus(id, isTrash);
            return HandleErrors(errors);
        }

        [Route("{id:guid}", Name = "UpdateInventory")]
        public IHttpActionResult PutUpdate(Guid id, Inventory item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != item.Id)
                return BadRequest();

            IList<ServiceError> errors = inventoryManagement.Update(item);
            return HandleErrors(errors);
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