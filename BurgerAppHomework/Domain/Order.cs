﻿
namespace Domain
{
    public class Order : BaseEntity
    {
        public string FullName {  get; set; }
        public string Address { get; set; }
        public string IsDelivered { get; set; }
        public string Location { get; set; }
        public List<Burger> Burgers { get; set; }
        public ICollection<BurgerOrder> BurgerOrders { get; set; }
        
    }
}
