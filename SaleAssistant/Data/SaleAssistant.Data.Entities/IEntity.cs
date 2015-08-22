namespace SaleAssistant.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; } 
    }

    public interface IEntityWithStatus
    {
        Status Status { get; set; }
    }

    public interface IEntityWithIsDeleted
    {
        bool IsDeleted { get; set; }
    }
}