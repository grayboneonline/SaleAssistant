using System;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductManagement : IEntityManagement<Product>
    {
        void SetStatus(Guid id, Status status);
        void SetTrashStatus(Guid id, bool isTrash);
    }

    public class ProductManagement : EntityManagement<Data.Entities.Product, Product, IProductDA>, IProductManagement
    {
        public ProductManagement(IProductDA da)
            : base(da)
        {
        }

        public void SetStatus(Guid id, Status status)
        {
            Data.Entities.Product unit = DA.GetById(id);
            unit.Status = (Data.Entities.Status)status;
            DA.Update(unit);
            DA.Save();
        }

        public void SetTrashStatus(Guid id, bool isTrash)
        {
            Data.Entities.Product unit = DA.GetById(id);
            unit.IsTrash = isTrash;
            DA.Update(unit);
            DA.Save();
        }
    }
}
