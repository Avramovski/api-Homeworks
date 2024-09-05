
using DataAccess;
using DataAccess.Interfaces;
using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;
using Services.Interfaces;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly BurgerAppDbContext _context;
        private readonly IRepository<Order> _orderRep;
        public OrderService(BurgerAppDbContext context,IRepository<Order> repository)
        {
            _context = context;
            _orderRep = repository;
        }

        public void AddOrder(CreateOrderVm createOrderVm)
        {
            var newOrder = new Order
            {
                FullName = createOrderVm.FullName,
                Address = createOrderVm.Address,
                Burgers = createOrderVm.Burgers
            };

          
            _context.Orders.Add(newOrder);
            _context.SaveChanges(); 
        }


        public void DeleteOrder(int id)
        {
            var order = _orderRep.GetById(id);
            _orderRep.Delete(order.Id);
        }

        public List<OrderDto> GetAllOrders()
        {
           var orders = _context.Orders.ToList();
            var orderDto = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                FullName=o.FullName,
                Address = o.Address,
                IsDelivered = o.IsDelivered,
                Location = o.Location,
                Burgers = o.Burgers

            }).ToList();
            return orderDto;
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
