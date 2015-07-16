using System;

namespace SaleAssistant.DataAccess.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

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