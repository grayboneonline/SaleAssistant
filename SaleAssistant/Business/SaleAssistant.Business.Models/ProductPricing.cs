using System;
using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class ProductPricing : IBusinessModel
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public PricingType Type { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }

    public enum PricingType
    {
        Cost = 0,
        Sale = 1
    }
}