using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface ICinema_Service
    {
        ResponseObject<DataResponse_Cinema> AddCinema(Request_UpdateCinema request);
        ResponseObject<DataResponse_Cinema> UpdateCinema (int cinemaId, Request_UpdateCinema request);
        ResponseObject<DataResponse_Cinema> DeleteCinema (int cinemaId);
    }
}
