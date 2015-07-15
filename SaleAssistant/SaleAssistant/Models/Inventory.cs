using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaleAssistant.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public InventoryStatus Status { get; set; }
    }

    public enum InventoryStatus
    {
        InActive = 0,
        Active = 1,
    }
}