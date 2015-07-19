using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.Data.Mapping
{
    public class InventoryItemMap : EntityTypeConfiguration<InventoryItem>
    {
        public InventoryItemMap()
        {
            ToTable("InventoryItem");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.InventoryId);
            HasRequired(x => x.Inventory);

            Property(x => x.ProductId);
            HasRequired(x => x.Product);

            Property(x => x.Quantity);
        }
    }
}
