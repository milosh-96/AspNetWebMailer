using System.Net.Mail;

namespace WebMailer.Application.Mailing
{
    public interface IMailService
    {
        Task SendEmail(MailMessage message);
    }
}