using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaleAssistant.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        public ProductStatus Status { get; set; }
    }

    public enum ProductStatus
    {
        InActive = 0,
        Active = 1,
    }
}