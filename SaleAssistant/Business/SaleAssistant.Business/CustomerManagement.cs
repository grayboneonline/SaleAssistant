using System;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface ICustomerManagement : IEntityManagement<Customer>
    {
        void SetStatus(Guid id, Status status);
        void SetTrashStatus(Guid id, bool isTrash);
    }

    public class CustomerManagement : EntityManagement<Data.Entities.Customer, Customer, ICustomerDA>, ICustomerManagement
    {
        public CustomerManagement(ICustomerDA da)
            : base(da)
        {
        }

        public void SetStatus(Guid id, Status status)
        {
            Data.Entities.Customer customer = DA.GetById(id);
            customer.Status = (Data.Entities.Status)status;
            DA.Update(customer);
            DA.Save();
        }

        public void SetTrashStatus(Guid id, bool isTrash)
        {
            Data.Entities.Customer customer = DA.GetById(id);
            customer.IsTrash = isTrash;
            DA.Update(customer);
            DA.Save();
        }
    }
}
