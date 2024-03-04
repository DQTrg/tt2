namespace TT2.Entity
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
        public double PriceTicket { get; set; }
        public bool IsActive { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
