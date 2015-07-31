using System;
using System.Collections.Generic;
using System.Net;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IVendorManagement : IEntityManagement<Vendor>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
    }

    public class VendorManagement : EntityManagement<Data.Entities.Vendor, Vendor, IVendorDA>, IVendorManagement
    {
        public VendorManagement(IVendorDA da)
            : base(da)
        {
        }

        public IList<ServiceError> SetStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Vendor vendor = DA.GetById(id);

            if (vendor == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                vendor.Status = (Data.Entities.Status) status;
                DA.Update(vendor);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> SetTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Vendor vendor = DA.GetById(id);

            if (vendor == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                vendor.IsTrash = isTrash;
                DA.Update(vendor);
                DA.Save();
            }
            return errors;
        }
    }
}
