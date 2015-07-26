namespace SaleAssistant.Data.Entities
{
    public class Unit : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool IsTrash { get; set; }
    }
}