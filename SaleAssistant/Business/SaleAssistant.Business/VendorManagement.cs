using System;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IVendorManagement : IEntityManagement<Vendor>
    {
        void SetStatus(Guid id, Status status);
        void SetTrashStatus(Guid id, bool isTrash);
    }

    public class VendorManagement : EntityManagement<Data.Entities.Vendor, Vendor, IVendorDA>, IVendorManagement
    {
        public VendorManagement(IVendorDA da)
            : base(da)
        {
        }

        public void SetStatus(Guid id, Status status)
        {
            Data.Entities.Vendor vendor = DA.GetById(id);
            vendor.Status = (Data.Entities.Status)status;
            DA.Update(vendor);
            DA.Save();
        }

        public void SetTrashStatus(Guid id, bool isTrash)
        {
            Data.Entities.Vendor vendor = DA.GetById(id);
            vendor.IsTrash = isTrash;
            DA.Update(vendor);
            DA.Save();
        }
    }
}
