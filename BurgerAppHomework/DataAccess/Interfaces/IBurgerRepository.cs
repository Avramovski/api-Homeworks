using Domain;
using Dtos.Dtos;

namespace DataAccess.Interfaces
{
    public interface IBurgerRepository : IRepository<Burger> 
    {
        void Add(BurgerDto burger);
    }
}
