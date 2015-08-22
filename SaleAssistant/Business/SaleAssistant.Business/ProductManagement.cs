using System.Linq;
using System.Collections.Generic;
using SaleAssistant.AutoMapper;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductManagement : IEntityManagement<Product>, IEntityWithStatusManagement, IEntityWithIsDeletedManagement
    {
        IList<Product> GetProductNotExistsInInventory(int inventoryId);
    }

    public class ProductManagement : EntityManagement<Data.Entities.Product, Product, IProductDA>, IProductManagement
    {
        private readonly IInventoryItemDA inventoryItemDA;
        public ProductManagement(IProductDA da, IInventoryItemDA inventoryItemDA)
            : base(da)
        {
            this.inventoryItemDA = inventoryItemDA;
        }

        public IList<Product> GetProductNotExistsInInventory(int inventoryId)
        {
            IList<int> productAddedIds = inventoryItemDA.GetByInventoryId(inventoryId).Select(x => x.ProductId).ToList();
            return DA.GetAll().Where(x => !productAddedIds.Contains(x.Id)).MapTo<IList<Product>>();
        }
    }
}
