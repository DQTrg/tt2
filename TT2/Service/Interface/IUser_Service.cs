using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface IUser_Service
    {
        ResponseObject<DataResponse_User> Register(Request_register request);
        IQueryable<DataResponse_User> GetAllUser();
        DataResponse_User GetUserById(int id);
    }
}
