using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest;
using TT2.Service.Implement;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class UserControler : Controller
    {
        private readonly IUser_Service _user_service;

        public UserControler(IUser_Service user_service)
        {
            _user_service = user_service;
        }
        [HttpPost("/api/auth/register")]
        public IActionResult register([FromForm] Request_register request_Register)
        {
            return Ok(_user_service.Register(request_Register));
        }
        [HttpPost("/api/auth/login")]
        public IActionResult Login([FromForm] Request_Login request)
        {
            return Ok(_user_service.Login(request));
        }
        [HttpGet("laytoanbo")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUser()
        {
            try
            {
                var users = _user_service.GetAllUser();
                return Ok(users);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }
        [HttpGet("TimKiemTheoId")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUserById(int id) 
        {
            try
            {
                var user = _user_service.GetUserById(id);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch(UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }
        [HttpPost("forgot")]
        public IActionResult ForgotPassword(Request_ForgotPassword request)
        {
            return Ok(_user_service.ForgotPassword(request.email));
        }

        [HttpPost("reset")]
        public IActionResult ResetPassword(Request_ResetPassword request)
        {
            return Ok(_user_service.ResetPassword(request));
        }

        [HttpPost("active")]
        public IActionResult xacthuc(string email, string token)
        {
            return Ok(_user_service.xacthuc(email, token));
        }

    }
}
