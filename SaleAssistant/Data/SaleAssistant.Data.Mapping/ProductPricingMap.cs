using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.Data.Mapping
{
    public class ProductPricingMap : EntityTypeConfiguration<ProductPricing>
    {
        public ProductPricingMap()
        {
            ToTable("ProductPricing");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ProductId);
            HasRequired(x => x.Product);

            Property(x => x.Type);

            Property(x => x.UnitPrice);

            Property(x => x.EffectiveDate);

            Property(x => x.CreatedDate);
        }
    }
}
