namespace TT2.Payload.DataRequest.Ticket
{
    public class Request_UpdateTicket
    {
        public string Code { get; set; }
        public double PriceTicket { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
    }
}
