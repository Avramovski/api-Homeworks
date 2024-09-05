using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders();
        void AddOrder(CreateOrderVm createOrderVm);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);

    }
}
