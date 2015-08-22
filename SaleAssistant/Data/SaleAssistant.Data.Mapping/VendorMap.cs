//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.ModelConfiguration;
//using SaleAssistant.Data.Entities;

//namespace SaleAssistant.Data.Mapping
//{
//    public class VendorMap : EntityTypeConfiguration<Vendor>
//    {
//        public VendorMap()
//        {
//            ToTable("Vendor");

//            HasKey(x => x.Id);
//            Property(x => x.Id)
//                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

//            Property(x => x.Name)
//                .IsRequired()
//                .HasMaxLength(200);

//            Property(x => x.Status);

//            Property(x => x.IsTrash);
//        }
//    }
//}
