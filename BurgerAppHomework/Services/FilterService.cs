using DataAccess.Interfaces;
using Domain;
using Dtos.Dtos;
using Services.Interfaces;
using Mapper;

namespace Services
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Burger> _burgerRepository;
        private readonly IRepository<Order> _orderRepository;
        public FilterService(
            IRepository<Burger> burgerRepository
            , IRepository<Order> orderRepository
            )
        {
            _burgerRepository = burgerRepository;
            _orderRepository = orderRepository;
        }
        public List<BurgerDto> GetBurgers()
        {
            return _burgerRepository.GetAll().Select(x=>x.Map()).ToList();
        }

        public FilterDto GetFilterDetails()
        {

            return new FilterDto
            {
                Burgers = GetBurgers(),
                Orders = GetOrders(),
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetAll().Select(x => x.Map()).ToList();
        }
    }
}
