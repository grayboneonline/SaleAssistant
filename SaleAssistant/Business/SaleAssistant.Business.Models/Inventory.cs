using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class Inventory : IBusinessModel
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}