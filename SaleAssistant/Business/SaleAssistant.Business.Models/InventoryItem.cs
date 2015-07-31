using System;
using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class InventoryItem : IBusinessModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}