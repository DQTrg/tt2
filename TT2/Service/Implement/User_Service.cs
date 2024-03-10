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
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TT2.Service.Implement
{
    public class User_Service : IUser_Service
    {
        public readonly App_DBcontext dbcontext;
        public readonly ResponseObject<DataResponse_User> response;
        public readonly UserConverter converter;
        private readonly IConfiguration _configuration;
        private readonly ResponseObject<DataResponseToken> _responseTokenObject;
        private readonly HttpContextAccessor _httpContextAccessor;

        public User_Service(IConfiguration configuration)
        {
            dbcontext = new App_DBcontext();
            response = new ResponseObject<DataResponse_User>();
            converter = new UserConverter();
            _configuration = configuration;
            _responseTokenObject = new ResponseObject<DataResponseToken>();
            _httpContextAccessor = new HttpContextAccessor();
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

        public IQueryable<DataResponse_User> GetAllUser()
        {
            var users = dbcontext.Users.Select(u => converter.EntityToDTO(u));
            return users;
        }

        public DataResponse_User GetUserById(int id)
        {
            var user = dbcontext.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            return converter.EntityToDTO(user);
        }

        public ResponseObject<DataResponseToken> Login(Request_Login request)
        {
            var account = dbcontext.Users.SingleOrDefault(x => x.Username.Equals(request.Username));
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return _responseTokenObject.ResponeError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            //bool checkPass = BCryptNet.Verify(request.password, account.Password);// so sánh mật khẩu vừa nhập và mật khẩu trong DB
            bool checkPass = request.Password.Equals(account.Password);
            if ((!checkPass)) // nếu mật khẩu sai
            {
                return _responseTokenObject.ResponeError(StatusCodes.Status400BadRequest, "Mật khẩu không chính xác", null);
            }
            sendmail(account.Email, "Đăng nhập thành công");
            return _responseTokenObject.ResponseSucess("Dang nhap thanh cong", GenerateAccessToken(account));

        }
        public DataResponseToken GenerateAccessToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);

            var role = dbcontext.Roles.SingleOrDefault(x => x.Id == user.RoleId);
            // mô tả token
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("User_Name", user.Username.ToString()),
                    new Claim(ClaimTypes.Role, role.Code),

                }),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            // tạo token
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            // hiển thị token dưới dạng chuỗi
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            RefreshToken rf = new RefreshToken
            {
                Token = refreshToken,
                ExpiredTime = DateTime.Now.AddDays(1),
                UserId = user.Id
            };
            dbcontext.RefreshTokens.Add(rf);
            dbcontext.SaveChanges();

            DataResponseToken resoult = new DataResponseToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken

            };
            return resoult;

        }
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        private string GenerateResetToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public DataResponseToken RenewAccessToken(Request_RenewAccessToken request)
        {
            throw new NotImplementedException();
        }
        public ResponseObject<DataResponse_User> ForgotPassword(string email)
        {
            var user = dbcontext.Users.SingleOrDefault(x => x.Email.Equals(email));
            if (user == null)
            {
                return response.ResponeError(StatusCodes.Status404NotFound, "Email không tìm thấy trong DB", null);
            }


            var resetToken = GenerateResetToken();


            var refreshToken = new RefreshToken
            {
                Token = resetToken,
                ExpiredTime = DateTime.Now.AddHours(1),
                UserId = user.Id
            };

            dbcontext.RefreshTokens.Add(refreshToken);
            dbcontext.SaveChanges();


            SendPasswordResetEmail(email, resetToken);

            return response.ResponseSucess("Password reset instructions sent to your email", null);
        }

        public ResponseObject<DataResponse_User> ResetPassword(Request_ResetPassword request)
        {
            var user = dbcontext.Users.SingleOrDefault(usr => usr.Email.Equals(request.email));
            if (user == null)
            {
                return response.ResponeError(StatusCodes.Status404NotFound, "User not found", null);
            }


            var refreshToken = dbcontext.RefreshTokens.SingleOrDefault(rt => rt.UserId == user.Id && rt.Token == request.resetToken);

            if (refreshToken == null || refreshToken.ExpiredTime < DateTime.Now)
            {
                return response.ResponeError(StatusCodes.Status400BadRequest, "Invalid or expired reset token", null);
            }


            var account = dbcontext.Users.SingleOrDefault(acc => acc.Id == user.Id);

            if (account == null)
            {
                return response.ResponeError(StatusCodes.Status404NotFound, "Account not found", null);
            }


            account.Password = BCryptNet.HashPassword(request.newPassword);


            dbcontext.RefreshTokens.Remove(refreshToken);
            dbcontext.SaveChanges();

            return response.ResponseSucess("Password reset successfully", null);
        }
        private void SendPasswordResetEmail(string email, string resetToken)
        {
            var emailTo = new EmailTo
            {
                Mail = email,
                Subject = "Ma reset mat khau cua ban tao thanh cong",
                Content = $"ma resetToken cua ban la: {resetToken}"
            };

            SendEmail(emailTo);
        }


        // Sử dụng Mật khẩu Ứng dụng của bạn để xác thực Gmail
        private const string SmtpPassword = "kvyz gumz rimx kcdn";
    }
}
