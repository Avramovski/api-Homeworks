using Domain;

namespace Services
{
    public interface IOrderService
    {
        void AddOrder(Order order, List<int> burgerIds);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void UpdateOrder(Order order, List<int> burgerIds);
        void DeleteOrder(int id);
    }

}
