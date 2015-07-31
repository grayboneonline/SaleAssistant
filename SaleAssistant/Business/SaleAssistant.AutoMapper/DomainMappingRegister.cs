using AutoMapper;

namespace SaleAssistant.AutoMapper
{
    public class DomainMappingRegister
    {
        public static void Register()
        {
            Map<Data.Entities.Product, Business.Models.Product>();
            Map<Data.Entities.Unit, Business.Models.Unit>();
            Map<Data.Entities.Vendor, Business.Models.Vendor>();
            Map<Data.Entities.Customer, Business.Models.Customer>();
            Map<Data.Entities.ProductPricing, Business.Models.ProductPricing>();
            Map<Data.Entities.Inventory, Business.Models.Inventory>();
            Map<Data.Entities.InventoryItem, Business.Models.InventoryItem>();
        }

        private static void Map<TLeft, TRight>()
        {
            Mapper.CreateMap<TLeft, TRight>();
            Mapper.CreateMap<TRight, TLeft>();
        }
    }

    public static class AutoMapperExtensions
    {
        public static T MapTo<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static void MapTo(this object source, object destination)
        {
            Mapper.Map(source, destination);
        }
    }
}
