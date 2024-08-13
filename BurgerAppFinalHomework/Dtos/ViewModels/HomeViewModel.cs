using Domain;


namespace Dtos.ViewModels
{
    public class HomeViewModel
    {
        public Burger MostPopularBurger { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageOrderPrice { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
