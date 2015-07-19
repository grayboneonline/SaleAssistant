using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IVendorDA : IEntityDA<Vendor>
    {
        
    }

    public class VendorDA : EntityDA<Vendor>, IVendorDA
    {
        public VendorDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
