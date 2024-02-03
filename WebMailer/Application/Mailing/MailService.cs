using System.Net;
using System.Net.Mail;
using WebMailer.Domain.Settings;

namespace WebMailer.Application.Mailing
{
    public class MailService : IMailService
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

        public async Task SendEmail(MailMessage message)
        {
            var client = new SmtpClient(mailSettings.Host, mailSettings.Port);
            NetworkCredential credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password);

            client.Credentials = credentials;

            client.SendAsync(message, credentials.UserName);
            client.SendCompleted += (sender, e) =>
            {
                Console.WriteLine("Done!");
            };


        }
    }
}
