using System;

namespace SaleAssistant.Business.Models
{
    public class ProductPricing : IBusinessModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public PricingType Type { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum PricingType
    {
        Cost = 0,
        Sale = 1
    }
}