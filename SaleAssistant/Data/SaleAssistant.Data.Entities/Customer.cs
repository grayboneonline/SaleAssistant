namespace SaleAssistant.Data.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}