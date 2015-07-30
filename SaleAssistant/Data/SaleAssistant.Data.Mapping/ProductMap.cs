using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.UnitId);

            HasRequired(x => x.Unit);

            Property(x => x.Status);

            Property(x => x.IsTrash);
        }
    }
}
