using BurgerAppHomework;
using DataAccess.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ImplementationsInMemDb
{
    public class BurgerRepositoryInMbDb : IRepository<Burger>
    {
        private readonly BurgerAppDbContext _context;
        public void Add(Burger entity)
        {
            entity.Id = InMemoryDataBase.Burgers.Count+1;
            InMemoryDataBase.Burgers.Add(entity);
        }

        public void Delete(int id)
        {
            var burger = _context.Burgers.Find(id);
            if (burger != null)
            {
                _context.Burgers.Remove(burger);
                _context.SaveChanges();
            }
        }


        public IEnumerable<Burger> GetAll()
        {
           return InMemoryDataBase.Burgers;
        }

       

        public Burger GetById(int id)
        {
            return InMemoryDataBase.Burgers.FirstOrDefault(i=>i.Id == id);
        }

        public void Update(Burger entity)
        {
            var burgers = GetById(entity.Id);
            if (burgers != null)
            {
                var burgerIndex = InMemoryDataBase.Burgers.IndexOf(burgers);
                InMemoryDataBase.Burgers[burgerIndex] = entity;
            }
        }
    }
}
