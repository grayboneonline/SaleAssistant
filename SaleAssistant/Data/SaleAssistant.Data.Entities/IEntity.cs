using System;

namespace SaleAssistant.Data.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }

        bool IsVisible { get; }

        bool IsRelationVisible { get; }
    }

    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public virtual bool IsVisible
        {
            get { return true; }
        }

        public virtual bool IsRelationVisible
        {
            get { return true; }
        }
    }
}
