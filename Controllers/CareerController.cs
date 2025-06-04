using jooneliweb.Models;
using jooneliweb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace jooneliweb.Controllers
{
    public class CareerController : Controller
    {
        private readonly IMongoRepository<CVUploadModel> _CVcollections;
        private ILogger<CareerController> _logger;

        public CareerController(IMongoRepository<CVUploadModel> cVcollections, ILogger<CareerController> logger)
        {
            _CVcollections = cVcollections;
            _logger = logger;
        }

        public async Task<IActionResult> CVUploads(string Name, string ContactNumber, string Email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var resumes = new CVUploadModel
                    {
                        Name = Name,
                        ContactNumber = ContactNumber,
                        Email = Email
                    };

                    
                    await _CVcollections.CreateAsync(resumes);

                    _logger.LogInformation("Resume data sent successfully.");
                    return RedirectToAction("Index", "Home"); 
                }
                catch (Exception e)
                {
                    _logger.LogError($"Failed to send resume data: {e.Message}");
                    ModelState.AddModelError("", "An error occurred while sending the resume data. Please try again.");
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return View("~Views/Home/Career/Index.html");
                }
            }

            return View("~Views/Home/Career/Index.html");
        }
    }
}
