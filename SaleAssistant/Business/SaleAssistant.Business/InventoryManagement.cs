using System;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IInventoryManagement : IEntityManagement<Inventory>
    {
        void SetStatus(Guid id, Status status);
        void SetTrashStatus(Guid id, bool isTrash);
    }

    public class InventoryManagement : EntityManagement<Data.Entities.Inventory, Inventory, IInventoryDA>, IInventoryManagement
    {
        public InventoryManagement(IInventoryDA da)
            : base(da)
        {
        }

        public void SetStatus(Guid id, Status status)
        {
            Data.Entities.Inventory inventory = DA.GetById(id);
            inventory.Status = (Data.Entities.Status)status;
            DA.Update(inventory);
            DA.Save();
        }

        public void SetTrashStatus(Guid id, bool isTrash)
        {
            Data.Entities.Inventory inventory = DA.GetById(id);
            inventory.IsTrash = isTrash;
            DA.Update(inventory);
            DA.Save();
        }
    }
}
