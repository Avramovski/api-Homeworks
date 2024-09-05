using Domain;
using Dtos.Dtos;

namespace Mapper
{
    public static class MapperExtensions
    {
        public static BurgerDto Map(this Burger burger)
        {
            return new BurgerDto { Id = burger.Id, Name = burger.Name };

        }

        public static OrderDto Map(this Order order)
        {
            return new OrderDto { Id = order.Id, FullName = order.FullName };
        }
    }
}
