using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Models;
using System.Diagnostics;

namespace SignalRDemo.Controllers
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
            var guid = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("userSessionId", guid);
            //set cookie
            return View("Connection_Page");
        }

        public IActionResult Privacy()
        {
            var userSessionId = HttpContext.Session.GetString("userSessionId");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}