using Domain;

namespace Services.ServiceImplementations
{
    public class LocationService : ILocationService
    {
        private readonly BurgerAppDbContext _context;

        public LocationService(BurgerAppDbContext context)
        {
            _context = context;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.Find(id);
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }
    }

}
