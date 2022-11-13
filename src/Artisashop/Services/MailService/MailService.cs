using System.Net.Mail;
using Artisashop.Interfaces.IService;

namespace Artisashop.Services.MailService
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string subject, string bodyText)
        {
            SmtpClient smtpClient = new("smtp-server", 25)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = false,
                /*NetworkCredential networkCredential = new("artisashop", "artisashop2021=)");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;*/
                UseDefaultCredentials = true
            };
            MailMessage message = new()
            {
                From = new MailAddress("artisashop@artisashop.eu"),
                Subject = subject,
                Body = bodyText,
                IsBodyHtml = true
            };
            message.To.Add(to);
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }
    }
}