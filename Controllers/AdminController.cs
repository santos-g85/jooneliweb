using jooneliweb.Models;
using jooneliweb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace jooneliweb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMongoRepository<NewsModel> _newscollection;
        private readonly IMongoRepository<ContactModel> _contactcollection;
        public ILogger<AdminController> _logger;

        public AdminController(IMongoRepository<NewsModel> newscollection, ILogger<AdminController> logger, IMongoRepository<ContactModel> contactcollection)
        {
            _newscollection = newscollection;
            _logger = logger;
            _contactcollection = contactcollection;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Business()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var newsitems = await _newscollection.GetAllAsync();
            return View("News/Index", newsitems);
        }

        public async Task<IActionResult> Contact()
        {
            var contactItems = await _contactcollection.GetAllAsync();
            return View("Messages/Index", contactItems);
        }
    }
}
