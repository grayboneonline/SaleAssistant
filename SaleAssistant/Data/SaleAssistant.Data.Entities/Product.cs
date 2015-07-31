using System;

namespace SaleAssistant.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }
        public Guid UnitId { get; set; }
        public bool IsTrash{ get; set; }

        public virtual Unit Unit { get; set; }

        public override bool IsVisible
        {
            get { return !IsTrash && Status == Status.Active; }
        }

        public override bool IsRelationVisible
        {
            get { return Unit.IsVisible; }
        }
    }
}