using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleAssistant.Data.Entities
{
    public class Unit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required, Index]
        //public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //public override bool IsVisible
        //{
        //    get { return !IsTrash && Status == Status.Active; }
        //}
    }
}