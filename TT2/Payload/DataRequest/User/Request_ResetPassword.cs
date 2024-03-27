namespace TT2.Payload.DataRequest.User
{
    public class Request_ResetPassword
    {
        public string email { get; set; }
        public string newPassword { get; set; }
        public string resetToken { get; set; }
    }
}
