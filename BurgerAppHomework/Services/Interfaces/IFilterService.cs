using Dtos.Dtos;

namespace Services.Interfaces
{
    public interface IFilterService
    {
        List<BurgerDto> GetBurgers();
        List<OrderDto> GetOrders();
        FilterDto GetFilterDetails();
    }
}
