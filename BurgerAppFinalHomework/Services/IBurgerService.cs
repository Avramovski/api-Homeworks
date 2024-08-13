using Domain;
using Dtos.ViewModels;

namespace Services
{
    public interface IBurgerService
    {
        IEnumerable<Burger> GetAllBurgers();
        Burger GetBurgerById(int id);
        void AddBurger(CreateBurgerVM createBurgerVM);
        void UpdateBurger(CreateBurgerVM createBurgerVM);
        void DeleteBurger(int id);
    }

}
