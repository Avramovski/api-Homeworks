using DataAccess;
using DataAccess.Interfaces;
using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;

namespace Services
{
    public class BurgerService : IBurgerService
    {
        private readonly BurgerAppDbContext _context;
        private readonly IRepository<Burger> _burgerRep;
        

        public BurgerService(BurgerAppDbContext context, IRepository<Burger> burgerRep)
        {
          _context = context;   
            _burgerRep=burgerRep;
           
        }

        public List<BurgerDto> GetAllBurgers()
        {
            var burgers = _context.Burgers.ToList();

            // Manually map Burger to BurgerDto
            var burgerDtos = burgers.Select(b => new BurgerDto
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.Price,
                IsVegetarian = b.IsVegetarian,
                IsVegan = b.IsVegan,
                HasFries = b.HasFries

                // Map other properties as needed
            }).ToList();

            return burgerDtos;
        }


        public Burger GetBurgerById(int id)
        {
            return _burgerRep.GetById(id);
        }

        public void AddBurger(CreateBurgerVM createBurgerVM)
        {
            var newBurger = new Burger
            {
                Name = createBurgerVM.Name,
                Price = createBurgerVM.Price,
                IsVegetarian = createBurgerVM.IsVegetarian,
                IsVegan = createBurgerVM.IsVegan,
                HasFries = createBurgerVM.HasFries


            };
            _burgerRep.Add(newBurger);
        }

        public void UpdateBurger(Burger burger)
        {
            _context.Burgers.Update(burger);
            _context.SaveChanges();
        }

        public void RemoveBurger(int id)
        {
            var burger = _burgerRep.GetById(id);
          
             _burgerRep.Delete(burger.Id);

            
        }


        public bool EditBurger(int id, EditBurgerVm editBurgerVm)
        {
            var burger = _context.Burgers.Find(id);
            if (burger == null)
            {
                return false;
            }
            burger.Id =editBurgerVm.Id;
            burger.Name = editBurgerVm.Name;
            burger.Price = editBurgerVm.Price;
            burger.IsVegetarian = editBurgerVm.IsVegetarian;
            burger.IsVegan = editBurgerVm.IsVegan;
            burger.HasFries = editBurgerVm.HasFries;

            _context.SaveChanges();
            return true;
        }
    }
}

