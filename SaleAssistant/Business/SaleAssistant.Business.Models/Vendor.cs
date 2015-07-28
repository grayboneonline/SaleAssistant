using System;

namespace SaleAssistant.Business.Models
{
    public class Vendor : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}