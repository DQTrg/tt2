using TT2.Entity;
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
        DataResponseToken GenerateAccessToken(User user);
        DataResponseToken RenewAccessToken(Request_RenewAccessToken request);
        ResponseObject<DataResponseToken> Login(Request_Login request);
        ResponseObject<DataResponse_User> ForgotPassword(string email);
        ResponseObject<DataResponse_User> ResetPassword(Request_ResetPassword request);
        ResponseObject<DataResponse_User> xacthuc(string email, string token);

    }
}
