using System.Diagnostics;
using jooneliweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace jooneliweb.Controllers
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
           
            return View();
        }
        
        public IActionResult About()
        {

            return View("About/Index");
        }
        public IActionResult Business()
        {

            return View("Business/Index");
        }
        public IActionResult Career()
        {

            return View("Career/Index");
        }
        public IActionResult Contact()
        {

            return View("Contact/Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
