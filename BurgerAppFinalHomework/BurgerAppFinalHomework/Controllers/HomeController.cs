using BurgerAppFinalHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace BurgerAppFinalHomework.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var mostPopularBurger = _orderService.GetMostPopularBurger();
            var totalOrders = _orderService.GetTotalOrders();
            var averageOrderPrice = _orderService.GetAverageOrderPrice();

            var model = new HomeViewModel
            {
                MostPopularBurger = mostPopularBurger,
                TotalOrders = totalOrders,
                AverageOrderPrice = averageOrderPrice
            };

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }

}
