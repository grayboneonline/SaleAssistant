using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductPricingManagement : IEntityManagement<ProductPricing>
    {
    }

    public class ProductPricingManagement : EntityManagement<Data.Entities.ProductPricing, ProductPricing, IProductPricingDA>, IProductPricingManagement
    {
        public ProductPricingManagement(IProductPricingDA da)
            : base(da)
        {
        }
    }
}
