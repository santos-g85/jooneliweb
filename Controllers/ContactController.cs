using jooneliweb.Models;
using jooneliweb.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace jooneliweb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IMongoCollection<ContactModel> _contactCollection;

        public ContactController(ILogger<ContactController> logger, MongoDbContext mongoDbContext)
        {
            _logger = logger;
            _contactCollection = mongoDbContext.ContactCollection;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            if (ModelState.IsValid)
            {
                var contact = new ContactModel
                {
                    Name = Request.Form["Name"],
                    Email = Request.Form["Email"],
                    Subject = Request.Form["Subject"],
                    Message = Request.Form["Message"],
                    CreatedAt = DateTime.UtcNow
                };
                try
                {
                    await _contactCollection.InsertOneAsync(contact);

                    TempData["SuccessMessage"] = "Your message has been sent successfully!";
                    _logger.LogInformation("Contact message received successfully. Name: {Name}, Email: {Email}, Subject: {Subject}", contact.Name, contact.Email, contact.Subject);
                    return RedirectToAction("Index", "Contact");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error while inserting contact message");
                    TempData["ErrorMessage"] = "There was a problem sending your message. Please try again later.";
                    return RedirectToAction("Index", "Contact");

                }
            }
            TempData["ErrorMessage"] = "Please correct the highlighted errors and try again.";
            return View("Index"); 
        }
    }
}
