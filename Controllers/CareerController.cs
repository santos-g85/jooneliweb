using jooneliweb.Models;
using jooneliweb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace jooneliweb.Controllers
{
   
    public class CareerController : Controller
    {
        private static readonly List<JobOpeningModel> _jobs = new()
            {
                new JobOpeningModel
                {
                    Id = "360-core-banking",
                    Title = "360 Core Banking System",
                    Department = "Development",
                    Location = "on site",
                    LogoUrl = "/images/joonlogo--JfLTwqW.png",
                    Description = "Work on mission-critical banking infrastructure with a dedicated and innovative team.",
                    EmploymentType = "Full-Time",
                },
                new JobOpeningModel
                {
                    Id = "trading-system",
                    Title = "Trading System",
                    Department = "Development",
                    Location = "Kathmandu",
                    LogoUrl = "/images/joonlogo--JfLTwqW.png",
                    Description = "Develop and maintain advanced trading systems to optimize performance.",
                    EmploymentType = "Full-Time",
                },
                new JobOpeningModel
                {
                    Id = "multidesk-support-specialist",
                    Title = "MultipleDesk Support Specialist",
                    Department = "Support",
                    Location = "Lalitpur",
                    LogoUrl = "/images/joonlogo--JfLTwqW.png",
                    Description = "Provide exceptional technical assistance and remote desktop support to enterprise clients.",
                    EmploymentType = "Full-Time",
                }
            };

        public IActionResult JobDetails(string id)
        {
            var job = _jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View("Views/Home/Career/Details.cshtml",job);
        }

        private readonly IMongoRepository<CVUploadModel> _CVcollections;
        private readonly ILogger<CareerController> _logger;

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
