using DataAccess.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        private readonly BurgerAppDbContext _dbContext;
        

        public BurgerRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BurgerRepository()
        {
            
        }
        public void Add(Burger entity)
        {

            _dbContext.Burgers.Add(entity);
            _dbContext.SaveChanges();
        }
  

        public void Delete(int id)
        {
            Burger burger =  GetById(id);
            if (burger != null)
            {
                _dbContext.Burgers.Remove(burger);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Burger> GetAll()
        {
            return _dbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _dbContext.Burgers.FirstOrDefault(i=>i.Id == id);
        }

        public void Update(Burger entity)
        {
           _dbContext.Burgers.Update(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Burger> GetAllBurgers()
        {
            return _dbContext.Burgers.ToList();
        }
    }
}
