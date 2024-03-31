using TT2.Payload.DataRequest.Ticket;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface ITicket_Service
    {
        ResponseObject<DataResponse_Ticket> AddTicket(Request_AddTicket request);
        ResponseObject<DataResponse_Ticket> UpdateTicket(int ticketId, Request_UpdateTicket request);
    }
}
