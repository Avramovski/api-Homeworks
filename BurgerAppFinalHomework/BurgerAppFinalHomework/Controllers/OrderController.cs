using Microsoft.AspNetCore.Mvc;
using Dtos.ViewModels;
using Domain;
using Services;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IBurgerService _burgerService;

    public OrderController(IOrderService orderService, IBurgerService burgerService)
    {
        _orderService = orderService;
        _burgerService = burgerService;
    }

    [HttpGet("add")]
    public IActionResult AddOrder()
    {
        ViewBag.Burgers = _burgerService.GetAllBurgers();
        return View(new CreateOrderVM());
    }

    [HttpPost("add")]
    public IActionResult AddOrder(CreateOrderVM createOrderVM)
    {
        if (ModelState.IsValid)
        {
            var order = new Order
            {
                FullName = createOrderVM.FullName,
                Address = createOrderVM.Address,
                IsDelivered = createOrderVM.IsDelivered
            };

            _orderService.AddOrder(order, createOrderVM.BurgerIds);
            return RedirectToAction("Index");
        }

        ViewBag.Burgers = _burgerService.GetAllBurgers();
        return View(createOrderVM);
    }

    // Implement other actions for editing, deleting, and listing orders
}
