using System;

namespace SaleAssistant.Data.Entities
{
    public class ProductPricing : Entity
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public PricingType Type { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Product Product { get; set; }

        public override bool IsRelationVisible
        {
            get { return Product.IsVisible; }
        }
    }

    public enum PricingType
    {
        Cost = 0,
        Sale = 1
    }
}