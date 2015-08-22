using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface ICustomerManagement : IEntityManagement<Customer>, IEntityWithStatusManagement, IEntityWithIsDeletedManagement
    {
    }

    public class CustomerManagement : EntityManagement<Data.Entities.Customer, Customer, ICustomerDA>, ICustomerManagement
    {
        public CustomerManagement(ICustomerDA da)
            : base(da)
        {
        }
    }
}
