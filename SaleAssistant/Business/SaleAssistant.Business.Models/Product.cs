using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAssistant.Business.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ProductStatus Status { get; set; }
    }

    public enum ProductStatus
    {
        InActive = 0,
        Active = 1,
    }
}
