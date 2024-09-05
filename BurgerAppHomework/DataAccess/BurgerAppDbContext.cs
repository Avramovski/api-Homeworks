using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BurgerAppDbContext : DbContext
    {
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Order> Orders { get; set; }

   

        public BurgerAppDbContext()
        {

        }
        public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<BurgerOrder>()
                .HasKey(bo => new { bo.BurgerId, bo.OrderId });

            modelBuilder.Entity<BurgerOrder>()
                .HasOne(bo => bo.Burger)
                .WithMany(b => b.BurgerOrders)
                .HasForeignKey(bo => bo.BurgerId);

            modelBuilder.Entity<BurgerOrder>()
                .HasOne(bo => bo.Order)
                .WithMany(o => o.BurgerOrders)
                .HasForeignKey(bo => bo.OrderId);
            // Seed data for Burgers
            modelBuilder.Entity<Burger>().HasData(
                new Burger { Id = 1, Name = "Classic Burger", Price = 10, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 2, Name = "Veggie Burger", Price = 8,  IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 3, Name = "Vegan Delight", Price = 9, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" },
                new Burger { Id = 4, Name = "Bacon Cheeseburger", Price = 12, IsVegetarian = "No", IsVegan = "No", HasFries = "Yes" }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, FullName = "John Doe", Address = "123 Main St", IsDelivered = "Yes", Location = "Downtown" },
                new Order { Id = 2, FullName = "Jane Smith", Address = "456 Elm St", IsDelivered = "No", Location = "Uptown" },
                new Order { Id = 3, FullName = "Alice Johnson", Address = "789 Oak St", IsDelivered = "Yes", Location = "Suburb" },
                new Order { Id = 4, FullName = "Bob Brown", Address = "321 Pine St", IsDelivered = "No", Location = "City Center" }
            );

            // Seed data for BurgerOrders (Associating Burgers with Orders)
            modelBuilder.Entity<BurgerOrder>().HasData(
                new BurgerOrder { BurgerId = 1, OrderId = 1 },
                new BurgerOrder { BurgerId = 2, OrderId = 2 },
                new BurgerOrder { BurgerId = 3, OrderId = 3 },
                new BurgerOrder { BurgerId = 4, OrderId = 4 },
                new BurgerOrder { BurgerId = 1, OrderId = 4 },
                new BurgerOrder { BurgerId = 2, OrderId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }



    }
}
