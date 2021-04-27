using GucluConsultancy.Static;
using GucluConsultancy.Utility.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GucluConsultancy.Utility
{
  public class EmailSender : IEmailSender
  {
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task SendEmailAsync(string subject, string htmlMessage, IFormFileCollection formFileCollection)
    {
      //var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
      var client = new SendGridClient(_configuration["SENDGRID_API_KEY"]);

      var fromEmail = new EmailAddress(EmailConstants.Sender, EmailConstants.SenderName);
      var toEmail = new EmailAddress(EmailConstants.Receiver);
      string emailSubject = $"Bir müşteriniz {subject} formu doldurdu";
      string plainContent = htmlMessage;
      string htmlContent = htmlMessage;

      SendGridMessage message = MailHelper.CreateSingleEmail(fromEmail, toEmail, emailSubject, plainContent, htmlContent);

      foreach (IFormFile file in formFileCollection)
      {
        // Create a unique filename in case someone uploads more than one document
        // with the same name (in which case the older attachment with the same
        // name gets removed).
        var fileInfo = new FileInfo(file.Name);
        string newFileName = $"{Guid.NewGuid()}{fileInfo.Extension}";

        await message.AddAttachmentAsync(newFileName, file.OpenReadStream(), file.ContentType);
      }

      try
      {
        var response = await client.SendEmailAsync(message);
      }
      catch (Exception)
      {
        // TODO: Log exception message to a log file.
        throw;
      }
    }
  }
}