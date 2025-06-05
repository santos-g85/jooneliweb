using jooneliweb.Models;
using jooneliweb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace jooneliweb.Controllers
{
    public class NewsController : Controller
    {

        private readonly ILogger<NewsController> _logger;
        //private readonly IMongoCollection<NewsModel> _newsCollection;
        //private readonly GridFSBucket _gridBucket;
       private readonly IMongoRepository<NewsModel> _newsCollection;
        public NewsController(ILogger<NewsController> logger, IMongoRepository<NewsModel> NewsCollection)
        {
            _logger = logger;
            _newsCollection = NewsCollection;
           // _gridBucket = gridBucket;
        }

        //GET: NewsController
        public ActionResult Index()
        {
            return View("~/Views/Admin/News/Index.cshtml");
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("~/Views/Admin/News/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                var news = new NewsModel
                {
                    Title = Request.Form["Title"],
                    Content = Request.Form["Content"],
                    Category = Request.Form["Category"],
                    CreatedAt = DateTime.UtcNow
                };
                
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await ImageFile.CopyToAsync(memoryStream);
                        news.Image = memoryStream.ToArray(); 
                    }
                }

                try
                {
                   
                    await _newsCollection.CreateAsync(news);
                    _logger.LogInformation("News item created successfully: {Title}", news.Title);
                    Console.WriteLine("succesfully cread news article");
                }
                catch (Exception ex)
                {
                    // Log the error and return the same view with error message
                    _logger.LogError(ex, "Error while creating news item: {Title}", news.Title);
                    ModelState.AddModelError("", "An error occurred while creating the news item. Please try again.");
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return RedirectToAction("Create");
                }
            }

            // If model is invalid, return the same view with validation errors
            return View();
        }


        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //public async Task<IActionResult> HomeNewsSection()
        //{
        //    var news = await _newsCollection.GetAllSortedByDateAsync();
                

        //    var viewModel = news.Select(n => new NewsViewModel
        //    {
        //        Title = n.Title,
        //        Content = n.Content,
        //        Category = n.Category,
        //        IsFeatured = n.IsFeatured,
        //        CreatedAt = n.CreatedAt,
        //        Image = n.Image != null
        //            ? $"data:image/jpeg;base64,{Convert.ToBase64String(n.Image.AsByteArray)}"
        //            : "/images/default.jpg"
        //    }).ToList() ?? new List<NewsViewModel>(); //new List<NewsViewModel>() ensure to newsviewmodel is never null

        //    return PartialView("~/Views/Shared/Partials/_NewsHome.cshtml",viewModel);
        //}
    }
}
