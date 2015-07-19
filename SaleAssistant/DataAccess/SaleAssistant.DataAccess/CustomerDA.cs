using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface ICustomerDA : IEntityDA<Customer>
    {
        
    }

    public class CustomerDA : EntityDA<Customer>, ICustomerDA
    {
        public CustomerDA(SaleAssistantDbContext context) : base (context)
        {
        }
    }
}
