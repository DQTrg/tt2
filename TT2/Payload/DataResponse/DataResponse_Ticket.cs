using System.Security;

namespace TT2.Payload.DataResponse
{
    public class DataResponse_Ticket
    {
        public string Code { get; set; }
        public double PriceTicket { get; set; }
        public string ScheduleName { get; set; }
        public int SeatNumber { get; set; }
        public string SeatLine { get; set; }
    }
}
