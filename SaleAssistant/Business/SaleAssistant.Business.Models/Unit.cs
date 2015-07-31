using System;
using System.ComponentModel.DataAnnotations;

namespace SaleAssistant.Business.Models
{
    public class Unit : IBusinessModel
    {
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool IsTrash { get; set; }
    }
}