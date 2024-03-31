using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest.Ticket;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Ticket_Service : ITicket_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Ticket> _response;
        public readonly TicketConverter _converter;
        public Ticket_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Ticket>();
            _converter = new TicketConverter();
        }
        public ResponseObject<DataResponse_Ticket> AddTicket(Request_AddTicket request)
        {
            var seat = _dbcontext.Seats.SingleOrDefault(x => x.Id == request.SeatId);
            if (seat == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            var schedule = _dbcontext.Schedules.SingleOrDefault(x => x.Id == request.ScheduleId);
            if (schedule == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            var ticket = new Ticket()
            {
                Code = request.Code,
                PriceTicket = request.PriceTicket,
                ScheduleId = schedule.Id,
                SeatId = request.SeatId,
                IsActive = false,
            };
            _dbcontext.Tickets.Add(ticket);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(ticket));
        }

        public ResponseObject<DataResponse_Ticket> UpdateTicket(int ticketId, Request_UpdateTicket request)
        {
            var ticket = _dbcontext.Tickets.SingleOrDefault(t => t.Id == ticketId);
            if (ticket == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            ticket.Code = request.Code;
            ticket.PriceTicket = request.PriceTicket;
            ticket.ScheduleId = request.ScheduleId;
            ticket.SeatId = request.SeatId;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("sua thanh cong", _converter.EntityToDTO(ticket));
        }
    }
}
