using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IProductDA : IEntityDA<Product>
    {
        
    }

    public class ProductDA : EntityDA<Product>, IProductDA
    {
        public ProductDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
