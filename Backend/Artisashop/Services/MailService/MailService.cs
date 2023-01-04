using System.Net;
using System.Net.Mail;
using Artisashop.Interfaces.IService;

namespace Artisashop.Services.MailService
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string subject, string bodyText)
        {
            SmtpClient smtpClient = new("ex5.mail.ovh.net", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("contact@artisashop.fr", "X9mseogcdn3E^LfCRVXCJ98XBCo4#8kW")

                /*NetworkCredential networkCredential = new("artisashop", "artisashop2021=)");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;*/
            };
            MailMessage message = new()
            {
                From = new MailAddress("contact@artisashop.fr"),
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