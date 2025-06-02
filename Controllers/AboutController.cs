using Microsoft.AspNetCore.Mvc;

namespace jooneliweb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
