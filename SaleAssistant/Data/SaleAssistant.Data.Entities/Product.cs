namespace SaleAssistant.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        
        public string Code { get; set; }

        public ProductStatus Status { get; set; }
    }

    public enum ProductStatus
    {
        InActive = 0,
        Active = 1,
    }
}