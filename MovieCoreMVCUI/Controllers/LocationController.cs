using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVCUI.Controllers
{
    public class LocationController : Controller
    {

        private IConfiguration _configuration;
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Location> locationresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/GetLocations";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        locationresult = JsonConvert.DeserializeObject<IEnumerable<Location>>(result);
                    }
                }
            }
            return View(locationresult);
        }
        public async Task<IActionResult> EditLocation(int LocationId)
        {
            Location location = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/GetLocationById?locationId=" + LocationId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        location = JsonConvert.DeserializeObject<Location>(result);
                    }
                }
            }

            return View(location);
        }
        [HttpPost]
        public async Task<IActionResult> EditLocation(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/UpdateLocation";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details updated successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteLocation(int LocationId)
        {
            Location location = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/GetLocationById?locationId=" + LocationId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        location = JsonConvert.DeserializeObject<Location>(result);
                    }
                }
            }

            return View(location);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteLocation(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/DeleteLocation?locationId=" + location.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details deleted successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public IActionResult LocationEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LocationEntry(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Locations/AddLocation";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
