using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface ILocationRepository
    {
        void AddLocation(Location location);

        void UpdateLocation(Location location);

        void DeleteLocation(int locationId);

        Location GetLocationById(int locationId);
        IEnumerable<Location> GetLocations();
    }
}
