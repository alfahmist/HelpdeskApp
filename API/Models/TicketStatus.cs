namespace API.Models
{
    public class TicketStatus
    {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public Status Status { get; set; }
    }
}