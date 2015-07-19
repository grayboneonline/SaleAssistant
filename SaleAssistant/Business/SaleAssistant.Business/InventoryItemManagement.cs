using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IInventoryItemManagement : IEntityManagement<InventoryItem>
    {
    }

    public class InventoryItemManagement : EntityManagement<Data.Entities.InventoryItem, InventoryItem, IInventoryItemDA>, IInventoryItemManagement
    {
        public InventoryItemManagement(IInventoryItemDA da)
            : base(da)
        {
        }
    }
}
