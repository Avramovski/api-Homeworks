using Domain;
using Dtos.Dtos;
using Dtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace BurgerAppHomework.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBurgerService _burgerService;
        private readonly IFilterService _filterService;
        private readonly IOrderService _orderService;

        public OrderController(IBurgerService burgerService, IFilterService filterService, IOrderService orderService)
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

            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
        [HttpGet("addOrder")]
        public IActionResult AddOrder()
        {
            ViewBag.Burgers = _filterService.GetBurgers();
            return View("AddOrder");
        }
        [HttpPost("addOrder")]
        public IActionResult AddOrder(CreateOrderVm createOrderVm)
        {
            if (createOrderVm.BurgerId == 0)
            {
                ViewBag.Error = "Please select valid category";
                ViewBag.Burgers = _filterService.GetBurgers();
                return View(createOrderVm);
            }

            _orderService.AddOrder(createOrderVm);
            return RedirectToAction("Index");
        }

    }
}
