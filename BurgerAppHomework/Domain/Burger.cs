

namespace Domain
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }    
        public int Price { get; set; }
        public string IsVegetarian { get; set; }
        public string IsVegan {  get; set; }
        
        public string? HasFries { get; set; }
        

        public ICollection<BurgerOrder> BurgerOrders { get; set; }


    }
}
