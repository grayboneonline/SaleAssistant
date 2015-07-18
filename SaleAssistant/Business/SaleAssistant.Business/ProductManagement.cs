using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductManagement : IEntityManagement<Product>
    {
    }

    public class ProductManagement : EntityManagement<Data.Entities.Product, Product, IProductDA>, IProductManagement
    {
        public ProductManagement(IProductDA da)
            : base(da)
        {
        }
    }
}
