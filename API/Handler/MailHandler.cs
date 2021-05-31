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
        public string Token { get; private set; }
        public string Url  { get; private set; }
        public string Sender { get; private set; }
        public string ResetUrl { get; private set; }
        public string Receiver { get; private set; }
        
        public MailHandler(string sender, string receiver, string url, string token)
        {
            Url = url;
            Token = token;
            Sender = sender;
            Receiver = receiver;
        }

        public MailMessage Message()
        {

            MailMessage message = new MailMessage(Sender, Receiver);
            message.IsBodyHtml = true;
            message.Subject = "Reset Password Request";
            message.Body = CreateBody();

            return message;
            
        }

        private string CreateBody()
        {
            ResetUrl = $"{Url}?token={Token}";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("Handler/Email.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{ResetUrl}", ResetUrl);
            body = body.Replace("{Url}", Url);
            return body;
        }
    }


}
