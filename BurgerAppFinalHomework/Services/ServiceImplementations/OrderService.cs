using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services.ServiceImplementations
{
    public class OrderService : IOrderService
    {
        private readonly BurgerAppDbContext _context;

        public OrderService(BurgerAppDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order, List<int> burgerIds)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var burgerId in burgerIds)
            {
                _context.BurgerOrders.Add(new BurgerOrder { OrderId = order.Id, BurgerId = burgerId });
            }
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.BurgerOrders).ThenInclude(bo => bo.Burger).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.BurgerOrders).ThenInclude(bo => bo.Burger).FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrder(Order order, List<int> burgerIds)
        {
            var existingOrder = _context.Orders.Include(o => o.BurgerOrders).FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.FullName = order.FullName;
                existingOrder.Address = order.Address;
                existingOrder.IsDelivered = order.IsDelivered;

                // Update BurgerOrders
                _context.BurgerOrders.RemoveRange(existingOrder.BurgerOrders);
                foreach (var burgerId in burgerIds)
                {
                    _context.BurgerOrders.Add(new BurgerOrder { OrderId = order.Id, BurgerId = burgerId });
                }

                _context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }

}
