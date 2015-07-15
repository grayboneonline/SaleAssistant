using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaleAssistant.DataAccess.Entities
{
    public class InventoryDetail
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