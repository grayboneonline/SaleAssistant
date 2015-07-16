using System;

namespace SaleAssistant.Data.Entities
{
    public class InventoryDetail : Entity
    {
        public Guid InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}