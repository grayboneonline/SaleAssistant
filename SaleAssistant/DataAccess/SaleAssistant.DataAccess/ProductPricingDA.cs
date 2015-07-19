using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IProductPricingDA : IEntityDA<ProductPricing>
    {
        
    }

    public class ProductPricingDA : EntityDA<ProductPricing>, IProductPricingDA
    {
        public ProductPricingDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
