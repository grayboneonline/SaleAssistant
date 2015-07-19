using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IInventoryDA : IEntityDA<Inventory>
    {
        
    }

    public class InventoryDA : EntityDA<Inventory>, IInventoryDA
    {
        public InventoryDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
