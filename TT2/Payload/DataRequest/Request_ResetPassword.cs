namespace TT2.Payload.DataRequest
{ 
    public class Request_ResetPassword
    {
        public string email { get; set; }
        public string newPassword { get; set; }
        public string resetToken { get; set; }
    }
}
