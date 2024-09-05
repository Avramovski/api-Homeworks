using Domain;

namespace Dtos.ViewModels
{
    public class CreateOrderVm
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string IsDelivered { get; set; }
        public string Location { get; set; }
        public List<Burger> Burgers { get; set; } = new List<Burger>();
        public int BurgerId { get; set; }

        public ICollection<BurgerOrder> BurgerOrders { get; set; }


    }
}
