using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using WebMailer.Application.Mailing;
using WebMailer.Domain.Settings;
using WebMailer.Models;

namespace WebMailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public async Task<IActionResult> Index()
        {
            // mail service is called here //
            try
            {
                MailMessage message = new MailMessage(
                    new MailAddress("office@example.com"),
                    new MailAddress("example@example.com")
                )
                {
                    IsBodyHtml = true,
                    Subject = "Hello!",
                    Body = @"<h2>Welcome to our Site!</h2><p>The mail service works.</p>"
                };
                await _mailService.SendEmail(message);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
            return Ok(
                "ok"
            );
               
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
