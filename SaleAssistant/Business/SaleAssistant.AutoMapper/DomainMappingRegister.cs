using AutoMapper;

namespace SaleAssistant.AutoMapper
{
    public class DomainMappingRegister
    {
        public static void Register()
        {
            Map<Data.Entities.Product, Business.Models.Product>();
        }

        private static void Map<TLeft, TRight>()
        {
            Mapper.CreateMap<TLeft, TRight>();
            Mapper.CreateMap<TRight, TLeft>();
        }
    }
}
