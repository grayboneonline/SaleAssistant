using System;

namespace SaleAssistant.Business.Models
{
    public class Unit : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool IsTrash { get; set; }
    }
}