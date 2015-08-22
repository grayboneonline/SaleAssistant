using System;
using System.Collections.Generic;
using System.Net;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface ICustomerManagement : IEntityManagement<Customer>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
    }

    public class CustomerManagement : EntityManagement<Data.Entities.Customer, Customer, ICustomerDA>, ICustomerManagement
    {
        public CustomerManagement(ICustomerDA da)
            : base(da)
        {
        }

        public IList<ServiceError> SetStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Customer customer = DA.GetById(id);

            if (customer == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                customer.Status = (Data.Entities.Status) status;
                DA.Update(customer);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> SetTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Customer customer = DA.GetById(id);

            if (customer == null)
                errors.Add(new ServiceError {FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound});
            else
            {
                //customer.IsTrash = isTrash;
                DA.Update(customer);
                DA.Save();
            }
            return errors;
        }
    }
}
