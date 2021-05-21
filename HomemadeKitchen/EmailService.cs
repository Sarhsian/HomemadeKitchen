using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CasualShop
{
    public class EmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            MailAddress from = new MailAddress("homemadekitchen2022@gmail.com", "Site Manager");
            MailAddress to = new MailAddress("homemadekitchen2022@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = message;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("homemadekitchen2022@gmail.com", "apppass123");
            smtp.EnableSsl = true;
            smtp.Send(m);

            //var emailMessage = new MimeMessage();
            //email = "sargsyan.mikhail.2017@gmail.com";

            //emailMessage.From.Add(new MailboxAddress("Site Manager", email));
            //emailMessage.To.Add(new MailboxAddress("", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = message
            //};

            //using (var client = new SmtpClient())
            //{
            //    //await client.ConnectAsync("smtp.yandex.ru", 25, false);
            //    client.Connect("smtp.gmail.com", 587, true);
            //    client.Authenticate(email, "SARgsYan9mikhail820157161514131211W7");
            //    client.Send(emailMessage);

            //    client.Disconnect(true);
            //}
        }
    }
}
