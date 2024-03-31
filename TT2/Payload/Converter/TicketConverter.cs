using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class TicketConverter
    {
        public readonly App_DBcontext dbcontext;
        public TicketConverter() 
        { 
            dbcontext = new App_DBcontext();
        
        }
        public DataResponse_Ticket EntityToDTO(Ticket ticket)
        {
            return new DataResponse_Ticket()
            {
                Code = ticket.Code,
                ScheduleName = dbcontext.Schedules.SingleOrDefault(x => x.Id == ticket.ScheduleId).Name,
                SeatLine = dbcontext.Seats.SingleOrDefault(x => x.Id == ticket.SeatId).Line,
                SeatNumber = dbcontext.Seats.SingleOrDefault(x => x.Id == ticket.SeatId).Number,
                PriceTicket = ticket.PriceTicket,
            };
        }
    }
}
