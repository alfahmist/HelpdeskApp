using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Handler
{
    public class CreateTicketEmailHandler
    {
        public string Subject { get; private set; }
        public string TicketName { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Messages { get; private set; }

        public CreateTicketEmailHandler(string sender, string receiver, string subject, string ticket, string message)
        {
            Subject = subject ;
            TicketName = ticket;
            Sender = sender;
            Receiver = receiver;
            Messages = message;
        }

        public MailMessage Message()
        {

            MailMessage message = new MailMessage(Sender, Receiver);
            message.IsBodyHtml = true;
            message.Subject = Subject;
            message.Body = CreateBody();

            return message;

        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("Handler/EmailCustomerSupport.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{TicketName}", TicketName);
            body = body.Replace("{TicketSubject}", Subject);
            body = body.Replace("{TicketMessage}", Messages);
            return body;
        }
    }


}
