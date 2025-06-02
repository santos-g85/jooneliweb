using Microsoft.AspNetCore.Mvc;

namespace jooneliweb.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
