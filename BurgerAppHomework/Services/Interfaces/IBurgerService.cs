using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;

namespace Services.Interfaces
{
    public  interface IBurgerService
    {
        List<BurgerDto> GetAllBurgers();
        Burger GetBurgerById(int id);
        //void UpdateBurger(Burger burger);
        void AddBurger(CreateBurgerVM createBurgerVM);
        void RemoveBurger(int id);
        bool EditBurger(int id, EditBurgerVm editBurgerVm);
    }
}
