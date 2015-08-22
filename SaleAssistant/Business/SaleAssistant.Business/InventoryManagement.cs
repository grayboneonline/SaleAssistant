using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IInventoryManagement : IEntityManagement<Inventory>, IEntityWithStatusManagement, IEntityWithIsDeletedManagement
    {
    }

    public class InventoryManagement : EntityManagement<Data.Entities.Inventory, Inventory, IInventoryDA>, IInventoryManagement
    {
        public InventoryManagement(IInventoryDA da)
            : base(da)
        {
        }
    }
}
