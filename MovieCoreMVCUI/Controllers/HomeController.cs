using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCoreMVCUI.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using static BookMyShowData.MovieDAL;



namespace MovieCoreMVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //IEnumerable<User> userresult = null;
            //using (HttpClient client = new HttpClient())
            //{

            //    string endPoint = _configuration["WebApiBaseUrl"] + "Users/GetUsers";
            //    using (var response = await client.GetAsync(endPoint))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            var result = await response.Content.ReadAsStringAsync();
            //            userresult = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
            //        }
            //    }
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
