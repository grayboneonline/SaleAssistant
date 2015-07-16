using System;

namespace SaleAssistant.DataAccess.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public InventoryStatus Status { get; set; }
    }

    public enum InventoryStatus
    {
        InActive = 0,
        Active = 1,
    }
}