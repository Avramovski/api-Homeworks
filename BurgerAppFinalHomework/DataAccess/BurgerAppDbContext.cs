using Domain;
using Microsoft.EntityFrameworkCore;

public class BurgerAppDbContext : DbContext
{
  
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options) { }
   

}
