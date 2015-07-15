using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaleAssistant.DataAccess.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Code { get; set; }

        public ProductStatus Status { get; set; }
    }

    public enum ProductStatus
    {
        InActive = 0,
        Active = 1,
    }
}