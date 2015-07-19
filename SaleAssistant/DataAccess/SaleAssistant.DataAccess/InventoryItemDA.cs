using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IInventoryItemDA : IEntityDA<InventoryItem>
    {
        
    }

    public class InventoryItemDA : EntityDA<InventoryItem>, IInventoryItemDA
    {
        public InventoryItemDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
