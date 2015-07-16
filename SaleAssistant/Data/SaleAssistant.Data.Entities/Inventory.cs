namespace SaleAssistant.Data.Entities
{
    public class Inventory : Entity
    {
        public string Name { get; set; }

        public InventoryStatus Status { get; set; }
    }

    public enum InventoryStatus
    {
        InActive = 0,
        Active = 1,
    }
}