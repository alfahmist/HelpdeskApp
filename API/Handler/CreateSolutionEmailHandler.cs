using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Handler
{
    public class CreateSolutionEmailHandler
    {
        public string TicketSubject { get; private set; }
        public string TicketId { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Solution { get; private set; }

        public CreateSolutionEmailHandler(string sender, string receiver, string ticketId, string ticketSubject, string solution)
        {
            TicketSubject = ticketSubject;
            TicketId = ticketId;
            Sender = sender;
            Receiver = receiver;
            Solution = solution;
        }

        public MailMessage Message()
        {

            MailMessage message = new MailMessage(Sender, Receiver);
            message.IsBodyHtml = true;
            message.Subject = "Ticket Solution For: " + TicketSubject;
            message.Body = CreateBody();

            return message;

        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("Handler/SolutionEmail.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{TicketId}", TicketId);
            body = body.Replace("{Solution}", Solution);
            return body;
        }
    }


}

