using Domain;
using Dtos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Services.ServiceImplementations
{
    public class BurgerService : IBurgerService
    {
        private readonly BurgerAppDbContext _context;

        public BurgerService(BurgerAppDbContext context)
        {
            _context = context;
        }

        public void AddBurger(CreateBurgerVM createBurgerVM)
        {
            var burger = new Burger
            {
                Name = createBurgerVM.Name,
                Price = createBurgerVM.Price,
                IsVegetarian = createBurgerVM.IsVegetarian,
                IsVegan = createBurgerVM.IsVegan,
                HasFries = createBurgerVM.HasFries,
                LocationId = createBurgerVM.LocationId
            };
            _context.Burgers.Add(burger);
            _context.SaveChanges();
        }

        public IEnumerable<Burger> GetAllBurgers()
        {
            return _context.Burgers.Include(b => b.Location).ToList();
        }

        public Burger GetBurgerById(int id)
        {
            return _context.Burgers.Include(b => b.Location).FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBurger(CreateBurgerVM createBurgerVM)
        {
            var burger = _context.Burgers.Find(createBurgerVM.Id);
            if (burger != null)
            {
                burger.Name = createBurgerVM.Name;
                burger.Price = createBurgerVM.Price;
                burger.IsVegetarian = createBurgerVM.IsVegetarian;
                burger.IsVegan = createBurgerVM.IsVegan;
                burger.HasFries = createBurgerVM.HasFries;
                burger.LocationId = createBurgerVM.LocationId;

                _context.SaveChanges();
            }
        }

        public void DeleteBurger(int id)
        {
            var burger = _context.Burgers.Find(id);
            if (burger != null)
            {
                _context.Burgers.Remove(burger);
                _context.SaveChanges();
            }
        }
    }

}
