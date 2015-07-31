using System;
using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class Product : IBusinessModel
    {
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Guid UnitId { get; set; }

        [Required]
        public bool IsTrash { get; set; }

        public Unit Unit { get; set; }
    }
}