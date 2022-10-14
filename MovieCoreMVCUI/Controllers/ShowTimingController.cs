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
    public class ShowTimingController : Controller
    {
        private IConfiguration _configuration;
        public ShowTimingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShowTiming> showtimingresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimings";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showtimingresult = JsonConvert.DeserializeObject<IEnumerable<ShowTiming>>(result);
                    }
                }
            }
            return View(showtimingresult);
        }
        public async Task<IActionResult> EditShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimingById?showTimingId=" + ShowTimingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }
                }
            }

            return View(showTiming);
        }
        [HttpPost]
        public async Task<IActionResult> EditShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/UpdateShowTiming";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTiming details updated successfully!";
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
        public async Task<IActionResult> DeleteShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimingById?showTimingId=" + ShowTimingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }
                }
            }

            return View(showTiming);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/DeleteShowTiming?showTimingId=" + showTiming.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTiming details deleted successfully!";
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
        public IActionResult ShowTimingEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ShowTimingEntry(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/AddShowTiming";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTiming details saved successfully!";
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
