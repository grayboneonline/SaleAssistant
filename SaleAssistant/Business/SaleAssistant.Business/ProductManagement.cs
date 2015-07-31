using System;
using System.Collections.Generic;
using System.Net;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IProductManagement : IEntityManagement<Product>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
    }

    public class ProductManagement : EntityManagement<Data.Entities.Product, Product, IProductDA>, IProductManagement
    {
        public ProductManagement(IProductDA da)
            : base(da)
        {
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
                product.IsTrash = isTrash;
                DA.Update(product);
                DA.Save();
            }
            return errors;
        }
    }
}
