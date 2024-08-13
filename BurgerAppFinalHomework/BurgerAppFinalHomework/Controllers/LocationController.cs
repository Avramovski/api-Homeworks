using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BurgerAppFinalHomework.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            var locations = _locationService.GetAllLocations();
            return View(locations);
        }

        public IActionResult Edit(int id)
        {
            var location = _locationService.GetLocationById(id);
            if (location == null) return NotFound();

            return View(location);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationService.UpdateLocation(location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationService.AddLocation(location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        public IActionResult Delete(int id)
        {
            _locationService.DeleteLocation(id);
            return RedirectToAction("Index");
        }
    }

}
