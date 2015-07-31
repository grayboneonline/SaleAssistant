using System;
using System.Collections.Generic;
using System.Net;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IInventoryManagement : IEntityManagement<Inventory>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
    }

    public class InventoryManagement : EntityManagement<Data.Entities.Inventory, Inventory, IInventoryDA>, IInventoryManagement
    {
        public InventoryManagement(IInventoryDA da)
            : base(da)
        {
        }

        public IList<ServiceError> SetStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Inventory inventory = DA.GetById(id);

            if (inventory == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                inventory.Status = (Data.Entities.Status) status;
                DA.Update(inventory);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> SetTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Inventory inventory = DA.GetById(id);

            if (inventory == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                inventory.IsTrash = isTrash;
                DA.Update(inventory);
                DA.Save();
            }
            return errors;
        }
    }
}
