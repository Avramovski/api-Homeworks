using DataAccess;
using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;

namespace BurgerAppHomework.Controllers
{
    [Route("")]
    public class BurgerAppController : Controller
    {
        private readonly IBurgerService _burgerService;
        private readonly IFilterService _filterService;
        private readonly IOrderService _orderService;

        public BurgerAppController(IBurgerService burgerService,IFilterService filterService,IOrderService orderService)
        {
            _burgerService = burgerService;
            _filterService = filterService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            int? orderId = null;
            int? burgerId = null;
            ViewBag.Filter = new FilterDto();

            if (TempData["HasFilter"] != null)
            {
                ViewBag.Filter.OrderId = (int)TempData["Order"];
                orderId = (int)TempData["Order"];

                ViewBag.Filter.BurgerId = (int)TempData["Burger"];
                burgerId = (int)TempData["Burger"];
            }
            ViewBag.Filter.Orders = _filterService.GetOrders();
            ViewBag.Filter.Burgers = _filterService.GetBurgers();

            var burgers = _burgerService.GetAllBurgers();
            return View(burgers);   

        }

        [HttpPost]
        public IActionResult RemoveBurger()
        {
            if (int.TryParse(Request.Form["id"], out int id))
            {
                try
                {
                    _burgerService.RemoveBurger(id);
                }
                catch (InvalidOperationException ex)
                {
                    return Content(ex.Message + " {id}");
                }
            }
            else
            {
                return Content("Invalid burger ID.");
            }

            return RedirectToAction("Index");
        }
        [HttpGet("add")]
        public IActionResult AddBurger()
        {
            ViewBag.Burgers = _filterService.GetBurgers();
            return View("AddBurger");
        }

        [HttpPost("add")]
        public IActionResult AddBurger(CreateBurgerVM createBurgerVm)
        {
            if (ModelState.IsValid)
            {
                var burger = new Burger
                {
                    Name = createBurgerVm.Name,
                    Price = createBurgerVm.Price,
                    IsVegetarian = createBurgerVm.IsVegetarian,
                    IsVegan = createBurgerVm.IsVegan,
                    HasFries = createBurgerVm.HasFries
                };

                _burgerService.AddBurger(createBurgerVm);
                return RedirectToAction("Index");
            }
            return View(createBurgerVm);
        }
        [HttpGet("edit/{id}")]
        public IActionResult EditBurger()
        {
            ViewBag.Burgers = _filterService.GetBurgers();
            return View("AddBurger");
        }
        [HttpPost("edit")]
        public IActionResult EditBurger(int id, EditBurgerVm editBurgerVm)
        {
            if (ModelState.IsValid)
            {
                var result = _burgerService.EditBurger(id, editBurgerVm);
                if (result)
                {
                    return RedirectToAction("Index");
                }

                return NotFound();
            }

            return View(editBurgerVm);
        }
    


    }
}
