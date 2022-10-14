using BookMyShowBussiness.services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private LocationService _locationService;
        public LocationsController(LocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet("GetLocations")]
        public IEnumerable<Location> GetLocations()
        {
            return _locationService.GetLocations();
        }
        [HttpGet("GetLocationById")]
        public Location GetLocationById(int locationId)
        {
            return _locationService.GetLocationByid(locationId);
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation([FromBody] Location location)
        {
            _locationService.AddLocation(location);
            return Ok("Location created successfully!!");
        }
        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationId)
        {
            _locationService.DeleteLocation(locationId);
            return Ok("Location deleted successfully!!");
        }
        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] Location location)
        {
            _locationService.UpdateLocation(location);
            return Ok("Location updated successfully!!");
        }
    }
}
