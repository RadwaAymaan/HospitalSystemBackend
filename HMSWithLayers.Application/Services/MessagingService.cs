using HMSWithLayers.Application.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
namespace HMSWithLayers.Application.Services;

public class MessagingService() : IMessagingService
{

    public Task SendMessage(string recipient, string subject, string message)
    {
        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
        {
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("hagershaaban7@gmail.com", "crxm pwdf jtys qnit");
            smtpClient.EnableSsl = true;

            // Create and send the email message
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress("hagershaaban7@gmail.com");
                emailMessage.To.Add(recipient);
                emailMessage.Subject = subject;
                emailMessage.Body = message;
                emailMessage.Body = $"<html><body>{message}</body></html>";
                emailMessage.IsBodyHtml = true;
                smtpClient.Send(emailMessage);
            }
        }
        return Task.CompletedTask;
    }
}

