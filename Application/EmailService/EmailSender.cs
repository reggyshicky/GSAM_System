using System.Net.Mail;
using System.Net;

namespace Application.EmailService
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("specialassetsmanagement@outlook.com", "Nugetpackages124#")
            };

            return client.SendMailAsync(
                new MailMessage(from: "specialassetsmanagement@outlook.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
