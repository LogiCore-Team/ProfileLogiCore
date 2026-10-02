using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;
using Portflio.Models;
using Portflio.Services;

namespace Portflio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortfolioContentProvider _contentProvider;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(
            ILogger<HomeController> logger,
            IPortfolioContentProvider contentProvider,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _contentProvider = contentProvider;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_contentProvider.GetHomePage());
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(
            [Bind("Name,Email,Subject,Message")] ContactMessage contactMessage)
        {
            if (!ModelState.IsValid)
            {
                var validationMessage = ModelState.Values
                    .SelectMany(entry => entry.Errors)
                    .Select(error => error.ErrorMessage)
                    .FirstOrDefault(message => !string.IsNullOrWhiteSpace(message));

                return BadRequest(new
                {
                    success = false,
                    message = validationMessage ?? "Please review the form and try again."
                });
            }

            contactMessage.Name = contactMessage.Name.Trim();
            contactMessage.Email = contactMessage.Email.Trim();
            contactMessage.Subject = contactMessage.Subject.Trim();
            contactMessage.Message = contactMessage.Message.Trim();
            contactMessage.CreatedAt = DateTime.UtcNow;
            contactMessage.IsRead = false;

            try
            {
                _dbContext.ContactMessages.Add(contactMessage);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError(exception, "Failed to save a contact message.");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    success = false,
                    message = "We could not send your message right now. Please try again later."
                });
            }

            return Json(new
            {
                success = true,
                message = "Thanks. Your message has been sent successfully."
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
