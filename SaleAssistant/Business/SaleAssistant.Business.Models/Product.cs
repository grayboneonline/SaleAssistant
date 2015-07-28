using System;

namespace SaleAssistant.Business.Models
{
    public class Product : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }
        public Guid UnitId { get; set; }
        public bool IsTrash { get; set; }

        public Unit Unit { get; set; }
    }
}