using System.Collections.Generic;
using System.Linq;
using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IInventoryItemDA : IEntityDA<InventoryItem>
    {
        IList<InventoryItem> GetByInventoryId(int inventoryId);
    }

    public class InventoryItemDA : EntityDA<InventoryItem>, IInventoryItemDA
    {
        public InventoryItemDA(SaleAssistantDbContext context) : base (context)
        {
        }

        public IList<InventoryItem> GetByInventoryId(int inventoryId)
        {
            return DbSet.Where(x => x.InventoryId == inventoryId).ToList();
        }
    }
}
