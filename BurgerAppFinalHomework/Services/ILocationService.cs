using Domain;

namespace Services
{
    public interface ILocationService
    {
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }

}
