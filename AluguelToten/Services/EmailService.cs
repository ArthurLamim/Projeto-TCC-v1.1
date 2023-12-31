﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace AluguelToten.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config) 
        {
            this._config = config;      
        }
      
        public void SendEmail(EmailDTO emailDto)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.To));
            email.Subject = emailDto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailDto.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
