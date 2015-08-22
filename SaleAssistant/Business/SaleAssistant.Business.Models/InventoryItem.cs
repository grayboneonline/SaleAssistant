using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class InventoryItem : IBusinessModel
    {
        public int Id { get; set; }

        [Required]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}