using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IUnitDA : IEntityDA<Unit>
    {
        
    }

    public class UnitDA : EntityDA<Unit>, IUnitDA
    {
        public UnitDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
