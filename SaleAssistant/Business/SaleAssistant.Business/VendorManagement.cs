using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IVendorManagement : IEntityManagement<Vendor>, IEntityWithStatusManagement, IEntityWithIsDeletedManagement
    {
    }

    public class VendorManagement : EntityManagement<Data.Entities.Vendor, Vendor, IVendorDA>, IVendorManagement
    {
        public VendorManagement(IVendorDA da)
            : base(da)
        {
        }
    }
}
