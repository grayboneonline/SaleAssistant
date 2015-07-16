﻿using System;

namespace SaleAssistant.DataAccess.Entities
{
    public class InventoryDetail
    {
        public Guid Id { get; set; }

        public Guid InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}