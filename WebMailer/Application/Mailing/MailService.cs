using System.Net;
using System.Net.Mail;
using WebMailer.Domain.Settings;

namespace WebMailer.Application.Mailing
{
    public class MailService 
    {
        private readonly IConfiguration _configuration;
        private readonly MailSettings mailSettings;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;

            mailSettings = new MailSettings();
            try
            {
                mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Couldn't parse values!");
            }
            
        }

        public async Task SendEmail()
        {
            var client = new SmtpClient(mailSettings.Host, mailSettings.Port);
            NetworkCredential credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password);

            client.Credentials = credentials;
           
            MailMessage message = new MailMessage(
                new MailAddress("office@milos.com"),
                new MailAddress("exec@asd.com")
            )
            {
                IsBodyHtml = true,
                Subject = "Zdravo",
                Body = @"<strong>Zdravo, ovo je email.</strong>"
            };
            client.SendAsync(message,credentials.UserName);
            client.SendCompleted += (sender, e) =>
            {
                Console.WriteLine("Done!");
            };

            
        }
    }
}
