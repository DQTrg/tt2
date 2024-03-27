using TT2.Payload.DataRequest.Room;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface IRoom_Service
    {
        ResponseObject<DataResponse_Room> AddRoom(Request_AddRoom request);
        ResponseObject<DataResponse_Room> UpdateRoom(int roomId, Request_UpdateRoom request);
        ResponseObject<DataResponse_Room> DeleteRoom(int roomId);
    }
}
