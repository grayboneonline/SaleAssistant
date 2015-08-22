using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleAssistant.Data.Entities
{
    public class ProductPricing : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

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