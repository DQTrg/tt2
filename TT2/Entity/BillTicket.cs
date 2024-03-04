namespace TT2.Entity
{
    public class BillTicket
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int TicketId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
