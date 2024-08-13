using Domain;
using Dtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BurgerAppFinalHomework.Controllers
{
    public class BurgerController : Controller
    {
        private readonly IBurgerService _burgerService;

        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            var burgers = _burgerService.GetAllBurgers();
            return View(burgers);
        }

        public IActionResult Edit(int id)
        {
            var burger = _burgerService.GetBurgerById(id);
            if (burger == null) return NotFound();

            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(CreateBurgerVM createBurgerVM)
        {
            if (ModelState.IsValid)
            {
                _burgerService.UpdateBurger(createBurgerVM);
                return RedirectToAction("Index");
            }

            return View(createBurgerVM);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateBurgerVM createBurgerVM )
        {
            if (ModelState.IsValid)
            {
                _burgerService.AddBurger(createBurgerVM);
                return RedirectToAction("Index");
            }

            return View(createBurgerVM);
        }

        public IActionResult Delete(int id)
        {
            _burgerService.DeleteBurger(id);
            return RedirectToAction("Index");
        }
    }

}
