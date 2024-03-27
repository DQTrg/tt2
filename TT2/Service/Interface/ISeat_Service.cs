using TT2.Payload.DataRequest.Seat;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface ISeat_Service
    {
        ResponseObject<DataResponse_Seat> AddSeat (Request_AddSeat request);
        ResponseObject<DataResponse_Seat> UpdateSeat (int seatId, Request_UpdateSeat request);
        ResponseObject<DataResponse_Seat> DeleteSeat (int seatId);
    }
}
