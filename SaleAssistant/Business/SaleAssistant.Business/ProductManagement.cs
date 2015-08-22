using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SaleAssistant.AutoMapper;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductManagement : IEntityManagement<Product>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
        IList<Product> GetProductNotExistsInInventory(Guid inventoryId);
    }

    public class ProductManagement : EntityManagement<Data.Entities.Product, Product, IProductDA>, IProductManagement
    {
        private readonly IInventoryItemDA inventoryItemDA;
        public ProductManagement(IProductDA da, IInventoryItemDA inventoryItemDA)
            : base(da)
        {
            this.inventoryItemDA = inventoryItemDA;
        }

        public IList<ServiceError> SetStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Product product = DA.GetById(id);

            if (product == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                product.Status = (Data.Entities.Status) status;
                DA.Update(product);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> SetTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Product product = DA.GetById(id);

            if (product == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                //product.IsTrash = isTrash;
                DA.Update(product);
                DA.Save();
            }
            return errors;
        }

        public IList<Product> GetProductNotExistsInInventory(Guid inventoryId)
        {
            return new Product[0];
            //IList<Guid> productAddedIds = inventoryItemDA.GetByInventoryId(inventoryId).Select(x => x.ProductId).ToList();
            //return DA.GetAll().Where(x => !productAddedIds.Contains(x.Id)).MapTo<IList<Product>>();
        }
    }
}
