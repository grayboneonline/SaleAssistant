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
        // working with only 1 inventory first
        private static readonly int InventoryId = 1;

        private readonly IInventoryItemManagement inventoryItemManagement;
        private readonly IProductManagement productManagement;

        public InventoryItemsController(IInventoryItemManagement inventoryItemManagement,
                                        IProductManagement productManagement)
        {
            this.inventoryItemManagement = inventoryItemManagement;
            this.productManagement = productManagement;
        }

        [Route("", Name = "GetAllInventoryItem")]
        public IHttpActionResult GetAll()
        {
            return Ok(inventoryItemManagement.GetAll(relationVisible: true));
        }

        [Route("{id:int}", Name = "GetInventoryItemById")]
        public IHttpActionResult Get(int id)
        {
            InventoryItem model = inventoryItemManagement.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("remainproducts", Name = "InventoryItem_GetRemainProducts")]
        public IHttpActionResult GetRemainProducts()
        {
            return Ok(productManagement.GetProductNotExistsInInventory(InventoryId));
        }

        [Route("{id:int}", Name = "UpdateInventoryItem")]
        public IHttpActionResult PutUpdate(int id, InventoryItem item)
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

            item.InventoryId = InventoryId;

            inventoryItemManagement.Insert(item);
            return Ok();
        }

        [Route("{id:int}", Name = "DeleteInventoryItem")]
        public IHttpActionResult Delete(int id)
        {
            IList<ServiceError> errors = inventoryItemManagement.Delete(id);
            return HandleErrors(errors);
        }
    }
}