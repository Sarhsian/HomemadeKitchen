﻿using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasualShop
{
    public class EmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            email = "sargsyan.mikhail.2017@gmail.com";
            emailMessage.From.Add(new MailboxAddress("Site Manager", email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                //await client.ConnectAsync("smtp.yandex.ru", 25, false);
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(email, "");
                client.Send(emailMessage);

                client.Disconnect(true);
            }
        }
    }
}
