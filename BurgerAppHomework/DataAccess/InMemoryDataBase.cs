using Domain;

namespace BurgerAppHomework
{
    public static class InMemoryDataBase
    {
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        static InMemoryDataBase()
        {
            LoadBurgers();
            LoadOrders();
            
        }

        private static void LoadBurgers() {
        Burgers = new List<Burger>()
        {
          new Burger { Id = 1, Name = "Classic Burger", Price = 10, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 2, Name = "Veggie Burger", Price = 8,  IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 3, Name = "Vegan Delight", Price = 9, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 4, Name = "Bacon Cheeseburger", Price = 12, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" }
        };

        }
        private static void LoadOrders() {
            Orders = new List<Order>() {
 new Order { Id = 1, FullName = "John Doe", Address = "123 Main St", IsDelivered = "Yes", Location = "Downtown",      Burgers = new List<Burger>
                {
                    new Burger { Name = "Classic Burger" },
                    new Burger { Name =  "Burger"}
                } },
        new Order { Id = 2, FullName = "Jane Smith", Address = "456 Elm St", IsDelivered = "No", Location = "Uptown",      Burgers = new List<Burger>
                {
                    new Burger { Name = "Classic Burger" },
                    new Burger { Name =  "Burger"}
                } },
        new Order { Id = 3, FullName = "Alice Johnson", Address = "789 Oak St", IsDelivered = "Yes", Location = "Suburb",      Burgers = new List<Burger>
                {
                    new Burger { Name = "Classic Burger" },
                    new Burger { Name =  "Burger"}
                } },
        new Order { Id = 4, FullName = "Bob Brown", Address = "321 Pine St", IsDelivered = "No", Location = "City Center",      Burgers = new List<Burger>
                {
                    new Burger { Name = "Classic Burger" },
                    new Burger { Name =  "Burger"}
                } }

            };
        }
    }
}
