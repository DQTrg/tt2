using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;
using TT2.Email;

namespace TT2.Service.Implement
{
    public class User_Service : IUser_Service
    {
        public readonly App_DBcontext dbcontext;
        public readonly ResponseObject<DataResponse_User> response;
        public readonly UserConverter converter;

        public User_Service()
        {
            dbcontext = new App_DBcontext();
            response = new ResponseObject<DataResponse_User>();
            converter = new UserConverter();
        }

        public ResponseObject<DataResponse_User> Register(Request_register request)
        {
            // kiểm tra thông tin điền vào có bị trống hay không
            if( string.IsNullOrWhiteSpace(request.Username)
              ||string.IsNullOrWhiteSpace(request.Name)
              ||string.IsNullOrWhiteSpace(request.Email)
              ||string.IsNullOrWhiteSpace(request.Password)
              ||string.IsNullOrWhiteSpace(request.PhoneNumber)
              ) 
            {
                return response.ResponeError(StatusCodes.Status400BadRequest, "Vui long nhap day du thong tin dang ky", null);
            }
            // kiểm tra email / username đã tồn tại trong DB hay chưa
            if(dbcontext.Users.Any(x => x.Email == request.Email))
            {
                return response.ResponeError(StatusCodes.Status400BadRequest, "email đã tồn tại vui lòng sử dụng email khác", null);
            }
            if(dbcontext.Users.Any(x => x.Username == request.Username)) 
            {
                return response.ResponeError(StatusCodes.Status400BadRequest, "Username đã tồn tại vui lòng sử dụng username khác", null);
            }
            User user = new User();
            user.Username = request.Username;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.RankCustomerId = 1;
            user.IsActive = true;
            user.RoleId = 1;
            user.UserStatusId = 1;
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            sendmail(user.Email, "Chúc mừng bạn đã tạo tài khoản thành công");
            return response.ResponseSucess("Bạn đã tạo tài khoản thành công", converter.EntityToDTO(user));

        }

        // gửi email

        public void sendmail(string email, string message)
        {
            var emailTo = new EmailTo
            {
                Mail = email,
                Subject = "Đăng ký tài khoản thành công",
                Content = message
            };
            SendEmail(emailTo); 
        }
        public string SendEmail(EmailTo emailTo)
        {
            if (!Validate.IsValidEmail(emailTo.Mail))
            {
                return "Định dạng email không hợp lệ";
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("vuquang01dl@gmail.com", "kvyz gumz rimx kcdn"),
                EnableSsl = true
            };
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("vuquang01dl@gmail.com");
                message.To.Add(emailTo.Mail);
                message.Subject = emailTo.Subject;
                message.Body = emailTo.Content;
                message.IsBodyHtml = true;
                smtpClient.Send(message);

                return "Gửi email thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi gửi email: " + ex.Message;
            }
        }

        // Sử dụng Mật khẩu Ứng dụng của bạn để xác thực Gmail
        private const string SmtpPassword = "kvyz gumz rimx kcdn";
    }
}
