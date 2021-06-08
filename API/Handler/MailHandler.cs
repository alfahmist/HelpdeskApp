using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Handler
{
    public class MailHandler
    {
        public string ResetUrl { get; private set; }
        public string Url { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }

        public MailHandler(string sender, string receiver, string url, string token)
        {
            Url = url;
            ResetUrl = url + token;
            Sender = sender;
            Receiver = receiver;
        }

        public MailMessage Message()
        {
            // Body Message
            MailMessage message = new MailMessage(Sender, Receiver);
            message.IsBodyHtml = true;
            message.Subject = "Reset Password Request";
            message.Body = CreateBody();

            return message;

        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("Handler/Email.html"))
            {
                body = reader.ReadToEnd();
            }

            // fungsi ini untuk mengubah data pada file HTML
            // body.Replace("{NAMA}", "John Smith");
            body = body.Replace("{ResetUrl}", ResetUrl);
            body = body.Replace("{Url}", Url);
            return body;
        }
    }


}
