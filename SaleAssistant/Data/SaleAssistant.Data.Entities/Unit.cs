namespace SaleAssistant.Data.Entities
{
    public class Unit : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool IsTrash { get; set; }

        public override bool IsVisible
        {
            get { return !IsTrash && Status == Status.Active; }
        }
    }
}