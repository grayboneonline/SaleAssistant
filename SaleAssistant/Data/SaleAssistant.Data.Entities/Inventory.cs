﻿namespace SaleAssistant.Data.Entities
{
    public class Inventory : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool IsTrash { get; set; }
    }
}