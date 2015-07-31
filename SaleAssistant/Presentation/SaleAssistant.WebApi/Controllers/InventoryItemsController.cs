using System;
using System.Collections.Generic;
using System.Web.Http;
using SaleAssistant.Business;
using SaleAssistant.Business.Models;

namespace SaleAssistant.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventoryitems")]
    public class InventoryItemsController : BaseApiController
    {
        private readonly IInventoryItemManagement inventoryItemManagement;

        public InventoryItemsController(IInventoryItemManagement inventoryItemManagement)
        {
            this.inventoryItemManagement = inventoryItemManagement;
        }

        [Route("", Name = "GetAllInventoryItem")]
        public IHttpActionResult GetAll()
        {
            return Ok(inventoryItemManagement.GetAll(relationVisible: true));
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

            IList<ServiceError> errors = inventoryItemManagement.Update(item);
            return HandleErrors(errors);
        }

        [Route("", Name = "AddInventoryItem")]
        public IHttpActionResult PostAdd(InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            item.InventoryId = new Guid("3A8ED735-F959-4D67-9E57-F781B746E0E9");

            inventoryItemManagement.Insert(item);
            return Ok();
        }

        [Route("{id:guid}", Name = "DeleteInventoryItem")]
        public IHttpActionResult Delete(Guid id)
        {
            IList<ServiceError> errors = inventoryItemManagement.Delete(id);
            return HandleErrors(errors);
        }
    }
}