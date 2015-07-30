using System;

namespace SaleAssistant.Data.Entities
{
    public class InventoryItem : Entity
    {
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
    }
}