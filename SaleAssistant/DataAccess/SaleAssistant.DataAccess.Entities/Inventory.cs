using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaleAssistant.DataAccess.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        public InventoryStatus Status { get; set; }
    }

    public enum InventoryStatus
    {
        InActive = 0,
        Active = 1,
    }
}