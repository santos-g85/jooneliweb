using jooneliweb.Models;
using jooneliweb.Services;
using jooneliweb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace jooneliweb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        //private readonly IMongoCollection<ContactModel> _contactCollection;
       private readonly IMongoRepository<ContactModel> _contactCollection;

        public ContactController(ILogger<ContactController> logger, IMongoRepository<ContactModel> contactcollection)
        {
            _logger = logger;
            _contactCollection = contactcollection;
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
                    await _contactCollection.CreateAsync(contact);

                    TempData["SuccessMessage"] = "Your message has been sent successfully!";
                    _logger.LogInformation("Contact message received successfully. Name: {Name}, Email: {Email}, Subject: {Subject}", contact.Name, contact.Email, contact.Subject);
                    return RedirectToAction("Contact", "Home");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error while inserting contact message");
                    return RedirectToAction("Contact", "Home");

                }
            }
            return View("Index"); 
        }
    }
}
