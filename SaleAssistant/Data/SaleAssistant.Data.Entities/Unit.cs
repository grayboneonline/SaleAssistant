using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleAssistant.Data.Entities
{
    public class Unit : IEntity, IEntityWithStatus, IEntityWithIsDeleted
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}